using Conexion_DB;
using Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinApp
{
    public partial class FormArticulos : Form
    {
        public FormArticulos()
        {
            InitializeComponent();
            
        }

       
        private void FormArticulos_Load(object sender, EventArgs e)
        {
            Cargar();
         //Carga los datos en el desplegable de campo
            cmbCampo.Items.Add("Categoria");
            cmbCampo.Items.Add("Marca");
            
            
        }

        private List<Articulos> listadoArticulo;

        
        private void Cargar()
        {
            ArticulosDB articulosDB = new ArticulosDB();
            try
            {
                listadoArticulo = articulosDB.Listar();
                dgvArticulo.DataSource = listadoArticulo;
                ocultarColumnas();
                cargarImagen(listadoArticulo[0].ImagenURL);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void ocultarColumnas()
        {
            dgvArticulo.Columns["ImagenURL"].Visible = false;
            dgvArticulo.Columns["Id"].Visible = false;
        }


        private void dgvArticulo_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvArticulo.CurrentRow != null)
            {
                Articulos seleccionado = (Articulos)dgvArticulo.CurrentRow.DataBoundItem;

                cargarImagen(seleccionado.ImagenURL);
            }
        }

        private void cargarImagen(string ImagenURL)
        {

            try
            {
                pbxArticulo.Load(ImagenURL);
            }
            catch (Exception)
            {
               pbxArticulo.Load("https://img.freepik.com/vector-premium/vector-icono-imagen-predeterminado-pagina-imagen-faltante-diseno-sitio-web-o-aplicacion-movil-no-hay-foto-disponible_87543-11093.jpg");
                                    
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            Agregar_Articulo nuevo = new Agregar_Articulo();

            nuevo.ShowDialog();

            Cargar();
        }

       
        private void btnModificar_Click(object sender, EventArgs e)
        {
            Articulos seleccionado;

            seleccionado = (Articulos)dgvArticulo.CurrentRow.DataBoundItem;

            //Contructor que recibe un articulo
            Agregar_Articulo modificar = new Agregar_Articulo(seleccionado);

            modificar.ShowDialog();

            Cargar();

        }

        //Eliminacion fisica y logica(Borra o desactiva completamente de la base de datos)
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
             

            
        }

        //Desactiva el registro de la base de datos
        private void Eliminar()
        {
            ArticulosDB articulos = new ArticulosDB();
            Articulos seleccionado;

            try
            {
                //Pregunta al usuario si desea eliminar o desactivar
                DialogResult respuesta = MessageBox.Show("¿Desea eliminar o desactivar el artículo? Si = Eliminar / No = Desactivar", "Eliminando / Desactivando", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (respuesta == DialogResult.Yes)
                {
                    // Eliminación física
                    seleccionado = (Articulos)dgvArticulo.CurrentRow.DataBoundItem;
                    articulos.Eliminar(seleccionado.Id);
                    
                }
                else if (respuesta == DialogResult.No )
                {
                    // Desactivación lógica
                    seleccionado = (Articulos)dgvArticulo.CurrentRow.DataBoundItem;
                    articulos.EliminarLogico(seleccionado.Id);
                    
                }
                Cargar();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ArticulosDB articulos = new ArticulosDB();
            try
            {
                string campo = cmbCampo.SelectedItem.ToString();
                string criterio = cmbCriterio.SelectedItem.ToString();
                string filtroAv = txbFiltroAvanzado.Text;

                dgvArticulo.DataSource = articulos.filtrar(campo, criterio, filtroAv);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        
        }

      
        private void txbFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Articulos> listaFilfrada;

            string Filtro = txbFiltro.Text;
            // Expresion lambda (=>)si el articulo ingresado en el textBox es true guarda en x y lo carga en listafiltrada
            // lambda = es una forma concisa de representar una función anónima o sin nombre

            if (Filtro.Length >= 3)
            {

                listaFilfrada = listadoArticulo.FindAll(x => x.Nombre.ToLower().Contains(Filtro.ToLower()) || x.CodigoArticulo.ToLower().Contains(Filtro.ToLower()) || x.Precio.ToString().ToLower().Contains(Filtro.ToLower()));


            }
            else
            {
                listaFilfrada = listadoArticulo;
            }

            dgvArticulo.DataSource = null;
            dgvArticulo.DataSource = listaFilfrada;
            ocultarColumnas();
        }

        private void cmbCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cmbCampo.SelectedItem.ToString();
            if (opcion == "Categoria")
            { 

                cmbCriterio.Items.Clear();  
                cmbCriterio.Items.Add("Celulares");
                cmbCriterio.Items.Add("Televisores");
                cmbCriterio.Items.Add("Media");
                cmbCriterio.Items.Add("Audio");

            }
            else
            {
                cmbCriterio.Items.Clear ();
                cmbCriterio.Items.Add ("Samsung");
                cmbCriterio.Items.Add("Apple");
                cmbCriterio.Items.Add("Sony");
                cmbCriterio.Items.Add("Huawey");
                cmbCriterio.Items.Add("Motorola");
            }
        }

        


    }
}
