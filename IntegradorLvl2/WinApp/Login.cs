using Conexion_DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinApp
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contrasena = txtContraseña.Text;

            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                if (accesoDatos.VerificarCredenciales(usuario, contrasena))
                {
                    MessageBox.Show("Inicio de sesión exitoso", "¡Bienvenido!");

                    // Cierra la ventana actual (LogIn)

                    this.Hide();

                    // Abre el formulario FormArticulos

                    FormArticulos formArticulos = new FormArticulos();

                    formArticulos.Show();
                }
                else
                {
                    MessageBox.Show("Error de inicio de sesión", "Credenciales incorrectas");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error de inicio de sesión");
            }
            finally
            {
                accesoDatos.CerrarConexion();
            }
        }
    }
}
