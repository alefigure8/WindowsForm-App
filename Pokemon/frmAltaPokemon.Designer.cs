namespace Pokemon
{
    partial class frmAltaPokemon
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
            this.lbNumero = new System.Windows.Forms.Label();
            this.lbNombre = new System.Windows.Forms.Label();
            this.lbDescripcion = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtUrlImagen = new System.Windows.Forms.TextBox();
            this.lbUrlImagen = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.txtTipo = new System.Windows.Forms.Label();
            this.txtDebilidad = new System.Windows.Forms.Label();
            this.cmbDebilidad = new System.Windows.Forms.ComboBox();
            this.pbCargarImagen = new System.Windows.Forms.PictureBox();
            this.btnAgregarImagen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbCargarImagen)).BeginInit();
            this.SuspendLayout();
            // 
            // lbNumero
            // 
            this.lbNumero.AutoSize = true;
            this.lbNumero.Location = new System.Drawing.Point(39, 41);
            this.lbNumero.Name = "lbNumero";
            this.lbNumero.Size = new System.Drawing.Size(44, 13);
            this.lbNumero.TabIndex = 0;
            this.lbNumero.Text = "Número";
            // 
            // lbNombre
            // 
            this.lbNombre.AutoSize = true;
            this.lbNombre.Location = new System.Drawing.Point(39, 67);
            this.lbNombre.Name = "lbNombre";
            this.lbNombre.Size = new System.Drawing.Size(44, 13);
            this.lbNombre.TabIndex = 1;
            this.lbNombre.Text = "Nombre";
            // 
            // lbDescripcion
            // 
            this.lbDescripcion.AutoSize = true;
            this.lbDescripcion.Location = new System.Drawing.Point(20, 96);
            this.lbDescripcion.Name = "lbDescripcion";
            this.lbDescripcion.Size = new System.Drawing.Size(63, 13);
            this.lbDescripcion.TabIndex = 2;
            this.lbDescripcion.Text = "Descripción";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(90, 41);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(149, 20);
            this.txtNumero.TabIndex = 0;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(90, 67);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(149, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(90, 93);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(149, 20);
            this.txtDescripcion.TabIndex = 2;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(166, 199);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(73, 28);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(90, 199);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(73, 28);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtUrlImagen
            // 
            this.txtUrlImagen.Location = new System.Drawing.Point(90, 119);
            this.txtUrlImagen.Name = "txtUrlImagen";
            this.txtUrlImagen.Size = new System.Drawing.Size(149, 20);
            this.txtUrlImagen.TabIndex = 3;
            this.txtUrlImagen.Leave += new System.EventHandler(this.txtUrlImagen_TextChanged);
            // 
            // lbUrlImagen
            // 
            this.lbUrlImagen.AutoSize = true;
            this.lbUrlImagen.Location = new System.Drawing.Point(16, 122);
            this.lbUrlImagen.Name = "lbUrlImagen";
            this.lbUrlImagen.Size = new System.Drawing.Size(67, 13);
            this.lbUrlImagen.TabIndex = 8;
            this.lbUrlImagen.Text = "URL Imagen";
            // 
            // cmbTipo
            // 
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(90, 145);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(149, 21);
            this.cmbTipo.TabIndex = 4;
            // 
            // txtTipo
            // 
            this.txtTipo.AutoSize = true;
            this.txtTipo.Location = new System.Drawing.Point(53, 148);
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.Size = new System.Drawing.Size(28, 13);
            this.txtTipo.TabIndex = 11;
            this.txtTipo.Text = "Tipo";
            // 
            // txtDebilidad
            // 
            this.txtDebilidad.AutoSize = true;
            this.txtDebilidad.Location = new System.Drawing.Point(30, 175);
            this.txtDebilidad.Name = "txtDebilidad";
            this.txtDebilidad.Size = new System.Drawing.Size(51, 13);
            this.txtDebilidad.TabIndex = 12;
            this.txtDebilidad.Text = "Debilidad";
            // 
            // cmbDebilidad
            // 
            this.cmbDebilidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDebilidad.FormattingEnabled = true;
            this.cmbDebilidad.Location = new System.Drawing.Point(90, 172);
            this.cmbDebilidad.Name = "cmbDebilidad";
            this.cmbDebilidad.Size = new System.Drawing.Size(149, 21);
            this.cmbDebilidad.TabIndex = 5;
            // 
            // pbCargarImagen
            // 
            this.pbCargarImagen.Location = new System.Drawing.Point(275, 41);
            this.pbCargarImagen.Name = "pbCargarImagen";
            this.pbCargarImagen.Size = new System.Drawing.Size(224, 186);
            this.pbCargarImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCargarImagen.TabIndex = 14;
            this.pbCargarImagen.TabStop = false;
            // 
            // btnAgregarImagen
            // 
            this.btnAgregarImagen.Location = new System.Drawing.Point(245, 117);
            this.btnAgregarImagen.Name = "btnAgregarImagen";
            this.btnAgregarImagen.Size = new System.Drawing.Size(24, 23);
            this.btnAgregarImagen.TabIndex = 15;
            this.btnAgregarImagen.Text = "...";
            this.btnAgregarImagen.UseVisualStyleBackColor = true;
            this.btnAgregarImagen.Click += new System.EventHandler(this.btnAgregarImagen_Click);
            // 
            // frmAltaPokemon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 262);
            this.Controls.Add(this.btnAgregarImagen);
            this.Controls.Add(this.pbCargarImagen);
            this.Controls.Add(this.cmbDebilidad);
            this.Controls.Add(this.txtDebilidad);
            this.Controls.Add(this.txtTipo);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.txtUrlImagen);
            this.Controls.Add(this.lbUrlImagen);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.lbDescripcion);
            this.Controls.Add(this.lbNombre);
            this.Controls.Add(this.lbNumero);
            this.Name = "frmAltaPokemon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAltaPokemon";
            this.Load += new System.EventHandler(this.frmAltaPokemon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbCargarImagen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbNumero;
        private System.Windows.Forms.Label lbNombre;
        private System.Windows.Forms.Label lbDescripcion;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtUrlImagen;
        private System.Windows.Forms.Label lbUrlImagen;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label txtTipo;
        private System.Windows.Forms.Label txtDebilidad;
        private System.Windows.Forms.ComboBox cmbDebilidad;
        private System.Windows.Forms.PictureBox pbCargarImagen;
        private System.Windows.Forms.Button btnAgregarImagen;
    }
}