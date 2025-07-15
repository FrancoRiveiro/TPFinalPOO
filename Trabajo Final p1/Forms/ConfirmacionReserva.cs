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
using Trabajo_Final_p1.Implementacion;

namespace Trabajo_Final_p1.Forms
{
    public partial class ConfirmacionReserva : Form
    {
        Usuario usuarioLogueado;
        Viaje viaje;
        private int _cuposDeseados;

        public int CuposDeseados
        {
            get { return _cuposDeseados; }
            set { _cuposDeseados = value; }
        }


        public ConfirmacionReserva(Viaje _viaje, Usuario _usuario)
        {
            InitializeComponent();
            viaje = _viaje;
            label3.Text = viaje.Destino;
            usuarioLogueado = _usuario;
            CuposDeseados = (int)numericUpDown1.Value;
            



        }
        SistemaGestionViajes sistema;
        

        

        private void ConfirmacionReserva_Load(object sender, EventArgs e)
        {
            SistemaGestionViajes sistema = new SistemaGestionViajes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CuposDeseados <= sistema.CalcularCuposDisponibles(viaje.IDViaje)) {
                sistema.RealizarPagoYReserva(usuarioLogueado.DNI, viaje.IDViaje, CuposDeseados); 
            }
            else
            {
                MessageBox.Show($"No hay capacidad para {CuposDeseados} pasajeros mas en este viaje.");
            }
            
        }
    }
}
