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
        GestionTransporteDao gestorTransporte = new GestionTransporteDao();
        SistemaGestionViajes sistemaViajes = new SistemaGestionViajes();
        BindingList<MedioDeTransporte> transportes = new BindingList<MedioDeTransporte>();
        BindingList<Empresa> empresas = new BindingList<Empresa>();
        BindingList<Viaje> viajes = new BindingList<Viaje>();
        public Usuario usuario;
        


        public Catalogo(Usuario _usuarioLogueado)
        {
            InitializeComponent();
            empresas = gestorEmpresas.CargarLista();
            transportes = gestorTransporte.CargarLista();
            viajes = gestorViajes.CargarLista(empresas,transportes);
            Usuario usuario = _usuarioLogueado;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            CargarViajesDisponibles();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona un viaje para reservar.", "Sin Selección", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Viaje viajeSeleccionado = dataGridView1.SelectedRows[0].DataBoundItem as Viaje;
            ConfirmacionReserva confirmacion = new ConfirmacionReserva(viajeSeleccionado, usuario);

           
            
        }

        public void CargarViajesDisponibles()
        {
            try
            {
                //Lista de viajes con cupos disponibles
              
                BindingList<Viaje> viajesConCupos = new BindingList<Viaje>(viajes.Where(v =>v.Transporte.Cupos > 
                sistemaViajes.CalcularCuposDisponibles(v.IDViaje)).ToList());
                dataGridView1.DataSource = viajesConCupos;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los viajes: {ex.Message}", "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
