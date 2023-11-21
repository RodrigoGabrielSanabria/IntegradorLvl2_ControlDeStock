using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Conexion_DB;

namespace WinApp
{
    public partial class Agregar_Articulo : Form
    {
        public Agregar_Articulo()
        {
            InitializeComponent();
        }

        //Carga la lista de opciones en el desplegable
        private void Agregar_Articulo_Load(object sender, EventArgs e)
        {

            CategoriasDB agregarCategoria = new CategoriasDB();
            MarcasDB agregarMarca = new MarcasDB();
            try
            {

                cmbCategoria.DataSource = agregarCategoria.Listar();

                cmbMarca.DataSource = agregarMarca.Listar();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            Articulos nuevoArt = new Articulos();

            ArticulosDB articulo = new ArticulosDB(); 

            try
            {
                    //Carga los datos ingresados en los texbox            
                nuevoArt.CodigoArticulo = txbCodigo.Text;

                nuevoArt.Nombre = txbNombre.Text;

                nuevoArt.Descripcion = txbDescripcion.Text; 

                nuevoArt.Precio = double.Parse(txbPrecio.Text);

                nuevoArt.Categorias = (Categorias)cmbCategoria.SelectedItem;

                nuevoArt.Marcas = (Marcas)cmbMarca.SelectedItem;  


                //Llama al metodo creado en ArticulosDB 

                articulo.AgregarArticulo(nuevoArt);

                MessageBox.Show("Agregado Exitosamente");

                Close();
            }
            catch (Exception ex)
            {

               MessageBox.Show(ex.ToString());
            }
        }

        private void txbURLimagen_Leave(object sender, EventArgs e)
        {
            cargarImagen(txbURLimagen.Text);
        }
        private void cargarImagen(string ImagenURL)
        {

            try
            {
                pbxPrevia.Load(ImagenURL);
            }
            catch (Exception)
            {

                pbxPrevia.Load("https://img.freepik.com/vector-premium/vector-icono-imagen-predeterminado-pagina-imagen-faltante-diseno-sitio-web-o-aplicacion-movil-no-hay-foto-disponible_87543-11093.jpg");
            }
        }
    }
}
