using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabajo_Final_p1.Clases;

namespace Trabajo_Final_p1.Forms
{
    public partial class Pagar : Form
    {
        private Viaje viaje;
        private Usuario usuarioLogueado;
        private int CuposDeseados;

        public Pagar(Viaje viaje, Usuario usuariologeado, int Cuposdeseados)
        {
            InitializeComponent();
            this.viaje = viaje;
            this.usuarioLogueado = usuariologeado;
            this.CuposDeseados = Cuposdeseados;
        }

    }
}
