using Conexion_DB;
using Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
                // Pregunta al usuario si desea eliminar o desactivar
                using (FormCustomDialog customDialog = new FormCustomDialog())
                {
                   
                    DialogResult respuesta = customDialog.ShowDialog();
                    
                    if (respuesta == DialogResult.Yes)
                    {
                        // Eliminación física
                        seleccionado = (Articulos)dgvArticulo.CurrentRow.DataBoundItem;
                        articulos.Eliminar(seleccionado.Id);

                    }
                    else if (respuesta == DialogResult.No)
                    {
                        // Desactivación lógica
                        seleccionado = (Articulos)dgvArticulo.CurrentRow.DataBoundItem;
                        articulos.EliminarLogico(seleccionado.Id);

                    }
                    Cargar();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool validarFiltro()
        {

            if (cmbCampo.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un campo para filtrar.");
                return true;
            }

            if (cmbCriterio.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione un criterio para filtrar.");
                return true;
            }

            //if (cmbCampo.SelectedIndex.ToString() == "Categoria")   //esta condicion daba error nunca ingresaba
            //{

                if (!(soloLetras(txbFiltroAvanzado.Text)))
                {
                    MessageBox.Show("Solo se pueden ingresar letras.");
                    return true;
                }

                if (string.IsNullOrEmpty(txbFiltroAvanzado.Text))
                {
                    MessageBox.Show("Debes cargar el filtro para realizar una busqueda");

                    return true;


                }


           // }

            return false;

        }

        private bool soloLetras (string cadena) 
        {
            foreach(char caracter in cadena)
            {
                if (!char.IsLetter(caracter))
                {
                    return false;
                }


            }
            return true;

        }
        
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ArticulosDB articulos = new ArticulosDB();
            try
            {
                if (validarFiltro())

                { 
                    return;
                }
                
                
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


        //Clase que hereda de FORM para modificar los botones del boton eliminar/Desactivar
        // Permitiendo personalizar la ventana y mensaje
       public class FormCustomDialog : Form
        {
            private Button btnEliminar;
            private Button btnDesactivar;
            private Button btnModificar;
            private Button btnCancelar;
            private Label lblMensaje;

            public FormCustomDialog()
            {
                // Configuracion de la ventana
                this.Text = "Eliminar - Desactivar ";
                this.FormBorderStyle = FormBorderStyle.FixedDialog;
                this.MaximizeBox = false;
                this.MinimizeBox = false;
                this.StartPosition = FormStartPosition.CenterParent;
                this.Size = new Size(230, 100);

                // Crea los botones 
                btnEliminar = new Button();
                btnEliminar.Text = "Eliminar";
                btnEliminar.DialogResult = DialogResult.Yes;
                btnEliminar.AutoSize = true;

                btnDesactivar = new Button();
                btnDesactivar.Text = "Desactivar";
                btnDesactivar.DialogResult = DialogResult.No;
                btnDesactivar.AutoSize = true;

                btnCancelar = new Button();
                btnCancelar.Text = "Cancelar";
                btnCancelar.DialogResult = DialogResult.Cancel;
                btnCancelar.AutoSize = true;

                lblMensaje = new Label();
                lblMensaje.Text = "¿Qué acción desea realizar?";
                lblMensaje.AutoSize = true;

                // Crea el panel donde se muestran los botones y los ubica x indice
                TableLayoutPanel tlp = new TableLayoutPanel();
                tlp.ColumnCount = 3;
                tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
                tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45));
                tlp.Controls.Add(btnEliminar, 1, 1);
                tlp.Controls.Add(btnDesactivar, 2, 1);
                tlp.Controls.Add(btnCancelar, 3, 1);
                tlp.Controls.Add(lblMensaje, 1, 0);
                tlp.SetColumnSpan(lblMensaje, 3);

                this.Controls.Add(tlp);
                this.AcceptButton = btnEliminar;
                this.CancelButton = btnCancelar;
            }
        }





        //Configurar ...
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }



    }
}
