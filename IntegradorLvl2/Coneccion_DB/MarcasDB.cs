using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conexion_DB
{
    public class MarcasDB
    {

        public List<Marcas> Listar()
        {

            List<Marcas> list = new List<Marcas>();

            AccesoDatos datos = new AccesoDatos();

            //Lectura del contenido en la tabla Marcas

            try
            {

                datos.SetearConsulta("Select Id, Descripcion From MARCAS");

                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Marcas aux = new Marcas();

                    aux.Id = (int)datos.Lector["Id"];

                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    list.Add(aux);
                }


                return list;

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
