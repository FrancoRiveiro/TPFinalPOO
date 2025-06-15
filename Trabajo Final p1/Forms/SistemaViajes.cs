using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabajo_Final_p1.Forms;

namespace Trabajo_Final_p1
{
    public partial class SistemaViajes : Form
    {
        private Login login;
        private Catalogo catalogo;
        private FormRegistro registrar;
        private Form5 agregarEm;
        private GestionarCliente gestionarCliente;

        public SistemaViajes()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

           
           // CenterToScreen();





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
            if (login == null)
            {
                login = new Login();
                //login.MdiParent = this;
                login.FormClosed += new FormClosedEventHandler(cerrarForms);
                login.Form1 = this;

                login.Show();
            }

        else
            {
                login.Activate(); 
            }
        }

          void cerrarForms(object sender, FormClosedEventArgs e) 
        {
            login=null;
            catalogo=null;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void agregarEmpresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            agregarEm = new Form5();
            agregarEm.MdiParent = this;
            agregarEm.Show();
        }

        private void gestionarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gestionarCliente = new GestionarCliente();
            gestionarCliente.MdiParent = this;
            gestionarCliente.Show();
        }
    }
}
