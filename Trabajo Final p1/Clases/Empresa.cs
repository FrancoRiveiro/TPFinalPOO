using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Final_p1.Clases
{
    public class Empresa
    {

        private int _idEmpresa;

        public int IDEmpresa
        {
            get { return _idEmpresa; }
            set { _idEmpresa = value; }
        }

        private string _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }



    }
}
