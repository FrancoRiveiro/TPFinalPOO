using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Final_p1.Clases
{
    abstract class MedioDeTransporte
    {
		private int _valorKM;

		public int ValorKM
		{
			get { return _valorKM; }
			set { _valorKM = value; }
		}

		private int _capacidad;

		public int Capacidad
		{
			get { return _capacidad; }
			set { _capacidad = value; }
		}
	}
}
