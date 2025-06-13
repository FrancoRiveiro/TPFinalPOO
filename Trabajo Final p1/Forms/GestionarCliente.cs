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
        List<Cliente> clientes = new List<Cliente>();

        public GestionarCliente()
        {
            InitializeComponent();
        }

        private void GestionarCliente_Load(object sender, EventArgs e)
        {
            this.ActualizarGrilla();
            gestor.CargarLista();
        }


        public void ActualizarGrilla() 
        {
            // Cargar los datos del archivo de texto en la grilla
            
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
                // Manejo de errores al cargar los datos

                MessageBox.Show($"Error al cargar los datos: {ex.Message}");
            }
              

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try {

                Cliente selec = (Cliente)dataGridView1.CurrentRow.DataBoundItem;
                // El gestor elimina el cliente del CSV
                gestor.Eliminar(selec);
                // Ahora lo removemos de la lista Local
                clientes.Remove(selec);
                //Ahora se actualiza el datagrid con la nueva lectura del csv
                this.ActualizarGrilla();
                
               
            }
            catch (InvalidCastException ex)
            {
                // Se lanza si CurrentRow.DataBoundItem no se puede convertir a Cliente
                MessageBox.Show($"Error al obtener los datos de la fila: {ex.Message}\nVerifique que el DataGridView esté bindeado correctamente.", "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try 
            { 

            
            }
            catch { }  
            
        }
    }
}
