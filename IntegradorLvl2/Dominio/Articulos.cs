using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dominio
{
    public class Articulos
    {
        public string CodigoArticulo { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public Marcas Marcas { get; set; }

        public Categorias Categorias { get; set; }

        public string ImagenURL { get; set; }

        public double Precio { get; set; }


    }
}
