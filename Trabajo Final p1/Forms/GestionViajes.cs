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
using Trabajo_Final_p1.Interfaces;

namespace Trabajo_Final_p1.Forms
{
    public partial class GestionViajes : Form
    {
        private GestionViajesDao GestorV;
        private GestionEmpresaDao GestorE;
        private GestionTransporteDao GestorT;
        private GestorViaje gestorViajeForm;

        
        public GestionViajes(GestionViajesDao gestorV, GestionEmpresaDao gestorE, GestionTransporteDao gestorT)
        {
          
            InitializeComponent();
            GestorV = gestorV;
            GestorT = gestorT;
            GestorE = gestorE;
            /*
            dgvViajes.AutoGenerateColumns = false; // Importante: deshabilitar auto-generación

            // Limpia las columnas existentes si las hubiera para evitar duplicados
            dgvViajes.Columns.Clear();

            
            dgvViajes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ID Viaje", DataPropertyName = "IDViaje", Name = "colIDViaje" });
            dgvViajes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Destino", DataPropertyName = "Destino", Name = "colDestino" });
            dgvViajes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Fecha Salida", DataPropertyName = "FechaSalida", Name = "colFechaSalida" });
            dgvViajes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Fecha Retorno", DataPropertyName = "FechaRetorno", Name = "colFechaRetorno" });
            dgvViajes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Cupos Disponibles", DataPropertyName = "CuposDisponibles", Name = "colCuposDisponibles" });

            // *** Columnas para Empresa y MedioDeTransporte usando las nuevas propiedades ***
            dgvViajes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Empresa", DataPropertyName = "NombreEmpresa", Name = "colNombreEmpresa" });
            dgvViajes.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tipo de Transporte", DataPropertyName = "NombreTransporte", Name = "colTipoMedioTransporte" });

            */
            GestorV = gestorV;
            GestorT = gestorT;
            GestorE = gestorE;
            BindingList<Empresa> empresas = gestorE.CargarLista();
            BindingList<MedioDeTransporte> transportes = gestorT.CargarLista();
            dgvViajes.DataSource = GestorV.CargarLista(empresas, transportes);



        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {

                Empresa selec = (Empresa)dgvViajes.CurrentRow.DataBoundItem;
                if (selec == null)
                {
                    MessageBox.Show("Debe seleccionar un Viaje para eliminar.", "Selección Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DialogResult confirmResult = MessageBox.Show(
          $"¿Está seguro de que desea eliminar a {selec.Nombre} (ID: {selec.IDEmpresa})?",
          "Confirmar Eliminación",
          MessageBoxButtons.YesNo,
          MessageBoxIcon.Question);


                if (confirmResult == DialogResult.Yes)
                {
                    var empresas = GestorE.CargarLista();
                    var transportes = GestorT.CargarLista();
                    GestorV.Eliminar(selec.IDEmpresa);
                    this.actualizarGrilla(empresas, transportes);
                }


            }
            catch (InvalidCastException ex)
            {
                // Se lanza si CurrentRow.DataBoundItem no se puede convertir a Cliente
                MessageBox.Show($"Error al obtener los datos de la fila: {ex.Message}\nVerifique que el DataGridView esté bindeado correctamente.", "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void actualizarGrilla(BindingList<Empresa>empresas,BindingList<MedioDeTransporte> transportes   )
        {
            dgvViajes.DataSource = null; // Limpiar la fuente de datos actual
            dgvViajes.DataSource = GestorV.CargarLista(empresas, transportes);
        }

        private void GestionViajes_Load(object sender, EventArgs e)
        {
           
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            gestorViajeForm = new GestorViaje(GestorV);
          
            gestorViajeForm.Show();
        }
    }
}
