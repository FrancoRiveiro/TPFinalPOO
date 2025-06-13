using System;
using System.Collections.Generic;
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
    public class GestorCliente : IGestor<Cliente>

    {
        private List<Cliente> clientes;
        public void CargarLista()
        {
            clientes = new List<Cliente>();
            foreach (var linea in File.ReadAllLines("Clientes.csv"))
            {
                var partes = linea.Split(';');
                if (partes.Length == 5)
                {
                    Cliente cli = new Cliente(partes[0], partes[1], partes[2], Convert.ToInt16(partes[3]), Convert.ToInt16(partes[4]));
                    clientes.Add(cli);
                }
            }
        }

        public GestorCliente()
        {
            clientes = new List<Cliente>();
        }


        public void Agregar(Cliente entidad)
        {
            // Creo que lo hice al pedo, agregamos clientes por otro metodo
            this.CargarLista();
            if (entidad == null)
            {
                throw new ArgumentNullException(nameof(entidad), "El cliente no puede ser nulo.");
            }
            else {
                FileStream fs = new FileStream("Clientes.csv", FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine($"{entidad.Nombre};{entidad.Apellido};{entidad.Email};{entidad.Telefono};{entidad.DNI}");
                sw.Close();
                fs.Close();
                clientes.Add(entidad);
            }
        }

        public void Eliminar(Cliente entidad)
        {

            this.CargarLista();
            clientes.Remove(entidad);
            //reescribe el archivo sin el cliente borrado
            FileStream fs = new FileStream("Clientes.csv", FileMode.Truncate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            foreach (var cliente in clientes)
            {
                string linea = ($"{cliente.Nombre};{cliente.Apellido};{cliente.Email};{cliente.Telefono};{cliente.DNI}");
                sw.WriteLine(linea);
            }
         
            sw.Close();
            fs.Close();



        }

         public void Modificar(Cliente entidad, string nom, string ape, string email, int celular, int dni)
        {
            this.CargarLista();
            //busca en la lista de clientes leida del csv
            int dniBuscado = entidad.DNI;
            var cliente = clientes.FirstOrDefault(c => c.DNI == dniBuscado);
            if (cliente != null)
            {
                entidad.Nombre = nom;
                entidad.Email = email;
                entidad.Apellido = ape;
                entidad.Telefono = celular;
                entidad.DNI = dni;

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
