using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trabajo_Final_p1.Clases
{
    public class Reserva
    {
        public Reserva(int id, int cupos, Cliente cli, Viaje viaje)
        {
			this.idReserva = id;
			this.Cupos = cupos;
			this.Cliente = cli;
			this.ViajeReservado = viaje;
			this.CostoTotal = (viaje != null ? viaje.CalcularCostoTotal() : 0) * cupos;
            
        }
        private int idReserva;

		public int IdReserva
		{
			get { return idReserva; }
			set { idReserva = value; }
		}

		private int _cupos;

		public int Cupos
		{
			get { return _cupos; }
			set { _cupos = value; }
		}

		private Cliente _cliente;

		public Cliente Cliente
		{
			get { return _cliente; }
			set { _cliente = value; }
		}
		private Viaje _viaje;

		public Viaje ViajeReservado
		{
			get { return _viaje; }
			set { _viaje = value; }
		}

		private int _costoTotal;

		public int CostoTotal
		{
			get { return _costoTotal; }
			set { _costoTotal = value; }
		}




	}
}
