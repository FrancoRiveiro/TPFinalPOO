using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Final_p1.Clases
{
    public class Cliente : Persona
    {
        //Hereda Nombre, apellido y DNI de la clase abstracta Persona

        //Constructor
        public Cliente(string Nombre, string Apellido, string Email,int Telefono,int DNI)
        
        {
         this.Nombre = Nombre;
         this.Apellido = Apellido;
         this.Email = Email;
         this.Telefono = Telefono;
         this.DNI = DNI;

            
        
        
        }


        //Propiedades de Cliente
        private int _telefono;

        public int Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        internal List<Viaje> ListaViajes;






    }
}
