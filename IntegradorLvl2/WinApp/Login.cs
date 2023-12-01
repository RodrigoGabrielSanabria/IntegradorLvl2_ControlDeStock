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
using System.Security.Cryptography;

namespace WinApp
{
    public partial class LogIn : Form
    {
        public class Encrypt
        {
        public static string GetSHA256(string str)
         {
          SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
             byte[] stream = null;
          StringBuilder sb = new StringBuilder();
          stream = sha256.ComputeHash(encoding.GetBytes(str));
          for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
          return sb.ToString();
         }

        }
      
        public LogIn()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtContraseña_KeyPress (object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;//elimina el sonido
                btnIngresar_Click(sender, e);//llama al evento click del boton
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;

            string contrasena = txtContraseña.Text;/// Encrypt.GetSHA256(txtContraseña.Text);

            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                if (accesoDatos.VerificarCredenciales(usuario, contrasena))
                {
                    //MessageBox.Show("Inicio de sesión exitoso", "¡Bienvenido!");

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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
