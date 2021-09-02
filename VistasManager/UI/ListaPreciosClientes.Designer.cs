namespace VistasManager.UI
{
    partial class ListaPreciosClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListaPreciosClientes));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnRecargar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txbBuscarTexto = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.BarraEstado = new System.Windows.Forms.StatusStrip();
            this.lblTotalDocumento = new System.Windows.Forms.ToolStripStatusLabel();
            this.BarraProgreso = new System.Windows.Forms.ToolStripProgressBar();
            this.lblTasa = new System.Windows.Forms.ToolStripStatusLabel();
            this.dgvCatalogo = new System.Windows.Forms.DataGridView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.txbNombreCliente = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnMostrarProductos = new System.Windows.Forms.ToolStripButton();
            this.IDProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Presentacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioActual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioEditable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.BarraEstado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCatalogo)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRecargar,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.txbBuscarTexto,
            this.toolStripSeparator2,
            this.btnGuardar});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(868, 32);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnRecargar
            // 
            this.btnRecargar.Image = ((System.Drawing.Image)(resources.GetObject("btnRecargar.Image")));
            this.btnRecargar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRecargar.Name = "btnRecargar";
            this.btnRecargar.Size = new System.Drawing.Size(73, 29);
            this.btnRecargar.Text = "Recargar";
            this.btnRecargar.Click += new System.EventHandler(this.btnRecargar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripLabel1.Image")));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(61, 29);
            this.toolStripLabel1.Text = "Buscar:";
            // 
            // txbBuscarTexto
            // 
            this.txbBuscarTexto.AutoSize = false;
            this.txbBuscarTexto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbBuscarTexto.Name = "txbBuscarTexto";
            this.txbBuscarTexto.Size = new System.Drawing.Size(220, 23);
            this.txbBuscarTexto.TextChanged += new System.EventHandler(this.txbBuscarTexto_TextChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 32);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(69, 29);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // BarraEstado
            // 
            this.BarraEstado.AutoSize = false;
            this.BarraEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTotalDocumento,
            this.BarraProgreso,
            this.lblTasa});
            this.BarraEstado.Location = new System.Drawing.Point(3, 538);
            this.BarraEstado.Name = "BarraEstado";
            this.BarraEstado.Size = new System.Drawing.Size(868, 32);
            this.BarraEstado.TabIndex = 13;
            this.BarraEstado.Text = "statusStrip1";
            // 
            // lblTotalDocumento
            // 
            this.lblTotalDocumento.Name = "lblTotalDocumento";
            this.lblTotalDocumento.Size = new System.Drawing.Size(853, 27);
            this.lblTotalDocumento.Spring = true;
            this.lblTotalDocumento.Text = "0 registros";
            this.lblTotalDocumento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BarraProgreso
            // 
            this.BarraProgreso.AutoSize = false;
            this.BarraProgreso.Name = "BarraProgreso";
            this.BarraProgreso.Size = new System.Drawing.Size(200, 26);
            this.BarraProgreso.Visible = false;
            // 
            // lblTasa
            // 
            this.lblTasa.Name = "lblTasa";
            this.lblTasa.Size = new System.Drawing.Size(23, 27);
            this.lblTasa.Text = "0%";
            this.lblTasa.Visible = false;
            // 
            // dgvCatalogo
            // 
            this.dgvCatalogo.AllowUserToAddRows = false;
            this.dgvCatalogo.AllowUserToDeleteRows = false;
            this.dgvCatalogo.AllowUserToResizeRows = false;
            this.dgvCatalogo.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvCatalogo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCatalogo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCatalogo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDProducto,
            this.CodigoProducto,
            this.NombreProducto,
            this.Presentacion,
            this.PrecioActual,
            this.PrecioEditable});
            this.dgvCatalogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCatalogo.Location = new System.Drawing.Point(3, 67);
            this.dgvCatalogo.MultiSelect = false;
            this.dgvCatalogo.Name = "dgvCatalogo";
            this.dgvCatalogo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvCatalogo.Size = new System.Drawing.Size(868, 471);
            this.dgvCatalogo.TabIndex = 14;
            this.dgvCatalogo.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCatalogo_CellEndEdit);
            this.dgvCatalogo.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvCatalogo_DataBindingComplete);
            // 
            // toolStrip2
            // 
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.txbNombreCliente,
            this.toolStripButton1,
            this.toolStripSeparator3,
            this.btnMostrarProductos});
            this.toolStrip2.Location = new System.Drawing.Point(3, 35);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(868, 32);
            this.toolStrip2.TabIndex = 15;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(47, 29);
            this.toolStripLabel2.Text = "Cliente:";
            // 
            // txbNombreCliente
            // 
            this.txbNombreCliente.AutoSize = false;
            this.txbNombreCliente.Enabled = false;
            this.txbNombreCliente.Name = "txbNombreCliente";
            this.txbNombreCliente.Size = new System.Drawing.Size(200, 32);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(69, 29);
            this.toolStripButton1.Text = "Clientes";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 32);
            // 
            // btnMostrarProductos
            // 
            this.btnMostrarProductos.Image = ((System.Drawing.Image)(resources.GetObject("btnMostrarProductos.Image")));
            this.btnMostrarProductos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMostrarProductos.Name = "btnMostrarProductos";
            this.btnMostrarProductos.Size = new System.Drawing.Size(81, 29);
            this.btnMostrarProductos.Text = "Productos";
            this.btnMostrarProductos.Click += new System.EventHandler(this.btnMostrarProductos_Click);
            // 
            // IDProducto
            // 
            this.IDProducto.DataPropertyName = "IDProducto";
            this.IDProducto.HeaderText = "ID";
            this.IDProducto.Name = "IDProducto";
            this.IDProducto.ReadOnly = true;
            this.IDProducto.Width = 60;
            // 
            // CodigoProducto
            // 
            this.CodigoProducto.DataPropertyName = "CodigoProducto";
            this.CodigoProducto.HeaderText = "Codigo";
            this.CodigoProducto.Name = "CodigoProducto";
            this.CodigoProducto.ReadOnly = true;
            // 
            // NombreProducto
            // 
            this.NombreProducto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NombreProducto.DataPropertyName = "NombreProducto";
            this.NombreProducto.HeaderText = "Nombre de Producto";
            this.NombreProducto.Name = "NombreProducto";
            this.NombreProducto.ReadOnly = true;
            // 
            // Presentacion
            // 
            this.Presentacion.DataPropertyName = "Presentacion";
            this.Presentacion.HeaderText = "Presentacion";
            this.Presentacion.Name = "Presentacion";
            this.Presentacion.ReadOnly = true;
            this.Presentacion.Width = 200;
            // 
            // PrecioActual
            // 
            this.PrecioActual.DataPropertyName = "PrecioActual";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.Format = "N4";
            this.PrecioActual.DefaultCellStyle = dataGridViewCellStyle1;
            this.PrecioActual.HeaderText = "Precio/Actual";
            this.PrecioActual.Name = "PrecioActual";
            this.PrecioActual.ReadOnly = true;
            // 
            // PrecioEditable
            // 
            this.PrecioEditable.DataPropertyName = "PrecioEditable";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.Format = "N4";
            this.PrecioEditable.DefaultCellStyle = dataGridViewCellStyle2;
            this.PrecioEditable.HeaderText = "Nuevo Precio";
            this.PrecioEditable.Name = "PrecioEditable";
            this.PrecioEditable.Width = 95;
            // 
            // ListaPreciosClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 573);
            this.Controls.Add(this.dgvCatalogo);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.BarraEstado);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ListaPreciosClientes";
            this.Text = "PRECIOS PARA CLIENTE";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.BarraEstado.ResumeLayout(false);
            this.BarraEstado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCatalogo)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnRecargar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox txbBuscarTexto;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.StatusStrip BarraEstado;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalDocumento;
        private System.Windows.Forms.ToolStripProgressBar BarraProgreso;
        private System.Windows.Forms.ToolStripStatusLabel lblTasa;
        private System.Windows.Forms.DataGridView dgvCatalogo;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox txbNombreCliente;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnMostrarProductos;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Presentacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioActual;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioEditable;
    }
}