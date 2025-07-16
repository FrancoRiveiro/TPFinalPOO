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

        public Viaje(int id, string dest, DateTime salida, DateTime retorno, Empresa emp, MedioDeTransporte transp, int km)
        {
            this.IDViaje = id;
            this.Destino = dest;
            this.FechaSalida = salida;
            this.FechaRetorno = retorno;
            this.Empresa = emp;
            this.Transporte = transp;
            this.CuposTotales = transp.Cupos;
            this.KM = km;
            this.Costo = this.CalcularCostoTotal();
        }

        //propiedades

        string NombreEmpresa => Empresa?.Nombre;
        string NombreTransporte => Transporte?.Nombre;
        private int _cuposTotales;

        public int CuposTotales
        {
            get { return _cuposTotales; }
            set { _cuposTotales = value; }
        }

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

        private MedioDeTransporte _transporte;

        public MedioDeTransporte Transporte
        {
            get { return _transporte; }
            set { _transporte = value; }
        }
        private int _km;

        public int KM
        {
            get { return _km; }
            set { _km = value; }
        }

        private int _cuposDisponibles;

        public int CuposDisponibles
        {
            get { return _cuposDisponibles; }
            set { _cuposDisponibles = value; }
        }

        private int _costo;

        public int Costo
        {
            get { return _costo; }
            set { _costo = value; }
        }





        public int CalcularCostoTotal()
        {
            int total = KM * Transporte.ValorKM;                       
            return total;
        }

        









    }
}
