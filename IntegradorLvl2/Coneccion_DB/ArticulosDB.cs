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
    public class ArticulosDB
    {
        public List<Articulos> Listar() 
        {
            List<Articulos> list = new List<Articulos>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS;database=CATALOGO_DB;integrated security=true";

                comando.CommandType = System.Data.CommandType.Text;

                comando.CommandText = ""; //Insertar consulta


                comando.Connection = conexion;

                conexion.Open();

                lector = comando.ExecuteReader();

                //Cargar Ciclo WHILE para mostrar los datos en el GridView

               //hol
            }
            catch (Exception ex) 
            {

                throw ex;
            }
        }
    }
}
