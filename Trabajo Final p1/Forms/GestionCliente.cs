using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trabajo_Final_p1.Clases;

namespace Trabajo_Final_p1.Forms
{
    public partial class GestionCliente: Form
    {
        public GestorCliente gestor = new GestorCliente();
       
        
       

        public GestionCliente()
        {
            InitializeComponent(); 
           dataGridView1.DataSource = gestor.clientes; // Asignar la lista de clientes al DataGridView
        }

        private void GestionarCliente_Load(object sender, EventArgs e)
        {
            // pongo el estado del formulario en maximizado desde el load porque si no se ajusta mal desde la propiedades

            this.WindowState = FormWindowState.Maximized;
        }


        public void ActualizarGrilla() 
        {
            //dataGridView1.Refresh();
            dataGridView1.DataSource = null; // Limpiar la fuente de datos actual
            dataGridView1.DataSource = gestor.CargarLista(); // asumimos que 'gestor' es tu GestorCliente
        }

        //boton de eliminar deberia llamarse btnEliminar, ojo 
        private void button2_Click(object sender, EventArgs e)
        {
            try {

                Cliente selec = (Cliente)dataGridView1.CurrentRow.DataBoundItem;
                if (selec == null)
                {
                    MessageBox.Show("Debe seleccionar un cliente para eliminar.", "Selección Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DialogResult confirmResult = MessageBox.Show(
          $"¿Está seguro de que desea eliminar a {selec.Nombre} {selec.Apellido} (DNI: {selec.DNI})?",
          "Confirmar Eliminación",
          MessageBoxButtons.YesNo,
          MessageBoxIcon.Question);


                if (confirmResult == DialogResult.Yes)
                {
                    gestor.Eliminar(selec.DNI);
                    this.ActualizarGrilla();
                }

      
            }
            catch (InvalidCastException ex)
            {
                // Se lanza si CurrentRow.DataBoundItem no se puede convertir a Cliente
                MessageBox.Show($"Error al obtener los datos de la fila: {ex.Message}\nVerifique que el DataGridView esté bindeado correctamente.", "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //boton para modificar 
        private void button1_Click(object sender, EventArgs e)
        {

            
            try 
            {
                
                Cliente selec = (Cliente)dataGridView1.CurrentRow.DataBoundItem;
    
                 if (selec == null)
                 {
                     MessageBox.Show("Debe seleccionar un cliente para modificar.", "Selección Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Mcliente mc = new Mcliente(selec, this.gestor);
                mc.ShowDialog();
                ActualizarGrilla();
            }
            catch { }
           
        }


        //boton para actualizar lista
        private void button3_Click(object sender, EventArgs e)
        {
           // gestor.CargarLista();
            this.ActualizarGrilla();

        }
    }
}
