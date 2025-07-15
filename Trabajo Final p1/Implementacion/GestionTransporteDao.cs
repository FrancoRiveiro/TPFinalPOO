using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_Final_p1.Clases;
using Trabajo_Final_p1.Interfaces;

namespace Trabajo_Final_p1.Implementacion
{
    public class GestionTransporteDao: IGestor<MedioDeTransporte>
    {
        private BindingList<MedioDeTransporte> _transportes;
        public BindingList<MedioDeTransporte> transportes => _transportes;

        public GestionTransporteDao()
        {
            _transportes = new BindingList<MedioDeTransporte>();
            CargarLista();
        }

        public BindingList<MedioDeTransporte> CargarLista()
        {
            _transportes.Clear();
            foreach (var linea in File.ReadAllLines("MediosDeTransporte.csv"))
            {
                var partes = linea.Split(';');
                if (partes.Length == 4)
                {
                    MedioDeTransporte transp = new MedioDeTransporte(Convert.ToInt32(partes[0]),
                        partes[1],
                        Convert.ToInt32(partes[2]),
                        Convert.ToInt32(partes[3]));
                    _transportes.Add(transp);
                }
            }

            return _transportes;
        }

        public MedioDeTransporte Obtener(int id)
        {                        
             return _transportes.FirstOrDefault(v => v.IdTransporte == id);                       
        }


        //No se utilizaran
        public void Agregar(MedioDeTransporte entidad)
        {
            throw new NotImplementedException();
        }

        public void Modificar(MedioDeTransporte entidad, params object[] valoresExtra)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
