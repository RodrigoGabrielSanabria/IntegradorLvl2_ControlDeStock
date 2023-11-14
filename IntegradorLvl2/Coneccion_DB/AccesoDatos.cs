using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Dominio;

namespace Coneccion_DB
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

        public void CerrarConexion ()
        {
            if(lector != null)
            { 
                lector.Close();
                conexion.Close();
            }
        }

    }
}
