using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace Dominio
{
    public class Articulos
    {
        
        public string CodigoArticulo { get; set; }

        public string Nombre { get; set; }
        [DisplayName ("Descripción")]//se utiliza para visualizar el acento o para mostrar
                                     //mas de una palabra o separaciones etc
        public string Descripcion { get; set; }

        public Marcas Marcas { get; set; }

        public Categorias Categorias { get; set; }

        public string ImagenURL { get; set; }

        public double Precio { get; set; }


    }
}
