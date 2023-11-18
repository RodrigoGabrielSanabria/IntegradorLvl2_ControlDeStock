using Conexion_DB;
using Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private List<Articulos> listadoArticulo;
        private void Form1_Load(object sender, EventArgs e)
        {
            ArticulosDB articulosDB = new ArticulosDB();

            listadoArticulo = articulosDB.Listar();

            dgvArticulo.DataSource = listadoArticulo;

            dgvArticulo.Columns["ImagenURL"].Visible = false;
            cargarImagen(listadoArticulo[0].ImagenURL);

        }

        private void dgvArticulo_SelectionChanged(object sender, EventArgs e)
        {
            Articulos seleccionado = (Articulos)dgvArticulo.CurrentRow.DataBoundItem;

            cargarImagen(seleccionado.ImagenURL);
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
        }

       
        //Cargar codigo para barra de progreso
        private void tsBarraProgreso_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripStatusLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
