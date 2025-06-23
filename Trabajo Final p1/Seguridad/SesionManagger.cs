using Trabajo_Final_p1.Clases;
using System;

namespace Trabajo_Final_p1.Seguridad
{
    public class SesionManagger
    {
        private static SesionManagger _instancia;

        // Variable para almacenar el usuario activo
        public static readonly object _lock = new object();

        // Propiedad para acceder a la persona en sesión y evitar que sea modificada directamente desde fuera de la clase
        public Usuario Usuario { get; private set; }
        public static bool SesionActiva => _instancia != null;
        public static SesionManagger Instancia
        {
            get
            {
                // Verifica si la instancia ya ha sido creada
                if (_instancia == null)
                {
                    throw new Exception ("La sesión no ha sido iniciada. Por favor, inicie sesión primero.");
                }
                return _instancia;

            }
        }

        public static void IniciarSesion(Usuario usuario)
        {
            lock (_lock)
            {
                if (_instancia == null)
                {
                    _instancia = new SesionManagger
                    { Usuario = usuario };

                }
           
            }
        }

        public static void CerrarSesion()
        {

            lock (_lock)
            {
                _instancia = null;


            }
        }

        private SesionManagger()
        {
            // Constructor privado para evitar la creación de instancias desde fuera de la clase
        }
    }
}




    