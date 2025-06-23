using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Trabajo_Final_p1.Clases;
using Trabajo_Final_p1.Seguridad;

namespace Trabajo_Final_p1
{
    public partial class Login : Form
    {
        public Form Form1;

        public FormRegistro registrar;
        public Usuario usuarioLog {  get; private set; }

        public Login()
        {
            InitializeComponent();
        }


        private void salir(object sender, EventArgs e)
        {
            Form1.Enabled = true;
            this.Hide();


        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            // Inicializa las variables para almacenar los datos del usuariow
            string[] datosUser = null;

            string Hash = string.Empty;
            string Email = this.textEmail.Text;
            string Contraseña = this.textContra.Text;

            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Contraseña))
            {
                MessageBox.Show("No se aceptan campos vacíos.");
                return;
            }
            else if (!Email.Contains("@") || !Email.Contains("."))
            {

                MessageBox.Show("El Email ingresado no es válido. Asegúrese de que contenga '@' y un dominio válido.");
                return;
            }


            bool encontrado = false;

            using (FileStream fs = new FileStream("Usuarios.csv", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string linea;
                    while ((linea = sr.ReadLine()) != null)
                    {
                        string[] datos = linea.Split(';');


                        if (datos.Length >= 6 && datos[3] == Email) // Verifica si el email coincide
                        {
                            datosUser = datos; // Guarda los datos del usuario
                            Hash = datos[2];
                            encontrado = true; // Marca que se encontró el email
                            break; // Sale del bucle si se encuentra el email

                        }
                       
                    }
                     if (!encontrado ) // Si no se ha encontrado el email
                    {
                        MessageBox.Show("El Email ingresado no está registrado. Por favor, regístrese primero.");
                        return; // Sale del bucle si el email no está registrado
                    }
                }
            }
            Contraseña = ContraseñaHasher.GenerarHash(Contraseña); // Encripta la contraseña ingresada

            if (Hash == Contraseña) // Compara la contraseña encriptada
            {

               bool rol = bool.Parse(datosUser[6]);
                if (rol)
                {

                    usuarioLog = new Administrador(datosUser[0], datosUser[1], datosUser[2], datosUser[3],
                    int.Parse(datosUser[4]), int.Parse(datosUser[5]));
                
                }
                else
                {
                    usuarioLog = new Cliente(datosUser[0], datosUser[1], datosUser[2], datosUser[3], int.Parse(datosUser[4]), int.Parse(datosUser[5]));
       
                }

                // Si las credenciales son correctas, crea un nuevo cliente y muestra un mensaje de éxito
                SesionManagger.IniciarSesion(usuarioLog);
                
                this.DialogResult = DialogResult.OK;
                this.Close();
                Form1.Enabled = true; // Habilita el formulario principal
                return; // Sale del bucle si las credenciales son correctas
            }
            else
            {
                MessageBox.Show("Contraseña incorrecta.");
                return;
            }

        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (registrar == null)
            {
                registrar = new FormRegistro();
               
                registrar.Show();
                registrar.FormClosed += new FormClosedEventHandler(cerrarRegistrarForms);
                this.Close();
            }

        }
        public void cerrarRegistrarForms(object sender, FormClosedEventArgs e)
        {
            registrar = null;

        }

        private void button2_Click(object sender, EventArgs e)
        {
          textContra.Text = string.Empty;
            textEmail.Text = string.Empty;
        }
    }
}
