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

        private GestorCliente gestor = new GestorCliente();


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
                    string Contraseña = this.textBox6.Text;
                
                    Cliente cliente = new Cliente(Nombre, Apellido,Contraseña, Email, Telefono, DNI)
                    { };

                    gestor.Agregar(cliente);

                 

                    this.DialogResult = DialogResult.OK; // Indica que el registro fue exitoso
                    MessageBox.Show("Cliente registrado exitosamente");
                    this.Close(); // Cierra el formulario después de registrar al cliente


            }//Atrapa un error si hay un campo nulo
            catch (ArgumentNullException)
                {
                    MessageBox.Show("Debe completar todos los campos");
                }
            
            

        }



        // Cierra el Form Actual
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
