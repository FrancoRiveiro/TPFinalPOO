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
using Trabajo_Final_p1.Forms;
using Trabajo_Final_p1.Implementacion;

namespace Trabajo_Final_p1
{
    public partial class Catalogo : Form
    {
        GestionViajesDao gestorViajes = new GestionViajesDao();
        GestionEmpresaDao gestorEmpresas = new GestionEmpresaDao();
        BindingList<Empresa> empresas = new BindingList<Empresa>();
        BindingList<Viaje> viajes = new BindingList<Viaje>();


        public Catalogo()
        {
            InitializeComponent();
            empresas = gestorEmpresas.CargarLista();
            viajes = gestorViajes.CargarLista(empresas);
            dataGridView1.DataSource = viajes;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
