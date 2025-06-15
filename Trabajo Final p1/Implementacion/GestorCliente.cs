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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Trabajo_Final_p1.Clases
{
    public class GestorCliente : IGCliente<Cliente>

    {
        private BindingList<Cliente> _clientes;


        public BindingList<Cliente> clientes => _clientes;



        public void CargarLista()

        {
            _clientes.Clear();
            foreach (var linea in File.ReadAllLines("Clientes.csv"))
            {
                var partes = linea.Split(';');
                if (partes.Length == 5)
                {
                    Cliente cli = new Cliente(partes[0], partes[1], partes[2], Convert.ToInt32(partes[3]), Convert.ToInt32(partes[4]));
                    _clientes.Add(cli);
                }
            }
        }

        public GestorCliente()
        {
            _clientes = new BindingList<Cliente>();
            CargarLista();
        }





        public void Agregar(Cliente cliente)
        {
            // Creo que lo hice al pedo, agregamos clientes por otro metodo
          

            if (cliente == null)
            {
                throw new ArgumentNullException(nameof(cliente), "El cliente no puede ser nulo.");
            }
            else {
                using (FileStream fs = new FileStream("Clientes.csv", FileMode.Append, FileAccess.Write))   
                    using (StreamWriter sw = new StreamWriter(fs))
                    { 
                    sw.WriteLine($"{cliente.Nombre};{cliente.Apellido};{cliente.Email};{cliente.Telefono};{cliente.DNI}");
                   
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
                            string linea = ($"{clienteR.Nombre};{clienteR.Apellido};{clienteR.Email};{clienteR.Telefono};{clienteR.DNI}");
                            sw.WriteLine(linea);
                        }
                     }

                }

            }
            this.CargarLista();
            MessageBox.Show($"Cliente con DNI {dni} eliminado correctamente del archivo.", "Eliminación Exitosa",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

         public void Modificar(Cliente cliente, string nom, string ape, string email, int celular, int dni)
        {
            this.CargarLista();
            //busca en la lista de clientes leida del csv
            int dniBuscado = cliente.DNI;
            var clienteR = clientes.FirstOrDefault(c => c.DNI == dniBuscado);
            if (cliente != null)
            {
                cliente.Nombre = nom;
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
                    string linea = $"{c.Nombre};{c.Apellido};{c.Email};{c.Telefono};{c.DNI}";
                    sw.WriteLine(linea);
                }
                sw.Close();








            }

        }
    }
}
