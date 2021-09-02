namespace VistasManager.UI
{
    partial class DocumentosTrasladosEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocumentosTrasladosEditor));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnCancelar = new System.Windows.Forms.ToolStripButton();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.btnRecargar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txbBuscarTexto = new System.Windows.Forms.ToolStripTextBox();
            this.BarraEstado = new System.Windows.Forms.StatusStrip();
            this.lblBarraEstado = new System.Windows.Forms.ToolStripStatusLabel();
            this.BarraProgreso = new System.Windows.Forms.ToolStripProgressBar();
            this.lblTotalDocumento = new System.Windows.Forms.ToolStripStatusLabel();
            this.dgvCatalogo = new System.Windows.Forms.DataGridView();
            this.IDProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subcategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormatoVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Existencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioSalida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.cbbBodegas = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.cbbBodegaDestino = new System.Windows.Forms.ToolStripComboBox();
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
            this.btnCancelar,
            this.btnGuardar,
            this.btnRecargar,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.txbBuscarTexto});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(999, 32);
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
            this.txbBuscarTexto.Size = new System.Drawing.Size(180, 23);
            this.txbBuscarTexto.TextChanged += new System.EventHandler(this.txbBuscarTexto_TextChanged);
            // 
            // BarraEstado
            // 
            this.BarraEstado.AutoSize = false;
            this.BarraEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblBarraEstado,
            this.BarraProgreso,
            this.lblTotalDocumento});
            this.BarraEstado.Location = new System.Drawing.Point(3, 596);
            this.BarraEstado.Name = "BarraEstado";
            this.BarraEstado.Size = new System.Drawing.Size(999, 32);
            this.BarraEstado.TabIndex = 14;
            this.BarraEstado.Text = "statusStrip1";
            // 
            // lblBarraEstado
            // 
            this.lblBarraEstado.Name = "lblBarraEstado";
            this.lblBarraEstado.Size = new System.Drawing.Size(492, 27);
            this.lblBarraEstado.Spring = true;
            this.lblBarraEstado.Text = "0 registros";
            this.lblBarraEstado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BarraProgreso
            // 
            this.BarraProgreso.Name = "BarraProgreso";
            this.BarraProgreso.Size = new System.Drawing.Size(200, 26);
            this.BarraProgreso.Visible = false;
            // 
            // lblTotalDocumento
            // 
            this.lblTotalDocumento.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalDocumento.Name = "lblTotalDocumento";
            this.lblTotalDocumento.Size = new System.Drawing.Size(492, 27);
            this.lblTotalDocumento.Spring = true;
            this.lblTotalDocumento.Text = "Total: $0.00";
            this.lblTotalDocumento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.Categoria,
            this.Subcategoria,
            this.FormatoVenta,
            this.Existencia,
            this.Cantidad,
            this.PrecioSalida,
            this.Total});
            this.dgvCatalogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCatalogo.Location = new System.Drawing.Point(3, 67);
            this.dgvCatalogo.MultiSelect = false;
            this.dgvCatalogo.Name = "dgvCatalogo";
            this.dgvCatalogo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvCatalogo.Size = new System.Drawing.Size(999, 529);
            this.dgvCatalogo.TabIndex = 15;
            this.dgvCatalogo.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCatalogo_CellEndEdit);
            this.dgvCatalogo.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvCatalogo_CellValidating);
            this.dgvCatalogo.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvCatalogo_CurrentCellDirtyStateChanged);
            this.dgvCatalogo.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvCatalogo_DataBindingComplete);
            // 
            // IDProducto
            // 
            this.IDProducto.DataPropertyName = "IDProducto";
            this.IDProducto.HeaderText = "ID. Producto";
            this.IDProducto.Name = "IDProducto";
            this.IDProducto.ReadOnly = true;
            this.IDProducto.Visible = false;
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
            this.NombreProducto.HeaderText = "Nombre de producto";
            this.NombreProducto.Name = "NombreProducto";
            this.NombreProducto.ReadOnly = true;
            // 
            // Categoria
            // 
            this.Categoria.DataPropertyName = "Categoria";
            this.Categoria.HeaderText = "Categoria";
            this.Categoria.Name = "Categoria";
            this.Categoria.ReadOnly = true;
            // 
            // Subcategoria
            // 
            this.Subcategoria.DataPropertyName = "Subcategoria";
            this.Subcategoria.HeaderText = "Subcategoria";
            this.Subcategoria.Name = "Subcategoria";
            this.Subcategoria.ReadOnly = true;
            // 
            // FormatoVenta
            // 
            this.FormatoVenta.DataPropertyName = "FormatoVenta";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FormatoVenta.DefaultCellStyle = dataGridViewCellStyle1;
            this.FormatoVenta.HeaderText = "Sugerido";
            this.FormatoVenta.Name = "FormatoVenta";
            this.FormatoVenta.Width = 80;
            // 
            // Existencia
            // 
            this.Existencia.DataPropertyName = "Existencia";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Existencia.DefaultCellStyle = dataGridViewCellStyle2;
            this.Existencia.HeaderText = "Existencia";
            this.Existencia.Name = "Existencia";
            this.Existencia.ReadOnly = true;
            this.Existencia.Width = 60;
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "Cantidad";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Cantidad.DefaultCellStyle = dataGridViewCellStyle3;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.Width = 80;
            // 
            // PrecioSalida
            // 
            this.PrecioSalida.DataPropertyName = "PrecioSalida";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.PrecioSalida.DefaultCellStyle = dataGridViewCellStyle4;
            this.PrecioSalida.HeaderText = "Precio";
            this.PrecioSalida.Name = "PrecioSalida";
            this.PrecioSalida.Width = 80;
            // 
            // Total
            // 
            this.Total.DataPropertyName = "Total";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.Total.DefaultCellStyle = dataGridViewCellStyle5;
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            this.Total.Width = 80;
            // 
            // toolStrip2
            // 
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.cbbBodegas,
            this.toolStripLabel3,
            this.cbbBodegaDestino});
            this.toolStrip2.Location = new System.Drawing.Point(3, 35);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(999, 32);
            this.toolStrip2.TabIndex = 16;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripLabel2.Image")));
            this.toolStripLabel2.Margin = new System.Windows.Forms.Padding(6, 1, 0, 2);
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(105, 29);
            this.toolStripLabel2.Text = "Bodega Origen:";
            // 
            // cbbBodegas
            // 
            this.cbbBodegas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbBodegas.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbbBodegas.Name = "cbbBodegas";
            this.cbbBodegas.Size = new System.Drawing.Size(180, 32);
            this.cbbBodegas.SelectedIndexChanged += new System.EventHandler(this.cbbBodegas_SelectedIndexChanged);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripLabel3.Image")));
            this.toolStripLabel3.Margin = new System.Windows.Forms.Padding(6, 1, 0, 2);
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(109, 29);
            this.toolStripLabel3.Text = "Bodega Destino:";
            // 
            // cbbBodegaDestino
            // 
            this.cbbBodegaDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbBodegaDestino.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbbBodegaDestino.Name = "cbbBodegaDestino";
            this.cbbBodegaDestino.Size = new System.Drawing.Size(180, 32);
            // 
            // DocumentosTrasladosEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 631);
            this.Controls.Add(this.dgvCatalogo);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.BarraEstado);
            this.Controls.Add(this.toolStrip1);
            this.Name = "DocumentosTrasladosEditor";
            this.Text = "EDITOR DE DOCUMENTOS DE TRASLADOS";
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
        private System.Windows.Forms.ToolStripButton btnCancelar;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.StatusStrip BarraEstado;
        private System.Windows.Forms.ToolStripStatusLabel lblBarraEstado;
        private System.Windows.Forms.ToolStripButton btnRecargar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox txbBuscarTexto;
        private System.Windows.Forms.DataGridView dgvCatalogo;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalDocumento;
        private System.Windows.Forms.ToolStripProgressBar BarraProgreso;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox cbbBodegas;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subcategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormatoVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Existencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioSalida;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripComboBox cbbBodegaDestino;
    }
}