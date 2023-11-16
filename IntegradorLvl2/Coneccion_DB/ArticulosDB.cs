using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Dominio;

namespace Conexion_DB
{
    public class ArticulosDB
    {
        public List<Articulos> Listar() 
        {
            List<Articulos> list = new List<Articulos>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            //Conexion y lectura de DB
            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS;database=CATALOGO_DB;integrated security=true";

                comando.CommandType = System.Data.CommandType.Text;

                comando.CommandText = "SELECT Codigo, Nombre, A.Descripcion, M.Descripcion, C.Descripcion, ImagenUrl,Precio from dbo.ARTICULOS A, DBO.CATEGORIAS C, DBO.MARCAS M where M.Id=A.IdMarca and C.Id=A.IdCategoria"; //Insertar consulta
                
                comando.Connection = conexion;

                conexion.Open();

                lector = comando.ExecuteReader();

                //Ciclo WHILE para mostrar los datos en el GridView
                while (lector.Read())
                {
                    Articulos aux = new Articulos();
                    aux.CodigoArticulo = lector.GetString(0);
                    aux.Nombre = lector.GetString(1);
                    aux.Descripcion = lector.GetString(2);
                    aux.Marcas = new Marcas();
                    aux.Marcas.Descripcion = lector.GetString(3);
                    aux.Categorias = new Categorias();
                    aux.Categorias.Descripcion = lector.GetString(4);
                    aux.ImagenURL = lector.GetString(5);
                    double precio;

                    if (double.TryParse(lector["Precio"].ToString(), out precio))
                    {
                        aux.Precio = precio;
                    }

                    list.Add(aux);
                }

                conexion.Close();
                return list;

            }

            catch (Exception ex)
            {

                throw ex;
            }
            //Cerrar 
        }

        public void AgregarArticulo(Articulos nuevo) 
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("Insert into ARTICULOS (Codigo, Nombre, Descripcion, Precio) values('" + nuevo.CodigoArticulo + "','" + nuevo.Nombre + "', '" + nuevo.Descripcion + "', " + nuevo.Precio +")");

                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            { 
            
                datos.CerrarConexion();

            }
        
        
        
        
        }

        public void ModificarArticulo(Articulos modificar) { }
 
    
    }
}
