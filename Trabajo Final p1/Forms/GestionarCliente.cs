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
    public partial class GestionarCliente: Form
    {
        public GestorCliente gestor = new GestorCliente();
       
        
       

        public GestionarCliente()
        {
            InitializeComponent(); 
           dataGridView1.DataSource = gestor.clientes; // Asignar la lista de clientes al DataGridView
        }

        private void GestionarCliente_Load(object sender, EventArgs e)
        {
            // pongo el estado del formulario en maximizado desde el load porque si no se ajusta mal desde la propiedades

            this.WindowState = FormWindowState.Maximized;


            //esto quedo inutilizado porque ahora se carga la lista de clientes desde el gestor
            // this.ActualizarGrilla();
            // gestor.CargarLista();


        }


        public void ActualizarGrilla() 
        {
            dataGridView1.Refresh();
 
            /*Cargar los datos del archivo de texto en la grilla
            try
            {
                FileStream fs = new FileStream("Clientes.csv", FileMode.OpenOrCreate, FileAccess.Read);
                using (StreamReader sr = new StreamReader(fs))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] datos = line.Split(';');
                        if (datos.Length == 5)
                        {
                            Cliente cliente = new Cliente(datos[0], datos[1], datos[2], Convert.ToInt32(datos[3]), Convert.ToInt32(datos[4]));
                            clientes.Add(cliente);
                        }
                    }
                    dataGridView1.DataSource = clientes;    
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores al cargar los dato
               MessageBox.Show($"Error al cargar los datos: {ex.Message}");
            }  
            */
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

         
               //
               //this.ActualizarGrilla();
                
               
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
                Mcliente mc = new Mcliente();
                Cliente selec = (Cliente)dataGridView1.CurrentRow.DataBoundItem;

               /* if (selec == null)
                {
                    MessageBox.Show("Debe seleccionar un cliente para modificar.", "Selección Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }*/
              

                 


             

            }
            catch { }  
            
        }


        //boton para actualizar lista
        private void button3_Click(object sender, EventArgs e)
        {
            gestor.CargarLista();
            this.ActualizarGrilla();

        }
    }
}
