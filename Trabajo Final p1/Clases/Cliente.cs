using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Final_p1.Clases
{
    public class Cliente : Usuario
    {
        //Hereda Nombre, apellido y DNI de la clase abstracta Persona

        //Constructor
        public Cliente(string Nombre, string Apellido,string Contraseña, string Email,int Telefono,int dni ) : base(Nombre, Apellido,dni, Contraseña, Email, false)
        
        {
  
         this.Telefono = Telefono;
        
 
        }


        //Propiedades de Cliente
        private int _telefono;

        public int Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

       
        internal List<Viaje> ListaViajes;






    }
}
