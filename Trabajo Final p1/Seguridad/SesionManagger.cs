using Trabajo_Final_p1.Clases;

namespace Trabajo_Final_p1.Seguridad
{
    public class SesionManagger
    {
        private static SesionManagger _instancia;

        // Variable para almacenar el usuario activo
        public static readonly object _lock = new object();

        // Propiedad para acceder a la persona en sesión y evitar que sea modificada directamente desde fuera de la clase
        public Usuario persona { get; private set; }

        public static SesionManagger Instancia
        {
            get
            {
                // Verifica si la instancia ya ha sido creada
                lock (_lock)
                {

                    if (_instancia == null)
                    {
                        _instancia = new SesionManagger();
                    }
                    return _instancia;
                }
            }
        }


    }
}




    