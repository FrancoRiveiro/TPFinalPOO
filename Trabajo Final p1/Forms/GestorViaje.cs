using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabajo_Final_p1.Clases;
using Trabajo_Final_p1.Implementacion;
using Trabajo_Final_p1.Interfaces;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Trabajo_Final_p1.Forms
{
    public partial class GestorViaje : Form
    {
        private GestionEmpresaDao gestionE;
        private GestionTransporteDao gestionT;
        private GestionViajesDao GestorV;
        BindingList<Viaje> viajes = new BindingList<Viaje>();
        BindingList<MedioDeTransporte> transportes = new BindingList<MedioDeTransporte>();
        BindingList<Empresa> empresas = new BindingList<Empresa>();
        private bool alta = false;
        Viaje miViaje;
        public GestorViaje(GestionViajesDao gestionV,bool alta = true, Viaje viajeSelec = null)
        {
            InitializeComponent();
            this.alta = alta;
            this.Text = alta ? "Alta Viaje" : "Modificar Modificar";
            this.GestorV = gestionV;
            miViaje = viajeSelec;

            if(miViaje != null)
            {
                textBox2.Text = miViaje.Destino;
                dateTimePicker1.Value = miViaje.FechaSalida;
                dateTimePicker2.Value = miViaje.FechaRetorno;
                comboBox1.IsAccessible = false;
                comboBox2.IsAccessible = false;
                textBox1.Text = miViaje.KM.ToString();
                

               
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void GestorViaje_Load(object sender, EventArgs e)
        {
            gestionE = new GestionEmpresaDao();
            gestionT = new GestionTransporteDao();
           
            
            CargarComboBox();
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int nuevoViajeID = GestorV.viajes.Count > 0 ? GestorV.viajes.Max(v => v.IDViaje) + 1 : 1;
            Empresa empresa = comboBox1.SelectedItem as Empresa;
            MedioDeTransporte transporte = comboBox2.SelectedItem as MedioDeTransporte;
            Viaje viaje = new Viaje(nuevoViajeID,
                textBox2.Text,
                dateTimePicker1.Value,
                dateTimePicker2.Value,
                empresa,
                transporte,
                Convert.ToInt32(textBox1.Text));
            GestorV.Agregar(viaje);
            MessageBox.Show($"Viaje con Destino:'{viaje.Destino}' agregado correctamente con ID: {nuevoViajeID}.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

           
            this.Close();
        }
        private void CargarComboBox()
        {
            try
            {
                BindingList<Empresa> listaEmpresas = gestionE.CargarLista();
                comboBox1.DataSource = listaEmpresas;
                comboBox1.DisplayMember = "Nombre"; 
                comboBox1.ValueMember = null; 
                                                      
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar empresas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try 
            {
                BindingList<MedioDeTransporte> listaTransportes = gestionT.CargarLista();
                comboBox2.DataSource = listaTransportes;
                comboBox2.DisplayMember = "Nombre";
                comboBox2.ValueMember = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar transportes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
}
