namespace VistasManager.UI
{
    partial class CatalogoSubcategoriasEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CatalogoSubcategoriasEditor));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnCancelar = new System.Windows.Forms.ToolStripButton();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.grupoIdentificacion = new System.Windows.Forms.GroupBox();
            this.NombreSubcategoria = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.IDSubcategoria = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NombreCategoria = new System.Windows.Forms.ComboBox();
            this.toolStrip1.SuspendLayout();
            this.grupoIdentificacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCancelar,
            this.btnGuardar});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(454, 32);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(73, 29);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(69, 29);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.ToolTipText = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // grupoIdentificacion
            // 
            this.grupoIdentificacion.Controls.Add(this.NombreCategoria);
            this.grupoIdentificacion.Controls.Add(this.label2);
            this.grupoIdentificacion.Controls.Add(this.NombreSubcategoria);
            this.grupoIdentificacion.Controls.Add(this.label3);
            this.grupoIdentificacion.Controls.Add(this.IDSubcategoria);
            this.grupoIdentificacion.Controls.Add(this.label1);
            this.grupoIdentificacion.Location = new System.Drawing.Point(6, 38);
            this.grupoIdentificacion.Name = "grupoIdentificacion";
            this.grupoIdentificacion.Size = new System.Drawing.Size(448, 126);
            this.grupoIdentificacion.TabIndex = 11;
            this.grupoIdentificacion.TabStop = false;
            this.grupoIdentificacion.Text = "IDENTIFICACION";
            // 
            // NombreSubcategoria
            // 
            this.NombreSubcategoria.Location = new System.Drawing.Point(145, 45);
            this.NombreSubcategoria.Name = "NombreSubcategoria";
            this.NombreSubcategoria.Size = new System.Drawing.Size(283, 20);
            this.NombreSubcategoria.TabIndex = 1;
            this.NombreSubcategoria.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NombreBodega_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nombre de subcategoría:";
            // 
            // IDSubcategoria
            // 
            this.IDSubcategoria.Enabled = false;
            this.IDSubcategoria.Location = new System.Drawing.Point(145, 19);
            this.IDSubcategoria.Name = "IDSubcategoria";
            this.IDSubcategoria.Size = new System.Drawing.Size(115, 20);
            this.IDSubcategoria.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID. Subcategoría:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(82, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Categoría:";
            // 
            // NombreCategoria
            // 
            this.NombreCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NombreCategoria.FormattingEnabled = true;
            this.NombreCategoria.Location = new System.Drawing.Point(145, 84);
            this.NombreCategoria.Name = "NombreCategoria";
            this.NombreCategoria.Size = new System.Drawing.Size(283, 21);
            this.NombreCategoria.TabIndex = 6;
            // 
            // CatalogoSubcategoriasEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 191);
            this.Controls.Add(this.grupoIdentificacion);
            this.Controls.Add(this.toolStrip1);
            this.Name = "CatalogoSubcategoriasEditor";
            this.Text = "EDITOR DE SUBCATEGORIAS";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.grupoIdentificacion.ResumeLayout(false);
            this.grupoIdentificacion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnCancelar;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.GroupBox grupoIdentificacion;
        private System.Windows.Forms.TextBox NombreSubcategoria;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox IDSubcategoria;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox NombreCategoria;
    }
}