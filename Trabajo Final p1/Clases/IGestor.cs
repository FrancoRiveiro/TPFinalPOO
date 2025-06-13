using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Final_p1.Clases
{
    public interface IGestor<in T> where T : class
    {
        void Agregar(T entidad);
        void Modificar(T entidad, string nom, string ape, string email, int celular, int dni);
        void Eliminar(T entidad);
     

    }
}
