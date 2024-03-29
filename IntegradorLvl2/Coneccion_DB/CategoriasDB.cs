﻿using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Conexion_DB
{
    public class CategoriasDB
    {

        public List<Categorias> Listar()
        {

            List <Categorias> list = new List<Categorias>();

            AccesoDatos datos = new AccesoDatos();

            //Lectura del contenido en la tabla Categorias 

            try
            {

                datos.SetearConsulta("Select Id, Descripcion From CATEGORIAS");

                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Categorias aux = new Categorias();
                    
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
