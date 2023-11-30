using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Dominio;
using System.Data;

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

        // Método para verificar las credenciales
        public bool VerificarCredenciales(string usuario, string contrasena)
        {
            try
            {
                // Reemplaza "NombreTabla" y "CampoUsuario" y "CampoContrasena" con los nombres reales de tu tabla y columnas.
                string consulta = "SELECT Usuario, Contrasena FROM Users WHERE Usuario = @usuario AND Contrasena = @contrasena";
                SetearConsulta(consulta);

                // Utiliza parámetros en lugar de concatenar la consulta para evitar SQL Injection
                var parametroUsuario = new SqlParameter("@usuario", SqlDbType.NVarChar, 50);
                parametroUsuario.Value = usuario;
                AgregarParametro(parametroUsuario);

                var parametroContrasena = new SqlParameter("@contrasena", SqlDbType.NVarChar, 50);
                parametroContrasena.Value = contrasena;
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
