using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinApp
{
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
}
