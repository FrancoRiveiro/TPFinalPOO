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

namespace Trabajo_Final_p1
{
    public partial class Login : Form
    {
        public Form Form1;

        public FormRegistro registrar;
        
 
        public Login()
        {
            InitializeComponent();
        }

        List<Cliente> Listcliente = new List<Cliente>();

        private void salir  (object sender, EventArgs e)
        {
            Form1.Enabled = true;
            this.Hide();
            

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {



            string Contraseña = this.textContra.Text;
            string Email =this.textEmail.Text;
       
            MessageBox.Show($"{Email} + {Contraseña}");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(registrar == null)
            {
                registrar = new FormRegistro();
                //registrar.Form = this;
                registrar.Show();
                registrar.FormClosed += new FormClosedEventHandler(cerrarRegistrarForms);
                this.Close();
            }
         
        }
        public void cerrarRegistrarForms(object sender, FormClosedEventArgs e)
        {
            registrar = null;
           
        }
    }
}
