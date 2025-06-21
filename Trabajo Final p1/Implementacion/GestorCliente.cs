using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabajo_Final_p1.Interfaces;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Trabajo_Final_p1.Clases
{
    public class GestorCliente : IGestor <Cliente>
    {
        private BindingList<Cliente> _clientes;
        public BindingList<Cliente> clientes => _clientes;
        public BindingList<Cliente> CargarLista()
        {
            _clientes.Clear();
            foreach (var linea in File.ReadAllLines("Clientes.csv"))
            {
                var partes = linea.Split(';');
                if (partes.Length == 6)
                {
                    Cliente cli = new Cliente(partes[0], partes[1], partes[2], partes[3], Convert.ToInt32(partes[4]), Convert.ToInt32(partes[5]));
                    _clientes.Add(cli);
                }
            }
            return _clientes;
        }

        public GestorCliente()
        {
            _clientes = new BindingList<Cliente>();
            CargarLista();
        }





        public void Agregar(Cliente cliente)
        {
            if (cliente == null)
            {
                throw new ArgumentNullException(nameof(cliente), "El cliente no puede ser nulo.");
            }
            else {
                using (FileStream fs = new FileStream("Clientes.csv", FileMode.Append, FileAccess.Write))   
                    using (StreamWriter sw = new StreamWriter(fs))
                    { 
                    sw.WriteLine($"{cliente.Nombre};{cliente.Apellido};{cliente.Contraseña};{cliente.Email};{cliente.Telefono};{cliente.DNI}");       
                    }
                this.CargarLista();
            }
        }

        public void Eliminar(int dni)
        {
            using (FileStream fs = new FileStream("Clientes.csv", FileMode.Truncate, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    foreach (var clienteR in clientes)
                    {
                        if (clienteR.DNI !=dni) {
                            string linea = ($"{clienteR.Nombre};{clienteR.Apellido};{clienteR.Contraseña};{clienteR.Email};{clienteR.Telefono};{clienteR.DNI}");
                            sw.WriteLine(linea);
                        }
                    }
                }
            }
            this.CargarLista();
            MessageBox.Show($"Cliente con DNI {dni} eliminado correctamente del archivo.", "Eliminación Exitosa",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

         public void Modificar(Cliente cliente, params object[] datos)
        {

            if( datos.Length <4)
            {
                throw new ArgumentException("Debe proporcionar al menos 4 datos para modificar el cliente.");
            }
            string nom = datos[0].ToString();
            string ape = datos[1].ToString();
            string contra = datos[2].ToString();
            string email = datos[3].ToString();
            int celular = Convert.ToInt32(datos[4]);
            int dni = Convert.ToInt32(datos[5]);

            
            
            //busca en la lista de clientes leida del csv
            int dniBuscado = cliente.DNI;
            var clienteR = clientes.FirstOrDefault(c => c.DNI == dniBuscado);
            if (cliente != null)
            {
                cliente.Nombre = nom;
                cliente.Contraseña = contra; // Asignar la contraseña
                cliente.Email = email;
                cliente.Apellido = ape;
                cliente.Telefono = celular;
                cliente.DNI = dni;

            }

            //reescribe el archivo con el cliente modificado
            using (StreamWriter sw = new StreamWriter("clientes.csv", false)) // false para sobrescribir
            {
                foreach (var c in clientes)
                {
                    string linea = $"{c.Nombre};{c.Apellido};{c.Contraseña};{c.Email};{c.Telefono};{c.DNI}";
                    sw.WriteLine(linea);
                }
                sw.Close();
            }
            
            
        }
    }
}
