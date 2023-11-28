namespace WinApp
{
    partial class Agregar_Articulo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txbCodigo = new System.Windows.Forms.TextBox();
            this.txbNombre = new System.Windows.Forms.TextBox();
            this.txbDescripcion = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txbPrecio = new System.Windows.Forms.TextBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.cmbMarca = new System.Windows.Forms.ComboBox();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.pbxPrevia = new System.Windows.Forms.PictureBox();
            this.LblVistaPrevia = new System.Windows.Forms.Label();
            this.LblURLimagen = new System.Windows.Forms.Label();
            this.txbURLimagen = new System.Windows.Forms.TextBox();
            this.btnAgregarImagen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPrevia)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(32, 63);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(59, 20);
            this.lblCodigo.TabIndex = 9;
            this.lblCodigo.Text = "Código";
            this.lblCodigo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(32, 123);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(65, 20);
            this.lblNombre.TabIndex = 10;
            this.lblNombre.Text = "Nombre";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(32, 183);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(92, 20);
            this.lblDescripcion.TabIndex = 11;
            this.lblDescripcion.Text = "Descripción";
            // 
            // txbCodigo
            // 
            this.txbCodigo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txbCodigo.Location = new System.Drawing.Point(166, 58);
            this.txbCodigo.Name = "txbCodigo";
            this.txbCodigo.Size = new System.Drawing.Size(169, 26);
            this.txbCodigo.TabIndex = 0;
            // 
            // txbNombre
            // 
            this.txbNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txbNombre.Location = new System.Drawing.Point(166, 118);
            this.txbNombre.Name = "txbNombre";
            this.txbNombre.Size = new System.Drawing.Size(169, 26);
            this.txbNombre.TabIndex = 1;
            // 
            // txbDescripcion
            // 
            this.txbDescripcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txbDescripcion.Location = new System.Drawing.Point(166, 178);
            this.txbDescripcion.Name = "txbDescripcion";
            this.txbDescripcion.Size = new System.Drawing.Size(169, 26);
            this.txbDescripcion.TabIndex = 2;
            // 
            // btnAceptar
            // 
            this.btnAceptar.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnAceptar.Location = new System.Drawing.Point(396, 506);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(118, 34);
            this.btnAceptar.TabIndex = 7;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.ForeColor = System.Drawing.Color.Red;
            this.btnCancelar.Location = new System.Drawing.Point(588, 506);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(117, 34);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txbPrecio
            // 
            this.txbPrecio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txbPrecio.Location = new System.Drawing.Point(166, 291);
            this.txbPrecio.Name = "txbPrecio";
            this.txbPrecio.Size = new System.Drawing.Size(169, 26);
            this.txbPrecio.TabIndex = 4;
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(32, 295);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(53, 20);
            this.lblPrecio.TabIndex = 13;
            this.lblPrecio.Text = "Precio";
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Location = new System.Drawing.Point(32, 355);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(53, 20);
            this.lblMarca.TabIndex = 14;
            this.lblMarca.Text = "Marca";
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(32, 423);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(78, 20);
            this.lblCategoria.TabIndex = 15;
            this.lblCategoria.Text = "Categoria";
            // 
            // cmbMarca
            // 
            this.cmbMarca.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.cmbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMarca.FormattingEnabled = true;
            this.cmbMarca.Location = new System.Drawing.Point(166, 351);
            this.cmbMarca.MaxDropDownItems = 20;
            this.cmbMarca.Name = "cmbMarca";
            this.cmbMarca.Size = new System.Drawing.Size(169, 28);
            this.cmbMarca.TabIndex = 5;
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(166, 418);
            this.cmbCategoria.MaxDropDownItems = 20;
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(169, 28);
            this.cmbCategoria.TabIndex = 6;
            // 
            // pbxPrevia
            // 
            this.pbxPrevia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbxPrevia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbxPrevia.Enabled = false;
            this.pbxPrevia.Location = new System.Drawing.Point(396, 63);
            this.pbxPrevia.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbxPrevia.Name = "pbxPrevia";
            this.pbxPrevia.Size = new System.Drawing.Size(309, 389);
            this.pbxPrevia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxPrevia.TabIndex = 16;
            this.pbxPrevia.TabStop = false;
            // 
            // LblVistaPrevia
            // 
            this.LblVistaPrevia.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblVistaPrevia.AutoSize = true;
            this.LblVistaPrevia.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblVistaPrevia.Location = new System.Drawing.Point(406, 2);
            this.LblVistaPrevia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblVistaPrevia.Name = "LblVistaPrevia";
            this.LblVistaPrevia.Size = new System.Drawing.Size(199, 37);
            this.LblVistaPrevia.TabIndex = 16;
            this.LblVistaPrevia.Text = "Vista Previa";
            this.LblVistaPrevia.UseMnemonic = false;
            // 
            // LblURLimagen
            // 
            this.LblURLimagen.AutoSize = true;
            this.LblURLimagen.Location = new System.Drawing.Point(32, 243);
            this.LblURLimagen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblURLimagen.Name = "LblURLimagen";
            this.LblURLimagen.Size = new System.Drawing.Size(100, 20);
            this.LblURLimagen.TabIndex = 12;
            this.LblURLimagen.Text = "URL Imagen";
            this.LblURLimagen.UseMnemonic = false;
            // 
            // txbURLimagen
            // 
            this.txbURLimagen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txbURLimagen.Location = new System.Drawing.Point(166, 238);
            this.txbURLimagen.Name = "txbURLimagen";
            this.txbURLimagen.Size = new System.Drawing.Size(169, 26);
            this.txbURLimagen.TabIndex = 3;
            this.txbURLimagen.Leave += new System.EventHandler(this.txbURLimagen_Leave);
            // 
            // btnAgregarImagen
            // 
            this.btnAgregarImagen.Location = new System.Drawing.Point(345, 240);
            this.btnAgregarImagen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAgregarImagen.Name = "btnAgregarImagen";
            this.btnAgregarImagen.Size = new System.Drawing.Size(42, 31);
            this.btnAgregarImagen.TabIndex = 17;
            this.btnAgregarImagen.Text = "+";
            this.btnAgregarImagen.UseVisualStyleBackColor = true;
            this.btnAgregarImagen.Click += new System.EventHandler(this.btnAgregarImagen_Click);
            // 
            // Agregar_Articulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 571);
            this.Controls.Add(this.btnAgregarImagen);
            this.Controls.Add(this.txbURLimagen);
            this.Controls.Add(this.LblURLimagen);
            this.Controls.Add(this.LblVistaPrevia);
            this.Controls.Add(this.pbxPrevia);
            this.Controls.Add(this.cmbCategoria);
            this.Controls.Add(this.cmbMarca);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.txbPrecio);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txbDescripcion);
            this.Controls.Add(this.txbNombre);
            this.Controls.Add(this.txbCodigo);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblCodigo);
            this.Name = "Agregar_Articulo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Agregar_Articulo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxPrevia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txbCodigo;
        private System.Windows.Forms.TextBox txbNombre;
        private System.Windows.Forms.TextBox txbDescripcion;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txbPrecio;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.ComboBox cmbMarca;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.PictureBox pbxPrevia;
        private System.Windows.Forms.Label LblVistaPrevia;
        private System.Windows.Forms.Label LblURLimagen;
        private System.Windows.Forms.TextBox txbURLimagen;
        private System.Windows.Forms.Button btnAgregarImagen;
    }
}