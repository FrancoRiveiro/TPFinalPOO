using System;
using System.Windows.Forms;
using Trabajo_Final_p1.Clases;
using Trabajo_Final_p1.Forms;
using Trabajo_Final_p1.Seguridad;

namespace Trabajo_Final_p1
{
    public partial class SistemaViajes : Form
    {
        private Login login;
        private Catalogo catalogo;
        private FormRegistro registrar;
        private GestionEmpresa gestionEmpresa;
        private GestionUsuario gestionarCliente;
     
        public SistemaViajes()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UsuariosToolStripMenuItem.Visible = false;
            EmpresaToolStripMenuItem.Visible = false;
        
        }


        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            catalogo = new Catalogo();
            catalogo.FormClosed += new FormClosedEventHandler(cerrarForms);
            catalogo.MdiParent = this;

            catalogo.Show();

        }

        private void holaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void LoginToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (SesionManagger.SesionActiva)
            {
                var usuario = SesionManagger.Instancia.Usuario;

                MessageBox.Show("Ya hay una sesión activa.");

                if (usuario.Rol)
                {
                    UsuariosToolStripMenuItem.Visible = true;
                    EmpresaToolStripMenuItem.Visible = true;
                }
                else
                {
                    UsuariosToolStripMenuItem.Visible = false;
                    EmpresaToolStripMenuItem.Visible = false;
                }

                MessageBox.Show($"Ya ha iniciado sesión como {usuario.Nombre}");
                return;
            }

            login = new Login();
            login.Form1 = this;



            if (login.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Inicia sesión y obtiene el usuario activo
                    var usuario = SesionManagger.Instancia.Usuario;


                    // Si es un administrador, muestra los menús correspondientes
                    if (usuario.Rol)

                        {
                            UsuariosToolStripMenuItem.Visible = true;
                            EmpresaToolStripMenuItem.Visible = true;

                        }
                    // Si es un cliente, oculta los menús de administración
                    else
                    {
                            UsuariosToolStripMenuItem.Visible = false;
                            EmpresaToolStripMenuItem.Visible = false;
                        }

                        MessageBox.Show($"Bienvenido {usuario.Nombre}");

  
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, " Error de sesio ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            login = null;
        }

        void cerrarForms(object sender, FormClosedEventArgs e)
        {
            login = null;
            catalogo = null;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }



        private void gestionarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gestionarCliente = new GestionUsuario();
            gestionarCliente.MdiParent = this;
            gestionarCliente.Show();
        }

        private void EmpresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gestionEmpresa = new GestionEmpresa();
            gestionEmpresa.MdiParent = this;
            gestionEmpresa.Show();
        }

        private void LogoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SesionManagger.CerrarSesion();
                MessageBox.Show("Sesión cerrada correctamente.");


                UsuariosToolStripMenuItem.Visible = false;
                EmpresaToolStripMenuItem.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cerrar sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
