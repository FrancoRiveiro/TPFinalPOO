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
using Trabajo_Final_p1.Interfaces;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Trabajo_Final_p1
{
    public partial class Catalogo : Form
    {
        GestionViajesDao gestorV = new GestionViajesDao();
        GestionEmpresaDao gestorE = new GestionEmpresaDao();
        GestionTransporteDao gestorT = new GestionTransporteDao();
        SistemaGestionViajes sistemaViajes = new SistemaGestionViajes();
        BindingList<MedioDeTransporte> transportes = new BindingList<MedioDeTransporte>();
        BindingList<Empresa> empresas = new BindingList<Empresa>();
        BindingList<Viaje> viajes = new BindingList<Viaje>();      
        public Usuario usuario;
        


        public Catalogo(Usuario _usuarioLogueado)
        {
            InitializeComponent();
            empresas = gestorE.CargarLista();
            transportes = gestorT.CargarLista();
            this.usuario = _usuarioLogueado;         
                
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            CargarViajesDisponibles();
            CargarComboBox();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona un viaje para reservar.", "Sin Selección", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idViaje = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            Viaje viajeSeleccionado = gestorV.Obtener(idViaje);            
            ConfirmacionReserva confirmacion = new ConfirmacionReserva(viajeSeleccionado, usuario);
            confirmacion.Show();

           
            
        }

        public void CargarViajesDisponibles()
        {
            try
            {

                //Lista de viajes con cupos disponibles
                viajes = gestorV.CargarLista(empresas,transportes);
                BindingList<Viaje> viajesConCupos = new BindingList<Viaje>(viajes.Where(v =>v.Transporte.Cupos >=
                sistemaViajes.CalcularCuposDisponibles(v.IDViaje)).ToList());
                


                var viajesParaGrid = viajesConCupos.Select(viaje => new
                {
                    ID = viaje.IDViaje,
                    Destino = viaje.Destino,
                    FechaSalida = viaje.FechaSalida.ToShortDateString(), 
                    FechaRetorno = viaje.FechaRetorno.ToShortDateString(),
                    CuposTotales = viaje.CuposTotales,
                    CuposDisponibles = sistemaViajes.CalcularCuposDisponibles(viaje.IDViaje), // Calcular los cupos disponibles
                    NombreEmpresa = viaje.Empresa?.Nombre, 
                    TipoTransporte = viaje.Transporte?.Nombre, 
                    Costo = viaje.Costo
                }).ToList(); // Convertir el resultado a una lista

                // Asignar esta nueva lista al DataGridView
                dataGridView1.DataSource = viajesParaGrid;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los viajes: {ex.Message}", "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {



                //Lista de viajes con cupos disponibles
                viajes = gestorV.CargarLista(empresas, transportes);
                BindingList<Viaje> viajesConCupos = new BindingList<Viaje>(viajes.Where(v => v.Transporte.Cupos >=
                sistemaViajes.CalcularCuposDisponibles(v.IDViaje)).ToList());
                BindingList<Viaje> filtroTransporte = new BindingList<Viaje>(viajesConCupos.Where(v => v.Transporte.Nombre == comboBox1.Text).ToList());



                var viajesParaGrid = filtroTransporte.Select(viaje => new
                {
                    ID = viaje.IDViaje,
                    Destino = viaje.Destino,
                    FechaSalida = viaje.FechaSalida.ToShortDateString(), // Formatear la fecha
                    FechaRetorno = viaje.FechaRetorno.ToShortDateString(), // Formatear la fecha
                    CuposTotales = viaje.CuposTotales,
                    CuposDisponibles = sistemaViajes.CalcularCuposDisponibles(viaje.IDViaje), //Calcula los cupos disponibles
                    NombreEmpresa = viaje.Empresa?.Nombre, // Accede al nombre de la empresa
                    TipoTransporte = viaje.Transporte?.Nombre // Accede al tipo de transporte
                }).ToList(); // Convertir el resultado a una lista

                // Asignar esta nueva lista al DataGridView
                dataGridView1.DataSource = viajesParaGrid;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los viajes: {ex.Message}", "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {



                //Lista de viajes con cupos disponibles
                viajes = gestorV.CargarLista(empresas, transportes);
                BindingList<Viaje> viajesConCupos = new BindingList<Viaje>(viajes.Where(v => v.Transporte.Cupos >=
                sistemaViajes.CalcularCuposDisponibles(v.IDViaje)).ToList());
                BindingList<Viaje> filtroSalida = new BindingList<Viaje>(viajesConCupos.Where(v => v.FechaSalida >= dateTimePicker1.Value.AddDays(2)).ToList());



                var viajesParaGrid = filtroSalida.Select(viaje => new
                {
                    ID = viaje.IDViaje,
                    Destino = viaje.Destino,
                    FechaSalida = viaje.FechaSalida.ToShortDateString(), // Formatear la fecha
                    FechaRetorno = viaje.FechaRetorno.ToShortDateString(), // Formatear la fecha
                    CuposTotales = viaje.CuposTotales,
                    CuposDisponibles = sistemaViajes.CalcularCuposDisponibles(viaje.IDViaje), //Calcula los cupos disponibles
                    NombreEmpresa = viaje.Empresa?.Nombre, // Accede al nombre de la empresa
                    TipoTransporte = viaje.Transporte?.Nombre // Accede al tipo de transporte
                }).ToList(); // Convertir el resultado a una lista

                // Asignar esta nueva lista al DataGridView
                dataGridView1.DataSource = viajesParaGrid;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los viajes: {ex.Message}", "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {



                //Lista de viajes con cupos disponibles
                viajes = gestorV.CargarLista(empresas, transportes);
                BindingList<Viaje> viajesConCupos = new BindingList<Viaje>(viajes.Where(v => v.Transporte.Cupos >=
                sistemaViajes.CalcularCuposDisponibles(v.IDViaje)).ToList());
                BindingList<Viaje> filtroDestino = new BindingList<Viaje>(viajesConCupos.Where(v => v.Destino == textBox1.Text ).ToList());



                var viajesParaGrid = filtroDestino.Select(viaje => new
                {
                    ID = viaje.IDViaje,
                    Destino = viaje.Destino,
                    FechaSalida = viaje.FechaSalida.ToShortDateString(), // Formatear la fecha
                    FechaRetorno = viaje.FechaRetorno.ToShortDateString(), // Formatear la fecha
                    CuposDisponibles = viaje.CuposDisponibles,
                    NombreEmpresa = viaje.Empresa?.Nombre, // Accede al nombre de la empresa
                    TipoTransporte = viaje.Transporte?.Nombre // Accede al tipo de transporte
                }).ToList(); // Convertir el resultado a una lista

                // Asignar esta nueva lista al DataGridView
                dataGridView1.DataSource = viajesParaGrid;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los viajes: {ex.Message}", "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void CargarComboBox()
        {
            
            try
            {
                BindingList<MedioDeTransporte> listaTransportes = gestorT.CargarLista();
                comboBox1.DataSource = listaTransportes;
                comboBox1.DisplayMember = "Nombre";
                comboBox1.ValueMember = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar transportes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
