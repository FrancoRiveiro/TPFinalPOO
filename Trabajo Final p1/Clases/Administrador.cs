using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Final_p1.Clases
{
    public class Administrador : Usuario
    {
        //Hereda Nombre, apellido y DNI de la clase abstracta Persona

        //COnstructor
        public Administrador(string Nombre, string Apellido, string Contraseña, string Email, int Telefono, int dni ) : base (Nombre,Apellido,dni,Contraseña, Email,true )
        {



            this.Telefono = Telefono;
        
          
        }


        private int _telefono;

        public int Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }



    }
}
