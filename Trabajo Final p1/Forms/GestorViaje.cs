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
using Trabajo_Final_p1.Implementacion;


namespace Trabajo_Final_p1.Forms
{
    public partial class GestorViaje : Form
    {
        GestionEmpresaDao gestionEmpresa = new GestionEmpresaDao();
        BindingList<Empresa> empresas = new BindingList<Empresa>();
        public GestorViaje()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void GestorViaje_Load(object sender, EventArgs e)
        {
            empresas = gestionEmpresa.CargarLista();
        }
    }
}
