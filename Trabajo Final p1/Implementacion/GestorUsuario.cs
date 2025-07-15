using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Trabajo_Final_p1.Interfaces;
using Trabajo_Final_p1.Seguridad;

namespace Trabajo_Final_p1.Clases
{
    public class GestorUsuario<T> : IGestor<T> where T : Usuario

    {

        private BindingList<T> _usuarios = new BindingList<T>();

        // Propiedad para acceder a la lista de clientes
        public BindingList<T> Usuario => _usuarios;



        public BindingList<T> CargarLista()

        {
            _usuarios.Clear();
            foreach (var linea in File.ReadAllLines("Usuarios.csv"))
            {
                var partes = linea.Split(';');
                if (partes.Length == 7)
                {

                    string nombre = partes[0];
                    string apellido = partes[1];
                    string contraseña = partes[2];
                    string email = partes[3];
                    int telefono = int.Parse(partes[4]);
                    int dni = int.Parse(partes[5]);
                    bool rol = bool.Parse(partes[6]);


                    if (typeof(T) == typeof(Cliente) && rol == false)
                    {

                        var cli = new Cliente(partes[0], partes[1], partes[2], partes[3], Convert.ToInt32(partes[4]), Convert.ToInt32(partes[5]));
                        _usuarios.Add((T)(object)cli);

                    }
                    else if (typeof(T) == typeof(Administrador) && rol == true)
                    {
                        var admin = new Administrador(partes[0], partes[1], partes[2], partes[3], Convert.ToInt32(partes[4]), Convert.ToInt32(partes[5]));
                        _usuarios.Add((T)(object)admin);
                    }

                }
            }
            return _usuarios;

        }


        public GestorUsuario()
        {
            _usuarios = new BindingList<T>();
            CargarLista();
            if (typeof(T) == typeof(Administrador))
            {
                InicializarAdministradores();
            }
        }





        public void Agregar(T usuario)
        {
            if (usuario == null)
            {
                throw new ArgumentNullException(nameof(usuario), "El Usuario no puede ser nulo.");
            }
            else
            {
                using (FileStream fs = new FileStream("Usuarios.csv", FileMode.Append, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    if (usuario is Cliente cliente)
                    {
                        sw.WriteLine($"{cliente.Nombre};{cliente.Apellido};{cliente.Contraseña};{cliente.Email};{cliente.Telefono};{cliente.DNI};{cliente.Rol}");

                    }
                    else if (usuario is Administrador administrador)
                    {
                        sw.WriteLine($"{administrador.Nombre};{administrador.Apellido};{administrador.Contraseña};{administrador.Email};{administrador.Telefono};{administrador.DNI};{administrador.Rol}");
                    }
                }
                this.CargarLista();
            }
        }

        public void Eliminar(int dni)
        {
            using (FileStream fs = new FileStream("Usuarios.csv", FileMode.Truncate, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    foreach (var usuario in _usuarios)
                    {
                        if (usuario is Cliente cliente && cliente.DNI != dni)
                        {
                            string linea = ($"{cliente.Nombre};{cliente.Apellido};{cliente.Contraseña};{cliente.Email};{cliente.Telefono};{cliente.DNI};{cliente.Rol}");
                            sw.WriteLine(linea);
                        }
                        else if (usuario is Administrador administrador && administrador.DNI != dni)
                        {
                            string linea = ($"{administrador.Nombre};{administrador.Apellido};{administrador.Contraseña};{administrador.Email};{administrador.Telefono};{administrador.DNI};{administrador.Rol}");
                            sw.WriteLine(linea);
                        }

                    }
                }
                this.CargarLista();
                MessageBox.Show($"Usuario con DNI {dni} eliminado correctamente del archivo.", "Eliminación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void Modificar(T usuario, params object[] datos)
        {

            if (datos.Length < 6)
            {
                throw new ArgumentException("Debe proporcionar al menos 6 datos para modificar el cliente.");
            }
            string nom = datos[0].ToString();
            string ape = datos[1].ToString();
            string contra = datos[2].ToString();
            string email = datos[3].ToString();
            int celular = (int)Convert.ToInt64(datos[4]);
            int dni = Convert.ToInt32(datos[5]);


            if (usuario is Cliente cliente)
            {
                //busca en la lista de clientes leida del csv
                //int dniBuscado = cliente.DNI;
                var clienteR = _usuarios.OfType<Cliente>().FirstOrDefault(c => c.DNI == cliente.DNI);
                if (clienteR != null)
                {
                    clienteR.Nombre = nom;
                    clienteR.Contraseña = contra; // Asignar la contraseña
                    clienteR.Email = email;
                    clienteR.Apellido = ape;
                    clienteR.Telefono = celular;
                    clienteR.DNI = dni;

                }
            }
            else if (usuario is Administrador adminstrador)
            {
                var AdminR = _usuarios.OfType<Administrador>().FirstOrDefault(c => c.DNI == adminstrador.DNI);
                if (AdminR != null)
                {

                    AdminR.Nombre = nom;
                    AdminR.Contraseña = contra; // Asignar la contraseña
                    AdminR.Email = email;
                    AdminR.Apellido = ape;
                    AdminR.Telefono = celular;
                    AdminR.DNI = dni;
                }

            }
            //reescribe el archivo con el cliente modificado
            using (StreamWriter sw = new StreamWriter("Usuarios.csv", false)) // false para sobrescribir
            {
                foreach (var u in _usuarios)
                {
                    if (u is Cliente c)
                    {
                        string linea = $"{c.Nombre};{c.Apellido};{c.Contraseña};{c.Email};{c.Telefono};{c.DNI};{c.Rol}";
                        sw.WriteLine(linea);
                    }
                    else if (u is Administrador a)
                    {
                        string linea = $"{a.Nombre};{a.Apellido};{a.Contraseña};{a.Email};{a.Telefono};{a.DNI};{a.Rol}";
                        sw.WriteLine(linea);
                    }

                }
                sw.Close();
            }
        }



        private void InicializarAdministradores()

        {
            if (!_usuarios.Any(u => u.Email == "admin1@gmail.com"))
            {
                var admin1 = new Administrador("Juan Pablo", "Ortega", ContraseñaHasher.GenerarHash("admin1"), "admin1@gmail.com", 1125551870, 46498814);
                _usuarios.Add((T)(object)admin1);
                Agregar((T)(object)admin1);
            }
            if (!_usuarios.Any(u => u.Email == "admin2@gmail.com"))
            {

                var admin2 = new Administrador("Franco Gabriel", "Riveiro", ContraseñaHasher.GenerarHash("admin2"), "admin2@gmail.com", 1136266825, 40498814);
                _usuarios.Add((T)(object)admin2);
                Agregar((T)(object)admin2);
            }


        }

        public T Obtener(int dni)
        {
            
            
              return _usuarios.FirstOrDefault(v => v.DNI == dni);
            
        }
    }
}

