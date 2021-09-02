namespace Migracion
{
    partial class Migrador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Migrador));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnCategorias = new System.Windows.Forms.Button();
            this.btnCrear = new System.Windows.Forms.Button();
            this.btnPrecios = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblNombreFichero = new System.Windows.Forms.Label();
            this.btnSeleccionarCSV = new System.Windows.Forms.Button();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.BarraProgreso = new System.Windows.Forms.ToolStripProgressBar();
            this.lblBarraProgreso = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotalRegistros = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnCostos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(5);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvDatos);
            this.splitContainer1.Panel2.Controls.Add(this.statusStrip1);
            this.splitContainer1.Size = new System.Drawing.Size(816, 530);
            this.splitContainer1.SplitterDistance = 148;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnCategorias
            // 
            this.btnCategorias.Image = ((System.Drawing.Image)(resources.GetObject("btnCategorias.Image")));
            this.btnCategorias.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategorias.Location = new System.Drawing.Point(581, 75);
            this.btnCategorias.Name = "btnCategorias";
            this.btnCategorias.Size = new System.Drawing.Size(149, 50);
            this.btnCategorias.TabIndex = 3;
            this.btnCategorias.Text = "Sincronizar Categorías";
            this.btnCategorias.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCategorias.UseVisualStyleBackColor = true;
            this.btnCategorias.Click += new System.EventHandler(this.btnCategorias_Click);
            // 
            // btnCrear
            // 
            this.btnCrear.Image = ((System.Drawing.Image)(resources.GetObject("btnCrear.Image")));
            this.btnCrear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCrear.Location = new System.Drawing.Point(581, 19);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(149, 50);
            this.btnCrear.TabIndex = 2;
            this.btnCrear.Text = "Crear Registros";
            this.btnCrear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // btnPrecios
            // 
            this.btnPrecios.Image = ((System.Drawing.Image)(resources.GetObject("btnPrecios.Image")));
            this.btnPrecios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrecios.Location = new System.Drawing.Point(426, 19);
            this.btnPrecios.Name = "btnPrecios";
            this.btnPrecios.Size = new System.Drawing.Size(149, 50);
            this.btnPrecios.TabIndex = 1;
            this.btnPrecios.Text = "Sincronizar Precios";
            this.btnPrecios.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrecios.UseVisualStyleBackColor = true;
            this.btnPrecios.Click += new System.EventHandler(this.btnPrecios_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCostos);
            this.groupBox1.Controls.Add(this.btnCategorias);
            this.groupBox1.Controls.Add(this.lblNombreFichero);
            this.groupBox1.Controls.Add(this.btnCrear);
            this.groupBox1.Controls.Add(this.btnSeleccionarCSV);
            this.groupBox1.Controls.Add(this.btnPrecios);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(750, 138);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccionar archivo";
            // 
            // lblNombreFichero
            // 
            this.lblNombreFichero.Location = new System.Drawing.Point(6, 16);
            this.lblNombreFichero.Name = "lblNombreFichero";
            this.lblNombreFichero.Size = new System.Drawing.Size(259, 109);
            this.lblNombreFichero.TabIndex = 3;
            this.lblNombreFichero.Text = "Ruta del archivo...";
            // 
            // btnSeleccionarCSV
            // 
            this.btnSeleccionarCSV.Image = ((System.Drawing.Image)(resources.GetObject("btnSeleccionarCSV.Image")));
            this.btnSeleccionarCSV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeleccionarCSV.Location = new System.Drawing.Point(271, 19);
            this.btnSeleccionarCSV.Name = "btnSeleccionarCSV";
            this.btnSeleccionarCSV.Size = new System.Drawing.Size(149, 50);
            this.btnSeleccionarCSV.TabIndex = 0;
            this.btnSeleccionarCSV.Text = "Buscar archivo CSV";
            this.btnSeleccionarCSV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSeleccionarCSV.UseVisualStyleBackColor = true;
            this.btnSeleccionarCSV.Click += new System.EventHandler(this.btnSeleccionarCSV_Click);
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDatos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDatos.Location = new System.Drawing.Point(0, 0);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            this.dgvDatos.RowHeadersVisible = false;
            this.dgvDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDatos.Size = new System.Drawing.Size(816, 346);
            this.dgvDatos.TabIndex = 1;
            this.dgvDatos.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvDatos_DataBindingComplete);
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BarraProgreso,
            this.lblBarraProgreso,
            this.lblTotalRegistros});
            this.statusStrip1.Location = new System.Drawing.Point(0, 346);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(816, 32);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // BarraProgreso
            // 
            this.BarraProgreso.AutoSize = false;
            this.BarraProgreso.Name = "BarraProgreso";
            this.BarraProgreso.Size = new System.Drawing.Size(200, 26);
            // 
            // lblBarraProgreso
            // 
            this.lblBarraProgreso.Name = "lblBarraProgreso";
            this.lblBarraProgreso.Size = new System.Drawing.Size(23, 27);
            this.lblBarraProgreso.Text = "0%";
            // 
            // lblTotalRegistros
            // 
            this.lblTotalRegistros.Name = "lblTotalRegistros";
            this.lblTotalRegistros.Size = new System.Drawing.Size(61, 27);
            this.lblTotalRegistros.Text = "0 registros";
            // 
            // btnCostos
            // 
            this.btnCostos.Image = ((System.Drawing.Image)(resources.GetObject("btnCostos.Image")));
            this.btnCostos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCostos.Location = new System.Drawing.Point(426, 75);
            this.btnCostos.Name = "btnCostos";
            this.btnCostos.Size = new System.Drawing.Size(149, 50);
            this.btnCostos.TabIndex = 4;
            this.btnCostos.Text = "Sincronizar Costo";
            this.btnCostos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCostos.UseVisualStyleBackColor = true;
            this.btnCostos.Click += new System.EventHandler(this.btnCostos_Click);
            // 
            // Migrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 530);
            this.Controls.Add(this.splitContainer1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Migrador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MIGRADOR DE CSV";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button btnSeleccionarCSV;
        private System.Windows.Forms.Label lblNombreFichero;
        private System.Windows.Forms.ToolStripProgressBar BarraProgreso;
        private System.Windows.Forms.ToolStripStatusLabel lblBarraProgreso;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCategorias;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Button btnPrecios;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalRegistros;
        private System.Windows.Forms.Button btnCostos;
    }
}