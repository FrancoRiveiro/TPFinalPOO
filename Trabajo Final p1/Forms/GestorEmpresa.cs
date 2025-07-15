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
using static System.Net.Mime.MediaTypeNames;

namespace Trabajo_Final_p1.Forms
{
    public partial class GestorEmpresa : Form
    {
        private GestionEmpresaDao _gestorDao;

        private bool alta = false;
        
        public Empresa empresa { get; set; }
        
        
        public GestorEmpresa(GestionEmpresaDao gestorDParam, bool alta = true, Empresa AgenteEmp = null)
        {
            InitializeComponent();
            this.alta = alta;
            this.Text = alta ? "Alta Empresa" : "Modificar Modificar";
            empresa = AgenteEmp;
            this._gestorDao = gestorDParam;

            if (AgenteEmp != null)
            {
                textId.Text = AgenteEmp.IDEmpresa.ToString();
                textNom.Text = AgenteEmp.Nombre;
                textCodPos.Text = AgenteEmp.CodPostal.ToString();
                textDire.Text = AgenteEmp.Direccion;

                textId.Enabled = false; // Deshabilitar el campo ID si es una modificación
            }
        }
        private void bntAceptar_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                
                int idEmpresa = Convert.ToInt32(textId.Text);
                string nombreEmpresa = textNom.Text;
                int codPostal = Convert.ToInt32(textCodPos.Text);
                string direccionEmpresa = textDire.Text;

                if (alta)
                {
                    empresa = new Empresa(Convert.ToInt32(textId.Text), textNom.Text, Convert.ToInt32(textCodPos.Text), textDire.Text);
                    _gestorDao.Agregar(this.empresa);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    
                    _gestorDao.Modificar(this.empresa, idEmpresa,nombreEmpresa,codPostal,direccionEmpresa);  

                    MessageBox.Show("Empresa modificada correctamente.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch 
            {
               // MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                // para indicar que la operación no se completó.
            }
        }

        private void GestorEmpresa_Load(object sender, EventArgs e)
        {

        }

    
    }
}
