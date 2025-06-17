using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Final_p1.Interfaces
{
    public  interface IGestor<in T> where T : class
    {


        void Agregar(T entidad);


        void Modificar(T entidad, params object[] valoresExtra);

        void Eliminar(int id);


        /*
        List<T> listar();*/

    }
}
