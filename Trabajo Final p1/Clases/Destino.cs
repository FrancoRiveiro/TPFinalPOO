using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Final_p1.Clases
{
    public class Destino
    {
        //constructor
        public Destino() { }

        //propiedades
        private int _IdDestino;

        public int IDDestino
        {
            get { return _IdDestino; }
            set { _IdDestino = value; }
        }
        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private int _cuposDisponibles;

        public int CuposDisponibles
        {
            get { return _cuposDisponibles; }
            set { _cuposDisponibles = value; }
        }

        private int _cuposTotales;

        public int CuposTotales
        {
            get { return _cuposTotales; }
            set { _cuposTotales = value; }
        }


    }
}
