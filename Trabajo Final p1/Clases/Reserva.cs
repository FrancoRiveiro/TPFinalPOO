using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Final_p1.Clases
{
    public class Reserva
    {

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

        public List<Cliente> clientes { get; set; }


    }
}
