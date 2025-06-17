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
    public partial class GestionEmpresa : Form
    {
        GestionEmpresaDao gestor = new GestionEmpresaDao();
        public GestionEmpresa()
        {
            InitializeComponent();
            dgvEmpresasInv.DataSource = gestor.CargarLista(); // Asignar la lista de empresas al DataGridView
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {


            GestorEmpresa gestoremp = new GestorEmpresa(gestor);
            if (gestoremp.ShowDialog() == DialogResult.OK)
            {

                
                actualizarGrilla();

                MessageBox.Show("Empresa agregado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                MessageBox.Show($"Se cancelo Operacion");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            if (dgvEmpresasInv.SelectedRows.Count == 1)
            {

                Empresa emp = dgvEmpresasInv.SelectedRows[0].DataBoundItem as Empresa;

                GestorEmpresa gestorEmp = new GestorEmpresa(gestor,false, emp);

                if(gestorEmp.ShowDialog() == DialogResult.OK)    
                {
                   
                    actualizarGrilla();

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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {

                Empresa selec = (Empresa)dgvEmpresasInv.CurrentRow.DataBoundItem;
                if (selec == null)
                {
                    MessageBox.Show("Debe seleccionar una Empresa para eliminar.", "Selección Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DialogResult confirmResult = MessageBox.Show(
          $"¿Está seguro de que desea eliminar a {selec.Nombre} (ID: {selec.IDEmpresa})?",
          "Confirmar Eliminación",
          MessageBoxButtons.YesNo,
          MessageBoxIcon.Question);


                if (confirmResult == DialogResult.Yes)
                {
                    gestor.Eliminar(selec.IDEmpresa);
                    this.actualizarGrilla();
                }


            }
            catch (InvalidCastException ex)
            {
                // Se lanza si CurrentRow.DataBoundItem no se puede convertir a Cliente
                MessageBox.Show($"Error al obtener los datos de la fila: {ex.Message}\nVerifique que el DataGridView esté bindeado correctamente.", "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void actualizarGrilla()
        {
            dgvEmpresasInv.DataSource = null; // Limpiar la fuente de datos actual
            dgvEmpresasInv.DataSource = gestor.CargarLista();
        }

        private void GestionEmpresa_Load(object sender, EventArgs e)
        {

        }
    }
}
