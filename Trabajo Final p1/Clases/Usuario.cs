using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Final_p1.Clases
{
    public abstract class Usuario
    {
        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private string _apellido;

        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }
        private int _dni;

        public int DNI
        {
            get { return _dni; }
            set { _dni = value; }
        }
        private string _Contraseña;

        public string Contraseña
        {
            get { return _Contraseña; }
            set { _Contraseña = value; }
        }
        private string _Email;

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        private Boolean _rol;

        public Boolean Rol
        {
            get { return _rol; }
            set { _rol = value; }
        }

        public Usuario(string nombre, string apellido,int dni, string contraseña, string email, bool rol)
        {

            Nombre = nombre;
            Apellido = apellido;
            DNI = dni;
            Contraseña = contraseña;
            Email = email;
            Rol = rol;
        }

       

    }
}
