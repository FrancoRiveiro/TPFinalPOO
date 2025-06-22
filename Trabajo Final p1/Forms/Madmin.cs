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
    public partial class Madmin : Form
    {
        private Administrador adminOriginal; // Cliente original para comparar cambios

        private GestorUsuario<Administrador> gestorAdminInstance;
        public Madmin(Administrador admin, GestorUsuario<Administrador> gestor)
        {
            InitializeComponent(); // importante que esté

            adminOriginal = admin;
            this.gestorAdminInstance = gestor;


            textNombre.Text = admin.Nombre;
            textApellido.Text = admin.Apellido;
            textContra.Text = admin.Contraseña;
            textEmail.Text = admin.Email;
            textCelular.Text = admin.Telefono.ToString();
            textDNI.Text = admin.DNI.ToString();

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

                gestorAdminInstance.Modificar(adminOriginal, nom, ape, contra, Email, cel, dni);


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
