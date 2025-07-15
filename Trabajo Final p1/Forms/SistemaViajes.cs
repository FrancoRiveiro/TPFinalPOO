using System;
using System.Windows.Forms;
using Trabajo_Final_p1.Clases;
using Trabajo_Final_p1.Forms;
using Trabajo_Final_p1.Implementacion;

namespace Trabajo_Final_p1
{
    public partial class SistemaViajes : Form
    {
        //forms
        private Login login;
        private Catalogo catalogo;
        private FormRegistro registrar;
        private GestionEmpresa gestionEmpresa;
        private GestionUsuario gestionarCliente;
        private Usuario usuarioActual;
        private GestorViaje gestorViaje;
        private GestionViajes gestionViajes;
        //DAOS
        private GestionViajesDao gestorV;
        private GestionTransporteDao gestorT;
        private GestionReservaDao gestorR;
        private GestionEmpresaDao gestorE;
        private GestorUsuario<Cliente> gestorC;
        

        public SistemaViajes()
        {
            InitializeComponent();
            gestorV = new GestionViajesDao();
            gestorE = new GestionEmpresaDao();
            gestorT = new GestionTransporteDao();           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UsuariosToolStripMenuItem.Visible = true;
            EmpresaToolStripMenuItem.Visible = true;
        
        }


        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            catalogo = new Catalogo(usuarioActual);
            catalogo.FormClosed += new FormClosedEventHandler(cerrarForms);
            catalogo.MdiParent = this;

            catalogo.Show();

        }

        private void holaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void LoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            login = new Login();
            login.Form1 = this;
          


            if (login.ShowDialog() == DialogResult.OK)
            {
               usuarioActual = login.usuarioLog;

                if (usuarioActual != null)
                {

                    if (usuarioActual.Rol)

                    {
                        UsuariosToolStripMenuItem.Visible = true;
                        EmpresaToolStripMenuItem.Visible = true;

                    }

                    else
                    {
                        UsuariosToolStripMenuItem.Visible = false;
                        EmpresaToolStripMenuItem.Visible = false;
                    }

                    MessageBox.Show($"Bienvenido {usuarioActual.Nombre}");

                }
           
            }
            login = null;

            /*
            if (login == null)
            {
                login = new Login();
              
                login.FormClosed += new FormClosedEventHandler(cerrarForms);
                login.Form1 = this;

                login.Show();
            }

        else
            {
                login.Activate(); 
            }*/
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

        private void viajesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gestionViajes = new GestionViajes(gestorV, gestorE, gestorT);
            gestionViajes.MdiParent = this;
            gestionViajes.Show();
            
        }
    }
}
