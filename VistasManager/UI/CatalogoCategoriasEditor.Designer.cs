namespace VistasManager.UI
{
    partial class CatalogoCategoriasEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CatalogoCategoriasEditor));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnCancelar = new System.Windows.Forms.ToolStripButton();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.grupoIdentificacion = new System.Windows.Forms.GroupBox();
            this.NombreCategoria = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.IDCategoria = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Descuento = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
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
            this.toolStrip1.Size = new System.Drawing.Size(418, 32);
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
            this.grupoIdentificacion.Controls.Add(this.Descuento);
            this.grupoIdentificacion.Controls.Add(this.label2);
            this.grupoIdentificacion.Controls.Add(this.NombreCategoria);
            this.grupoIdentificacion.Controls.Add(this.label3);
            this.grupoIdentificacion.Controls.Add(this.IDCategoria);
            this.grupoIdentificacion.Controls.Add(this.label1);
            this.grupoIdentificacion.Location = new System.Drawing.Point(6, 38);
            this.grupoIdentificacion.Name = "grupoIdentificacion";
            this.grupoIdentificacion.Size = new System.Drawing.Size(412, 113);
            this.grupoIdentificacion.TabIndex = 11;
            this.grupoIdentificacion.TabStop = false;
            this.grupoIdentificacion.Text = "IDENTIFICACION";
            // 
            // NombreCategoria
            // 
            this.NombreCategoria.Location = new System.Drawing.Point(128, 45);
            this.NombreCategoria.Name = "NombreCategoria";
            this.NombreCategoria.Size = new System.Drawing.Size(264, 20);
            this.NombreCategoria.TabIndex = 1;
            this.NombreCategoria.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NombreBodega_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nombre de categoría:";
            // 
            // IDCategoria
            // 
            this.IDCategoria.Enabled = false;
            this.IDCategoria.Location = new System.Drawing.Point(128, 19);
            this.IDCategoria.Name = "IDCategoria";
            this.IDCategoria.Size = new System.Drawing.Size(115, 20);
            this.IDCategoria.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID. Categoría:";
            // 
            // Descuento
            // 
            this.Descuento.Location = new System.Drawing.Point(128, 71);
            this.Descuento.Name = "Descuento";
            this.Descuento.Size = new System.Drawing.Size(115, 20);
            this.Descuento.TabIndex = 5;
            this.Descuento.Validating += new System.ComponentModel.CancelEventHandler(this.Descuento_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Descuento (%):";
            // 
            // CatalogoCategoriasEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 181);
            this.Controls.Add(this.grupoIdentificacion);
            this.Controls.Add(this.toolStrip1);
            this.Name = "CatalogoCategoriasEditor";
            this.Text = "EDITOR DE CATEGORIAS";
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
        private System.Windows.Forms.TextBox NombreCategoria;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox IDCategoria;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Descuento;
        private System.Windows.Forms.Label label2;
    }
}