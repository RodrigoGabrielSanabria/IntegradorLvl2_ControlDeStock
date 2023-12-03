using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Dominio;
using System.Data;
using System.Security.Cryptography;


namespace Conexion_DB
{
    public class AccesoDatos 
    {
        private SqlConnection conexion;

        private SqlCommand comando;

        private SqlDataReader lector;

        public SqlDataReader Lector
        {
            get { return lector; }
        }

       
        
        // Constructor sobre cargado con la conexion a la DB
        public AccesoDatos()
        {
          conexion = new SqlConnection("server=.\\SQLEXPRESS;database=CATALOGO_DB;integrated security=true");
            comando = new SqlCommand();

        }

        //Busqueda de datos en DB
        public void SetearConsulta(string consulta)
        {
                    
            comando.CommandType = System.Data.CommandType.Text;

            comando.CommandText = consulta; 
        
        }

        //Lectura de contenido
        public void EjecutarLectura()
        { 
            
            comando.Connection = conexion;

            try
            {


                conexion.Open();

                lector = comando.ExecuteReader();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        
        }

        public void setearParametro(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        public void CerrarConexion ()
        {
            if(lector != null)
            { 
                lector.Close();
                conexion.Close();
            }
        }

        //Metodo para ejecutar el añadido de un nuevo articulo
        public void EjecutarAccion () 
        {

            comando.Connection= conexion;

            try
            {

                conexion.Open();

               comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        
        }


        //Encriptación de clave en sha256
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
        // Método para verificar las credenciales
        public bool VerificarCredenciales(string usuario, string contrasena)
        {
            try
            {
                string contrasenaEncriptada = Encrypt.GetSHA256(contrasena);

                // Reemplaza "NombreTabla" y "CampoUsuario" y "CampoContrasena" con los nombres reales de tu tabla y columnas.
                string consulta = "SELECT Usuario, Contrasena FROM Users WHERE Usuario = @usuario AND Contrasena = @contrasena";
                SetearConsulta(consulta);

                // Utiliza parámetros en lugar de concatenar la consulta para evitar SQL Injection
                var parametroUsuario = new SqlParameter("@usuario", SqlDbType.NVarChar, 50);
                parametroUsuario.Value = usuario;
                AgregarParametro(parametroUsuario);

                var parametroContrasena = new SqlParameter("@contrasena", SqlDbType.NVarChar, 200);
                parametroContrasena.Value = contrasenaEncriptada;
                AgregarParametro(parametroContrasena);

                EjecutarLectura();

                // Si el lector tiene alguna fila, entonces las credenciales son correctas.
                return lector.HasRows;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CerrarConexion();
            }
        }
        public void AgregarParametro(SqlParameter parametro)
        {
            if (comando != null)
            {
                comando.Parameters.Add(parametro);
            }
        }

    }
}
