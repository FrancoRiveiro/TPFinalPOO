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

        private void button1_Click(object sender, EventArgs e)
        {
            bool pagoFueExitoso = true; // <--- **Esto debe ser el resultado real de tu lógica de pago**
                                        

            if (pagoFueExitoso)
            {
                // Si el pago es exitoso, establece el resultado del diálogo a OK
                this.DialogResult = DialogResult.OK;
                this.Close(); // Cierra el formulario Pagar
            }
            else
            {
                // Si el pago falló, muestra un mensaje de error y no cierres el formulario
                // Opcionalmente, podrías cerrar con DialogResult.Cancel si un fallo de pago es una cancelación
                MessageBox.Show("Hubo un problema al procesar el pago. Por favor, inténtelo de nuevo.", "Error de Pago", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // Establece el resultado del diálogo a Cancel
            this.Close();
        }
    }
}
