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
using System.IO;
using System.Configuration;
using System.Text.RegularExpressions;

namespace WinApp
{
    public partial class Agregar_Articulo : Form
    {
        private Articulos articulos = null;
        private OpenFileDialog Archivo = null;

        public Agregar_Articulo()
        {
            InitializeComponent();
        }

        //Constructor 
        public Agregar_Articulo(Articulos articulos)
        {
            InitializeComponent();

            this.articulos=articulos;

            Text = "Modificar Artículo";
        }

       

        //Carga la lista de opciones en el desplegable
        private void Agregar_Articulo_Load(object sender, EventArgs e)
        {

            CategoriasDB agregarCategoria = new CategoriasDB();
            MarcasDB agregarMarca = new MarcasDB();
            try
            {

                cmbCategoria.DataSource = agregarCategoria.Listar();
               
                //Nombres de las propiedades de la clase Categoria y Marca
                cmbCategoria.ValueMember = "Id";
                cmbCategoria.DisplayMember = "Descripcion";
                 
                
                cmbMarca.DataSource = agregarMarca.Listar();

                //Propiedades de Marca
                cmbMarca.ValueMember = "Id";
                cmbMarca.DisplayMember = "Descripcion";

                //Precarga los datos del articulo seleccionado reutilizando el formulario Agregar Articulo
                if (articulos != null)
                {

                    txbCodigo.Text = articulos.CodigoArticulo;
                    txbNombre.Text = articulos.Nombre;
                    txbDescripcion.Text = articulos.Descripcion;
                    txbURLimagen.Text = articulos.ImagenURL;
                    txbPrecio.Text = articulos.Precio.ToString();

                    cargarImagen(articulos.ImagenURL);

                    //Pre seleccionar opciones de los desplegables del articulo seleccionado
                    cmbCategoria.SelectedValue = articulos.Categorias.Id;
                    cmbMarca.SelectedValue = articulos.Marcas.Id;
                }
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

            //Articulos nuevoArt = new Articulos();

            ArticulosDB articulo = new ArticulosDB();

            try
            {
                if (!ValidarCodigo(txbCodigo.Text))
                {
                    MessageBox.Show("No debe contener caracteres especiales.");
                    return;
                }

                if (!ValidarNombre(txbNombre.Text))
                {
                    MessageBox.Show("No debe contener caracteres especiales, ni números.");
                    return;
                }

                if (!ValidarDescripcion(txbDescripcion.Text))
                {
                    MessageBox.Show("No debe contener caracteres especiales y/o espacios en blanco.");
                    return;
                }

                if (!ValidarPrecio(txbPrecio.Text))
                {
                    MessageBox.Show("No debe contener caracteres especiales, ni letras.");
                    return;
                }
                //Uso de de la clase privada articulos. Mapea los datos para agregar y modificar
                //Carga los datos ingresados en los texbox            

                if (articulos == null)
                    articulos = new Articulos(); //Si esta en nulo, se agrega un nuevo articulo

                articulos.CodigoArticulo = txbCodigo.Text;

                articulos.Nombre = txbNombre.Text;

                articulos.Descripcion = txbDescripcion.Text;

                articulos.Precio = double.Parse(txbPrecio.Text);

                articulos.Categorias = (Categorias)cmbCategoria.SelectedItem;

                articulos.Marcas = (Marcas)cmbMarca.SelectedItem;

                articulos.ImagenURL = txbURLimagen.Text;


                //Llama al metodo creado en ArticulosDB 

                if (articulos.Id != 0)
                {

                    articulo.ModificarArticulo(articulos);

                    MessageBox.Show("Modificado Exitosamente");

                }
                else
                {
                    articulo.AgregarArticulo(articulos);

                    MessageBox.Show("Agregado Exitosamente");

                }
                //guardar imagen si esta subida desde el ordenador
               // if (Archivo != null && !(txbURLimagen.Text.ToUpper().Contains("HTTP")))
               // {
               //     File.Copy(Archivo.FileName, ConfigurationManager.AppSettings["images-folder"] + Archivo.SafeFileName);
               // }
                    

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

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            Archivo = new OpenFileDialog();
            Archivo.Filter = "jpg|*.jpg|png|*.png"; //Filtro 

            if (Archivo.ShowDialog() == DialogResult.OK)
            {
                string nombreArchivo = Path.GetFileName(Archivo.FileName);
                string nuevoNombreArchivo = nombreArchivo;
                int contador = 1;

                //Si la imagen ya existe, agre "_" e incrementa el contador
                while (File.Exists(Path.Combine(ConfigurationManager.AppSettings["images-folder"], nuevoNombreArchivo)))
                {
                    string nombreArchivoSinExtension = Path.GetFileNameWithoutExtension(nombreArchivo);
                    string extension = Path.GetExtension(nombreArchivo);
                    nuevoNombreArchivo = $"{nombreArchivoSinExtension}_{contador}{extension}";
                    contador++;
                }

                string archivoPath = Path.Combine(ConfigurationManager.AppSettings["images-folder"], nuevoNombreArchivo);

                //En el caso de que no exita, solamente copia la imagen y la guarda
                try
                {
                    File.Copy(Archivo.FileName, archivoPath);

                    txbURLimagen.Text = archivoPath;
                    cargarImagen(archivoPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"No se pudo copiar el archivo: {ex.Message}");
                }
            }

           

            

        }
        //-------------------------

        private bool ValidarCodigo(string codigo)
        {

            // Acepta solo letras y números y no acepta espacios en blanco
            return !string.IsNullOrWhiteSpace(codigo) && Regex.IsMatch(codigo, "^[a-zA-Z0-9]+$");
        }

        private bool ValidarNombre(string nombre)
        {
            foreach (char caracter in nombre)
            {
                if (!char.IsLetter(caracter))
                {
                    return false;
                }


            }
            return true;
            // No acepta caracteres especiales ni números
            //return Regex.IsMatch(nombre, "^[a-zA-Z]+$");
        }

        private bool ValidarDescripcion(string descripcion)
        {
            // No acepta caracteres especiales y no admite cadenas vacías
            return !string.IsNullOrWhiteSpace(descripcion) && Regex.IsMatch(descripcion, "^[a-zA-Z0-9 ]+$");
        }

        private bool ValidarUrlImagen(string urlImagen)
        {
           
           
            return !string.IsNullOrWhiteSpace(urlImagen);
        }

        private bool ValidarPrecio(string precio)
        {
            // No acepta caracteres especiales ni letras y espacios en blanco
            return !string.IsNullOrWhiteSpace(precio) && Regex.IsMatch(precio, "^[0-9.]+$");
        }

        
    }
}
