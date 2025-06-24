using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabajo_Final_p1.Clases;
using Trabajo_Final_p1.Interfaces;

namespace Trabajo_Final_p1.Implementacion
{
    /*
    public  class GestionViajeDao: IGestor<Viaje>
    {


        private BindingList<Viaje> _viaje ;


        public BindingList<Viaje> viajes => _viaje;

        
        public GestionEmpresaDao()
        {
            _viaje = new BindingList<Viaje>();
            CargarLista();
        }
        public BindingList<Viaje> CargarLista()

        {
            _empresa.Clear();
            foreach (var linea in File.ReadAllLines("Viaje.csv"))
            {
                var partes = linea.Split(';');
                if (partes.Length == 4)
                {
                    Empresa emp = new Empresa(Convert.ToInt32(partes[0]), partes[1], Convert.ToInt32(partes[2]), partes[3]);
                    _empresa.Add(emp);
                }
            }
            return _empresa;
        }
        public void Agregar(Viaje empresa)
        {
            if (empresa == null)

            {

                throw new ArgumentNullException(nameof(empresa), "La Empresa no puede ser nulo.");
            }
            else
            {
                using (FileStream fs = new FileStream("Viaje.csv", FileMode.Append, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine($"{empresa.IDEmpresa};{empresa.Nombre};{empresa.CodPostal};{empresa.Direccion}");
                }
                this.CargarLista();
            }
        }





        public void Eliminar(int idEmpresa)
        {
            using (FileStream fs = new FileStream("Viaje.csv", FileMode.Truncate, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    foreach (var empresaR in empresas)
                    {
                        if (empresaR.IDEmpresa != idEmpresa)
                        {
                            string linea = ($"{empresaR.IDEmpresa};{empresaR.Nombre};{empresaR.CodPostal};{empresaR.Direccion}");
                            sw.WriteLine(linea);
                        }
                    }
                }
            }
            this.CargarLista();
            MessageBox.Show($"Cliente con DNI {idEmpresa} eliminado correctamente del archivo.", "Eliminación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        public void Modificar(Viaje empresa, params object[] datos)
        {
            if (datos.Length < 4)
            {
                throw new ArgumentException("Debe proporcionar al menos 2 datos para modificar el cliente.");
            }
            int IdEmp = Convert.ToInt32(datos[0]);
            string nom = datos[1].ToString();
            int CodPos = Convert.ToInt32(datos[2]);
            string dir = datos[3].ToString();



            //busca en la lista de clientes leida del csv
            int idBuscado = empresa.IDEmpresa;
            var EmpresaR = empresas.FirstOrDefault(x => x.IDEmpresa == idBuscado);
            if (empresa != null)
            {
                empresa.IDEmpresa = IdEmp;
                empresa.Nombre = nom;
                empresa.CodPostal = CodPos;
                empresa.Direccion = dir;


            }

            //reescribe el archivo con el cliente modificado
            using (StreamWriter sw = new StreamWriter("Empresa.csv", false)) // false para sobrescribir
            {
                foreach (var c in empresas)
                {
                    string linea = $"{c.IDEmpresa};{c.Nombre};{c.CodPostal};{c.Direccion}";
                    sw.WriteLine(linea);
                }
                sw.Close();
            }

        }

        public List<Viaje> Listar() => new List<Viaje>();

    }


    */

}
   
