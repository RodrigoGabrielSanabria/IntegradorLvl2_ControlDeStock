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

                comando.CommandText = "SELECT Codigo, Nombre, A.Descripcion, M.Descripcion, C.Descripcion, ImagenUrl,Precio, A.IdMarca, A.IdCategoria, A.Id from dbo.ARTICULOS A, dbo.categorias C, dbo.marcas M where M.Id=A.IdMarca and C.Id=A.IdCategoria\r\n"; //Insertar consulta
                
                comando.Connection = conexion;

                conexion.Open();

                lector = comando.ExecuteReader();

                //Ciclo WHILE para mostrar los datos en el GridView
                while (lector.Read())
                {
                    Articulos aux = new Articulos();
                    aux.Id = (int)lector["Id"];
                    aux.CodigoArticulo = lector.GetString(0);
                    aux.Nombre = lector.GetString(1);
                    aux.Descripcion = lector.GetString(2);
                    aux.Marcas = new Marcas();
                    aux.Marcas.Id = (int)lector["IdMarca"];
                    aux.Marcas.Descripcion = lector.GetString(3);
                    aux.Categorias = new Categorias();
                    aux.Categorias.Id = (int)lector["IdCategoria"];
                    aux.Categorias.Descripcion = lector.GetString(4);
                    if(!(lector["ImagenURL"] is DBNull)) //Se utiliza para hacer una comprobacion
                    aux.ImagenURL = lector.GetString(5); //Para saber si el valor es nulo

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
          
        }

        public void AgregarArticulo(Articulos nuevo) 
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearConsulta("Insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio, ImagenUrl) values('" + nuevo.CodigoArticulo + "', '" + nuevo.Nombre + "', '" + nuevo.Descripcion + "', @IdMarca, @IdCategoria, '" + nuevo.Precio +"', @ImagenUrl )");
                datos.setearParametro("@IdMarca", nuevo.Marcas.Id);
                datos.setearParametro("@IdCategoria", nuevo.Categorias.Id);
                datos.setearParametro("@ImagenUrl", nuevo.ImagenURL);
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

        public void ModificarArticulo(Articulos modificar) 
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {

                datos.SetearConsulta("update ARTICULOS set Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, IdMarca = @IdMarca, IdCategoria = @IdCategoria, ImagenUrl= @ImagenUrl, Precio = @Precio where Id = @Id");

                datos.setearParametro("@Codigo", modificar.CodigoArticulo);
                datos.setearParametro("@Nombre", modificar.Nombre);
                datos.setearParametro("@Descripcion", modificar.Descripcion);
                datos.setearParametro("@IdMarca", modificar.Marcas.Id);
                datos.setearParametro("@IdCategoria", modificar.Categorias.Id);
                datos.setearParametro("@ImagenUrl", modificar.ImagenURL);
                datos.setearParametro("@Precio", modificar.Precio);
                datos.setearParametro("@Id", modificar.Id);

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
 
    
    }
}
