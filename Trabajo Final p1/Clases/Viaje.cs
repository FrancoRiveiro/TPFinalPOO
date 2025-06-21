using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Final_p1.Clases
{
    public class Viaje
    {
        //constructor

        public Viaje(int id, string dest, DateTime salida, DateTime retorno, Empresa emp)
        {
            this.IDViaje = id;
            this.Destino = dest;
            this.FechaSalida = salida;
            this.FechaSalida = retorno;
            this.Empresa = emp;
                

        }

        //propiedades

        private Empresa _empresa;

        public Empresa Empresa
        {
            get { return _empresa; }
            set { _empresa = value; }
        }

        private int _IDViaje;

        public int IDViaje
        {
            get { return _IDViaje; }
            set { _IDViaje = value; }
        }

        private DateTime _fechaSalida;

        public DateTime FechaSalida
        {
            get { return _fechaSalida; }
            set { _fechaSalida = value; }
        }

        private DateTime _fechaRetorno;

        public DateTime FechaRetorno
        {
            get { return _fechaRetorno; }
            set { _fechaRetorno = value; }
        }

        private string _destino;

        public string Destino
        {
            get { return _destino; }
            set { _destino = value; }
        }

        internal List<Cliente> clientes;
        



    }
}
