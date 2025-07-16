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
        private SistemaGestionViajes sistemaGV;

        
        public GestionViajes(GestionViajesDao gestorV, GestionEmpresaDao gestorE, GestionTransporteDao gestorT)
        {
          
            InitializeComponent();
            GestorV = gestorV;
            GestorT = gestorT;
            GestorE = gestorE;
            sistemaGV = new SistemaGestionViajes();
            BindingList<Empresa> empresas = gestorE.CargarLista();
            BindingList<MedioDeTransporte> transportes = gestorT.CargarLista();
            BindingList<Viaje> listaViajesOriginal = GestorV.CargarLista(empresas, transportes);

            var viajesParaGrid = listaViajesOriginal.Select(viaje => new
            {
                ID = viaje.IDViaje,
                Destino = viaje.Destino,
                FechaSalida = viaje.FechaSalida.ToShortDateString(), // Formatear la fecha
                FechaRetorno = viaje.FechaRetorno.ToShortDateString(), // Formatear la fecha
                CuposTotales = viaje.CuposTotales,
                CuposDisponibles = sistemaGV.CalcularCuposDisponibles(viaje.IDViaje), // Calcular los cupos disponibles
                NombreEmpresa = viaje.Empresa?.Nombre, // Accede al nombre de la empresa
                TipoTransporte = viaje.Transporte?.Nombre // Accede al tipo de transporte
            }).ToList(); // Convertir el resultado a una lista

            // Asignar esta nueva lista al DataGridView
            dgvViajes.DataSource = viajesParaGrid;
         
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
             
                if (dgvViajes.CurrentRow == null)
                {
                    MessageBox.Show("Debe seleccionar un Viaje para eliminar.", "Selección Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idViajeAEliminar = Convert.ToInt32(dgvViajes.CurrentRow.Cells[0].Value);

                //Pedir confirmación al usuario
                DialogResult confirmResult = MessageBox.Show(
                    $"¿Está seguro de que desea eliminar el viaje (ID: {idViajeAEliminar}?",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                // Si el usuario confirma, proceder con la eliminación
                if (confirmResult == DialogResult.Yes)
                {
                    GestorV.Eliminar(idViajeAEliminar);

                    // Refrescar el DataGridView
                    // Las listas 'empresas' y 'transportes' se necesitan para que 'actualizarGrilla'
                    // pueda cargar y reproyectar los datos correctamente.
                    var empresas = GestorE.CargarLista();
                    var transportes = GestorT.CargarLista();
                    this.actualizarGrilla(empresas, transportes);

                    MessageBox.Show("Viaje eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Error: El ID de la celda seleccionada no es un número válido.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al intentar eliminar el viaje: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        void actualizarGrilla(BindingList<Empresa>empresas,BindingList<MedioDeTransporte> transportes   )
        {
            dgvViajes.DataSource = null; // Limpiar la fuente de datos actual
            BindingList<Viaje> listaViajesOriginal = GestorV.CargarLista(empresas, transportes);
            var viajesParaGrid = listaViajesOriginal.Select(viaje => new
            {
                ID = viaje.IDViaje,
                Destino = viaje.Destino,
                FechaSalida = viaje.FechaSalida.ToShortDateString(), // Formatear la fecha
                FechaRetorno = viaje.FechaRetorno.ToShortDateString(), // Formatear la fecha
                CuposTotales = viaje.CuposTotales,
                CuposDisponibles = sistemaGV.CalcularCuposDisponibles(viaje.IDViaje), // Calcular los cupos disponibles
                NombreEmpresa = viaje.Empresa?.Nombre, // Accede al nombre de la empresa
                TipoTransporte = viaje.Transporte?.Nombre // Accede al tipo de transporte
            }).ToList(); // Convertir el resultado a una lista

            // Asignar esta nueva lista al DataGridView
            dgvViajes.DataSource = viajesParaGrid;


        }

        private void GestionViajes_Load(object sender, EventArgs e)
        {
           
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            gestorViajeForm = new GestorViaje(GestorV);
          
            gestorViajeForm.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvViajes.SelectedRows.Count == 1)
            {
                int idViaje = Convert.ToInt32(dgvViajes.CurrentRow.Cells[0].Value);
                Viaje viajeSeleccionado = GestorV.Obtener(idViaje);
                BindingList<Empresa> empresas = GestorE.CargarLista();
                BindingList<MedioDeTransporte> transportes = GestorT.CargarLista();

                GestorViaje gestorV = new GestorViaje(GestorV, false, viajeSeleccionado);


                if (gestorV.ShowDialog() == DialogResult.OK)
                {

                    actualizarGrilla(empresas, transportes);

                    MessageBox.Show("Libro modificado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    MessageBox.Show($"Se cancelo Operacion");
                }

            }

            else
            {
                MessageBox.Show("Seleccione un libro para modificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
