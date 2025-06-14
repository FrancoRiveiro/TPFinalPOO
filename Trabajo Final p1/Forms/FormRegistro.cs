using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabajo_Final_p1.Clases;

namespace Trabajo_Final_p1
{
    public partial class FormRegistro: Form
    {
        public Form registrar;
        GestorCliente gestor = new GestorCliente();

        List<Cliente> Listcliente = new List<Cliente>();

        public FormRegistro()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Intenta crear el cliente con los datos de los textbox
            try {
                string Nombre = this.textBox1.Text;
                string Apellido = this.textBox2.Text;
                string Email = this.textBox3.Text;
                int Telefono = Convert.ToInt32(this.textBox4.Text);
                int DNI = Convert.ToInt32(this.textBox5.Text);
                Cliente cliente = new Cliente(Nombre, Apellido, Email, Telefono, DNI)
                { };

                gestor.Agregar(cliente);

                Listcliente.Add(cliente);
                
               
            }//Atrapa un error si hay un campo nulo
            catch (ArgumentNullException )
            {
                MessageBox.Show("Debe completar todos los campos");
            }

            

        }



        // Cierra el Form Actual
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }
    }
}
