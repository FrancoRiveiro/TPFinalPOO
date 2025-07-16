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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Trabajo_Final_p1.Forms
{
    public partial class ConfirmacionReserva : Form
    {
        Form Pagar = new Form();
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
            
        }
 
        private void ConfirmacionReserva_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SistemaGestionViajes sistema = new SistemaGestionViajes();
            CuposDeseados = Convert.ToInt32(textBox1.Text);
            if (CuposDeseados <= sistema.CalcularCuposDisponibles(viaje.IDViaje))
            {
                // 2. Crea y muestra el formulario de pago.
                Pagar = new Pagar(viaje, usuarioLogueado, CuposDeseados);
                Pagar.ShowDialog();                
                if (Pagar.DialogResult == DialogResult.OK)
                {                 
                    sistema.RealizarPagoYReserva(usuarioLogueado.DNI, viaje.IDViaje, CuposDeseados);

                    MessageBox.Show("Reserva realizada con éxito.");
                    this.DialogResult = DialogResult.OK; 
                    this.Close();
                }
                else
                {
                  
                    MessageBox.Show("Reserva cancelada.");
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            }
            else
            {
                // Si no hay cupos suficientes, se muestra este mensaje sin abrir el formulario de pago.
                MessageBox.Show($"No hay capacidad para {CuposDeseados} pasajeros más en este viaje.");
                this.DialogResult = DialogResult.Cancel; // Considera esto como una cancelación también
                this.Close(); // Cierra el formulario
            }
        }
    }
}
