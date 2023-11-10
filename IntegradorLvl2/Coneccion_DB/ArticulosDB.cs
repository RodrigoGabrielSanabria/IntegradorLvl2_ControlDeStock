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

                comando.CommandText = "SELECT Codigo, Nombre, A.Descripcion, M.Descripcion, C.Descripcion, ImagenUrl,Precio from dbo.ARTICULOS A, DBO.CATEGORIAS C, DBO.MARCAS M where M.Id=A.IdMarca and C.Id=A.IdCategoria"; //Insertar consulta
                
                comando.Connection = conexion;

                conexion.Open();

                lector = comando.ExecuteReader();

                //Cargar Ciclo WHILE para mostrar los datos en el GridView
                while (lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.CodigoArticulo = lector.GetString(0);
                    aux.Nombre = lector.GetString(1);
                    aux.Descripcion = lector.GetString(2);
                    aux.Marca = new Marca();
                    aux.Marca.Descripcion = lector.GetString(3);
                    aux.Categoria = new Categoria();
                    aux.Categoria.Descripcion = lector.GetString(4);
                    aux.Imagen = lector.GetString(5);
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
            
        }
    }
}
