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
    public class GestionViajesDao : IGestor<Viaje>
    {
        private BindingList<Viaje> _viaje;
        public BindingList<Viaje> viajes => _viaje;

        GestionEmpresaDao gestorE = new GestionEmpresaDao();
        GestionTransporteDao gestorT = new GestionTransporteDao();
        BindingList<Empresa> listaEmpresas = new BindingList<Empresa>();
        BindingList<MedioDeTransporte> listaTranportes = new BindingList<MedioDeTransporte>();

        public GestionViajesDao()
        {
            //cargamos ambas listas de Transportes y Empresas
            listaTranportes = gestorT.CargarLista();
            listaEmpresas = gestorE.CargarLista();
            _viaje = new BindingList<Viaje>();            
            _viaje = CargarLista(listaEmpresas, listaTranportes);
        }
        public BindingList<Viaje> CargarLista(BindingList<Empresa> empresas, BindingList<MedioDeTransporte> transportes)

        {
            _viaje.Clear();
            foreach (var linea in File.ReadAllLines("Viajes.csv"))
            {
                var partes = linea.Split(';');
                if (partes.Length == 7)
                {

                    Viaje via = new Viaje(
                        Convert.ToInt32(partes[0]),
                        partes[1],
                        Convert.ToDateTime(partes[2]),
                        Convert.ToDateTime(partes[3]),
                        empresas.FirstOrDefault(e => e.Nombre.Equals(partes[4], StringComparison.OrdinalIgnoreCase)),
                        transportes.FirstOrDefault(t => t.Nombre.Equals(partes[5], StringComparison.OrdinalIgnoreCase)),
                        Convert.ToInt32(partes[6])
                        );
                    _viaje.Add(via);
                }
            }
            return _viaje;
        }

        public void Agregar(Viaje viaje)
        {
            if (viaje == null)

            {

                throw new ArgumentNullException(nameof(viaje), "El viaje no puede ser nulo.");
            }
            else
            {
                using (FileStream fs = new FileStream("Viajes.csv", FileMode.Append, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine($"{viaje.IDViaje};{viaje.Destino};{viaje.FechaSalida};{viaje.FechaRetorno};{viaje.Empresa.Nombre};{viaje.Transporte.Nombre};{viaje.KM}");
                }
                CargarLista(listaEmpresas, listaTranportes);
            }
        }

        public void Eliminar(int idViaje)
        {
            using (FileStream fs = new FileStream("Viajes.csv", FileMode.Truncate, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    foreach (var viajeR in viajes)
                    {
                        if (viajeR.IDViaje != idViaje)
                        {
                            string linea = ($"{viajeR.IDViaje};{viajeR.Destino};{viajeR.FechaSalida};{viajeR.FechaRetorno};{viajeR.Empresa.Nombre};{viajeR.Transporte.Nombre};{viajeR.KM}");
                            sw.WriteLine(linea);
                        }
                    }
                }
            }
            this.CargarLista(listaEmpresas, listaTranportes);
            MessageBox.Show($"Cliente con DNI {idViaje} eliminado correctamente del archivo.", "Eliminación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        public void Modificar(Viaje viaje, params object[] datos)
        {
            listaEmpresas = gestorE.CargarLista();
            listaTranportes = gestorT.CargarLista();
            CargarLista(listaEmpresas, listaTranportes);

            if (datos.Length < 7)
            {
                throw new ArgumentException("Debe proporcionar al menos 6 datos para modificar el viaje.");
            }
            int IdVia = Convert.ToInt32(datos[0]);
            string destino = datos[1].ToString();
            DateTime salida = Convert.ToDateTime(datos[2]);
            DateTime retorno = Convert.ToDateTime(datos[3]);
            Empresa empresa = listaEmpresas.FirstOrDefault(e => e.Nombre.Equals(datos[4]));
            MedioDeTransporte transporte = listaTranportes.FirstOrDefault(c => c.Nombre.Equals(datos[5]));
            int km = Convert.ToInt32(datos[6]);

            //busca en la lista de viajes leida del csv
            int idBuscado = viaje.IDViaje;
            var EmpresaR = viajes.FirstOrDefault(x => x.IDViaje == idBuscado);
            if (viaje != null)
            {
                viaje.IDViaje = IdVia;
                viaje.Destino = destino;
                viaje.FechaSalida = salida;
                viaje.FechaRetorno = retorno;
                viaje.Empresa = empresa;
                viaje.Transporte = transporte;
                viaje.KM = km;


            }

            //reescribe el archivo con el cliente modificado
            using (StreamWriter sw = new StreamWriter("Viajes.csv", false)) // false para sobrescribir
            {
                foreach (var c in viajes)
                {
                    string linea = $"{c.IDViaje};{c.Destino};{c.FechaSalida};{c.FechaRetorno};{c.Empresa.Nombre};{c.Transporte.Nombre};{c.KM}";
                    sw.WriteLine(linea);
                }
                sw.Close();
            }

        }

        public Viaje Obtener(int id)
        {
            return viajes.FirstOrDefault(v => v.IDViaje == id);
        }

       
    }

}
   
