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
using Trabajo_Final_p1.Forms;
using Trabajo_Final_p1.Seguridad;

namespace Trabajo_Final_p1
{
    public partial class FormRegistro: Form
    {

        public Form registrar;


       // private GestorCliente gestor = new GestorCliente();


        private GestorUsuario<Cliente> gestor = new GestorUsuario<Cliente>();
       
        
        public FormRegistro()
        {
            InitializeComponent();

        }s

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
                    string ContraseñaEncriptada = ContraseñaHasher.GenerarHash(Contraseña); // Encripta la contraseña antes de guardarla

                        Cliente cliente = new Cliente(Nombre, Apellido,ContraseñaEncriptada, Email, Telefono, DNI)
                    { };

                    gestor.Agregar(cliente);

                 

                    this.DialogResult = DialogResult.OK; // Indica que el registro fue exitoso
                    MessageBox.Show("Cliente registrado exitosamente");


                /////// // Actualiza la grilla de clientes en el formulario de gestión
                    
                    
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

       
    }
}
