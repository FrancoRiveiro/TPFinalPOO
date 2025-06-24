using System;
using System.Windows.Forms;
using Trabajo_Final_p1.Clases;

namespace Trabajo_Final_p1.Forms
{
    public partial class GestionUsuario : Form
    {
        public GestorUsuario<Cliente> gestor = new GestorUsuario<Cliente>();
        public GestorUsuario<Administrador> gestorAdmin = new GestorUsuario<Administrador>();




        public GestionUsuario()
        {
            InitializeComponent();

            this.Load += GestionarCliente_Load;
        }

        private void GestionarCliente_Load(object sender, EventArgs e)
        {
            // pongo el estado del formulario en maximizado desde el load porque si no se ajusta mal desde la propiedades
            this.WindowState = FormWindowState.Maximized;

            if (comboboxTipo.Items.Count == 0)
            {
                comboboxTipo.Items.Add("Clientes");
                comboboxTipo.Items.Add("Administradores");
            }
            comboboxTipo.SelectedIndex = 0; // Por defecto selecciona "Clientes"

            ActualizarGrilla(); // Cargar la lista de clientes al iniciar el formulario
        }


        public void ActualizarGrilla()
        {
            if (comboboxTipo?.SelectedItem == null || dataGridView1 == null)
                return;

            dataGridView1.DataSource = null;

            if (comboboxTipo.SelectedItem.ToString() == "Clientes")
            {
                dataGridView1.DataSource = gestor.CargarLista();
            }
            else if (comboboxTipo.SelectedItem.ToString() == "Administradores")
            {
                dataGridView1.DataSource = gestorAdmin.CargarLista();
            }
        }

        //boton de eliminar deberia llamarse btnEliminar, ojo 
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboboxTipo.SelectedItem.ToString() == "Clientes")
                {

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
                        // this.ActualizarGrilla();
                    }
                }
                else if (comboboxTipo.SelectedItem.ToString() == "Administradores")
                {
                    Administrador selec = (Administrador)dataGridView1.CurrentRow.DataBoundItem;
                    if (selec == null)
                    {
                        MessageBox.Show("Debe seleccionar un administrador para eliminar.", "Selección Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    DialogResult confirmResult = MessageBox.Show("¿Está seguro de que desea eliminar al administrador " + selec.Nombre + " " + selec.Apellido + " (DNI: " + selec.DNI + ")?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirmResult == DialogResult.Yes)
                    {
                        // Elimina el administrador seleccionado
                        gestorAdmin.Eliminar(selec.DNI);
                    }
                }
                ActualizarGrilla();
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
                if (comboboxTipo.SelectedItem.ToString() == "Clientes")
                {
                    // Obtiene el cliente seleccionado
                    Cliente selec = (Cliente)dataGridView1.CurrentRow.DataBoundItem;
                    if (selec == null)
                    {
                        MessageBox.Show("Debe seleccionar un cliente para modificar.", "Selección Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    Mcliente mc = new Mcliente(selec, this.gestor);
                    mc.ShowDialog();


                }
                else if (comboboxTipo.SelectedItem.ToString() == "Administradores")
                {
                    // Obtiene el administrador seleccionado
                    Administrador selec = (Administrador)dataGridView1.CurrentRow.DataBoundItem;
                    if (selec == null)
                    {
                        MessageBox.Show("Debe seleccionar un administrador para modificar.", "Selección Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    Madmin ma = new Madmin(selec, this.gestorAdmin);
                    ma.ShowDialog();
                }
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

        private void GestionCliente_Enter(object sender, EventArgs e)
        {
            ActualizarGrilla(); // Actualizar la grilla al entrar al formulario
        }

    }
}
