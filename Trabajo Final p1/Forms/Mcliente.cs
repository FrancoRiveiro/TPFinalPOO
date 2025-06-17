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
using Trabajo_Final_p1.Interfaces;

namespace Trabajo_Final_p1.Forms
{
    public partial class Mcliente : Form
    {

        private Cliente clienteOriginal; // Cliente original para comparar cambios
        private GestorCliente gestorClienteInstance;
        public Mcliente(Cliente cliente, GestorCliente  gestor)
        {
            InitializeComponent(); // importante que esté

            clienteOriginal = cliente;
            this.gestorClienteInstance = gestor;


            textNombre.Text = cliente.Nombre;
            textApellido.Text = cliente.Apellido;
            textContra.Text = cliente.Contraseña;
            textEmail.Text = cliente.Email;
            textCelular.Text = cliente.Telefono.ToString();
            textDNI.Text = cliente.DNI.ToString();

            // si no querés que se modifique el DNI
            textDNI.Enabled = false;
            //this.gestorClienteInstance = gestorClienteInstance;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {


            try
            {
                // validaciones opcionales...

                string nom = textNombre.Text;
                string ape = textApellido.Text;
                string contra = textContra.Text;
                string Email = textEmail.Text;
                int cel = int.Parse(textCelular.Text);
                int dni = int.Parse(textDNI.Text); // si está deshabilitado, sigue siendo válido

               // GestorCliente gestor = new GestorCliente();
               
                gestorClienteInstance.Modificar(clienteOriginal, nom, ape, contra, Email, cel, dni);
              

                MessageBox.Show("Cliente modificado correctamente.");
                this.Close(); // cierra el formulario
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar: " + ex.Message);
            }
    
        }
    }
}
