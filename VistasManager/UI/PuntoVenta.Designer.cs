namespace VistasManager.UI
{
    partial class PuntoVenta
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PuntoVenta));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvDocumentos = new System.Windows.Forms.DataGridView();
            this.IDDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Items = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BarraEstatusDocumentos = new System.Windows.Forms.StatusStrip();
            this.lblConteoDocumentos = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnRecargar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txbBuscarTexto = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnAgregarItem = new System.Windows.Forms.Button();
            this.txbCantidad = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txbNombreProducto = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.btnBuscarProducto = new System.Windows.Forms.Button();
            this.txbCodigoProducto = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.IDProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioSalida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadSalida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnFinalizarVenta = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEliminarItem = new System.Windows.Forms.ToolStripButton();
            this.lblItemsVendidos = new System.Windows.Forms.ToolStripLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblTotalVenta = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txbTotalDescuento = new System.Windows.Forms.TextBox();
            this.txbSubTotal = new System.Windows.Forms.TextBox();
            this.txbTotalIVA = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txbTotalGravado = new System.Windows.Forms.TextBox();
            this.txbTotalExcento = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumentos)).BeginInit();
            this.BarraEstatusDocumentos.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvDocumentos);
            this.splitContainer1.Panel1.Controls.Add(this.BarraEstatusDocumentos);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(965, 643);
            this.splitContainer1.SplitterDistance = 398;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 0;
            // 
            // dgvDocumentos
            // 
            this.dgvDocumentos.AllowUserToAddRows = false;
            this.dgvDocumentos.AllowUserToDeleteRows = false;
            this.dgvDocumentos.AllowUserToResizeRows = false;
            this.dgvDocumentos.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dgvDocumentos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDocumentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocumentos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDDocumento,
            this.NumeroDocumento,
            this.Documento,
            this.Items,
            this.Total});
            this.dgvDocumentos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocumentos.Location = new System.Drawing.Point(0, 32);
            this.dgvDocumentos.Name = "dgvDocumentos";
            this.dgvDocumentos.ReadOnly = true;
            this.dgvDocumentos.RowHeadersVisible = false;
            this.dgvDocumentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocumentos.Size = new System.Drawing.Size(398, 579);
            this.dgvDocumentos.TabIndex = 15;
            this.dgvDocumentos.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvDocumentos_DataBindingComplete);
            // 
            // IDDocumento
            // 
            this.IDDocumento.DataPropertyName = "IDDocumento";
            this.IDDocumento.HeaderText = "ID.";
            this.IDDocumento.Name = "IDDocumento";
            this.IDDocumento.ReadOnly = true;
            this.IDDocumento.Width = 60;
            // 
            // NumeroDocumento
            // 
            this.NumeroDocumento.DataPropertyName = "NumeroDocumento";
            this.NumeroDocumento.HeaderText = "Numero";
            this.NumeroDocumento.Name = "NumeroDocumento";
            this.NumeroDocumento.ReadOnly = true;
            this.NumeroDocumento.Width = 80;
            // 
            // Documento
            // 
            this.Documento.DataPropertyName = "Documento";
            this.Documento.HeaderText = "Documento";
            this.Documento.Name = "Documento";
            this.Documento.ReadOnly = true;
            this.Documento.Width = 120;
            // 
            // Items
            // 
            this.Items.DataPropertyName = "Items";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Items.DefaultCellStyle = dataGridViewCellStyle1;
            this.Items.HeaderText = "Items";
            this.Items.Name = "Items";
            this.Items.ReadOnly = true;
            this.Items.Width = 60;
            // 
            // Total
            // 
            this.Total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Total.DataPropertyName = "Total";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.Total.DefaultCellStyle = dataGridViewCellStyle2;
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // BarraEstatusDocumentos
            // 
            this.BarraEstatusDocumentos.AutoSize = false;
            this.BarraEstatusDocumentos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblConteoDocumentos});
            this.BarraEstatusDocumentos.Location = new System.Drawing.Point(0, 611);
            this.BarraEstatusDocumentos.Name = "BarraEstatusDocumentos";
            this.BarraEstatusDocumentos.Size = new System.Drawing.Size(398, 32);
            this.BarraEstatusDocumentos.SizingGrip = false;
            this.BarraEstatusDocumentos.TabIndex = 0;
            this.BarraEstatusDocumentos.Text = "statusStrip1";
            // 
            // lblConteoDocumentos
            // 
            this.lblConteoDocumentos.Image = ((System.Drawing.Image)(resources.GetObject("lblConteoDocumentos.Image")));
            this.lblConteoDocumentos.Name = "lblConteoDocumentos";
            this.lblConteoDocumentos.Size = new System.Drawing.Size(99, 27);
            this.lblConteoDocumentos.Text = "0 documentos";
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
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(398, 32);
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
            this.txbBuscarTexto.Size = new System.Drawing.Size(100, 23);
            this.txbBuscarTexto.TextChanged += new System.EventHandler(this.txbBuscarTexto_TextChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(73, 29);
            this.toolStripButton1.Text = "Imprimir";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.IsSplitterFixed = true;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.groupBox4);
            this.splitContainer3.Panel1.Padding = new System.Windows.Forms.Padding(5);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer3.Size = new System.Drawing.Size(559, 643);
            this.splitContainer3.SplitterDistance = 126;
            this.splitContainer3.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnAgregarItem);
            this.groupBox4.Controls.Add(this.txbCantidad);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.txbNombreProducto);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.btnBuscarProducto);
            this.groupBox4.Controls.Add(this.txbCodigoProducto);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(5, 5);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(549, 116);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "ENTRADA DE PRODUCTOS";
            // 
            // btnAgregarItem
            // 
            this.btnAgregarItem.BackColor = System.Drawing.SystemColors.Control;
            this.btnAgregarItem.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarItem.Image")));
            this.btnAgregarItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarItem.Location = new System.Drawing.Point(426, 74);
            this.btnAgregarItem.Name = "btnAgregarItem";
            this.btnAgregarItem.Size = new System.Drawing.Size(114, 36);
            this.btnAgregarItem.TabIndex = 16;
            this.btnAgregarItem.Text = "Agregar Item";
            this.btnAgregarItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregarItem.UseVisualStyleBackColor = false;
            this.btnAgregarItem.Click += new System.EventHandler(this.btnAgregarItem_Click);
            // 
            // txbCantidad
            // 
            this.txbCantidad.Enabled = false;
            this.txbCantidad.Location = new System.Drawing.Point(333, 82);
            this.txbCantidad.Name = "txbCantidad";
            this.txbCantidad.Size = new System.Drawing.Size(73, 20);
            this.txbCantidad.TabIndex = 15;
            this.txbCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txbCantidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbCantidad_KeyDown);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(330, 66);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(52, 13);
            this.label20.TabIndex = 14;
            this.label20.Text = "Cantidad:";
            // 
            // txbNombreProducto
            // 
            this.txbNombreProducto.Enabled = false;
            this.txbNombreProducto.Location = new System.Drawing.Point(9, 82);
            this.txbNombreProducto.Name = "txbNombreProducto";
            this.txbNombreProducto.Size = new System.Drawing.Size(318, 20);
            this.txbNombreProducto.TabIndex = 11;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(10, 66);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(107, 13);
            this.label18.TabIndex = 10;
            this.label18.Text = "Nombre de producto:";
            // 
            // btnBuscarProducto
            // 
            this.btnBuscarProducto.BackColor = System.Drawing.SystemColors.Control;
            this.btnBuscarProducto.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarProducto.Image")));
            this.btnBuscarProducto.Location = new System.Drawing.Point(237, 33);
            this.btnBuscarProducto.Name = "btnBuscarProducto";
            this.btnBuscarProducto.Size = new System.Drawing.Size(90, 36);
            this.btnBuscarProducto.TabIndex = 9;
            this.btnBuscarProducto.Text = "Productos";
            this.btnBuscarProducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscarProducto.UseVisualStyleBackColor = false;
            this.btnBuscarProducto.Click += new System.EventHandler(this.btnBuscarProducto_Click);
            // 
            // txbCodigoProducto
            // 
            this.txbCodigoProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbCodigoProducto.Location = new System.Drawing.Point(9, 37);
            this.txbCodigoProducto.Name = "txbCodigoProducto";
            this.txbCodigoProducto.Size = new System.Drawing.Size(206, 26);
            this.txbCodigoProducto.TabIndex = 8;
            this.txbCodigoProducto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbCodigoProducto_KeyDown);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(10, 21);
            this.label19.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(103, 13);
            this.label19.TabIndex = 7;
            this.label19.Text = "Codigo de producto:";
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer4.IsSplitterFixed = true;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.dgvDetalle);
            this.splitContainer4.Panel1.Controls.Add(this.toolStrip2);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer4.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainer4.Size = new System.Drawing.Size(559, 513);
            this.splitContainer4.SplitterDistance = 345;
            this.splitContainer4.TabIndex = 0;
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.AllowUserToResizeRows = false;
            this.dgvDetalle.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDProducto,
            this.CodigoProducto,
            this.NombreProducto,
            this.PrecioSalida,
            this.CantidadSalida,
            this.TotalVenta});
            this.dgvDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalle.Location = new System.Drawing.Point(0, 32);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.RowHeadersVisible = false;
            this.dgvDetalle.Size = new System.Drawing.Size(559, 313);
            this.dgvDetalle.TabIndex = 10;
            this.dgvDetalle.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvDetalle_DataBindingComplete);
            // 
            // IDProducto
            // 
            this.IDProducto.DataPropertyName = "IDProducto";
            this.IDProducto.HeaderText = "ID. Prod.";
            this.IDProducto.Name = "IDProducto";
            this.IDProducto.ReadOnly = true;
            this.IDProducto.Visible = false;
            this.IDProducto.Width = 80;
            // 
            // CodigoProducto
            // 
            this.CodigoProducto.DataPropertyName = "CodigoProducto";
            this.CodigoProducto.HeaderText = "Codigo";
            this.CodigoProducto.Name = "CodigoProducto";
            this.CodigoProducto.ReadOnly = true;
            this.CodigoProducto.Width = 120;
            // 
            // NombreProducto
            // 
            this.NombreProducto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NombreProducto.DataPropertyName = "NombreProducto";
            this.NombreProducto.HeaderText = "Producto";
            this.NombreProducto.Name = "NombreProducto";
            this.NombreProducto.ReadOnly = true;
            // 
            // PrecioSalida
            // 
            this.PrecioSalida.DataPropertyName = "Precio";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N4";
            dataGridViewCellStyle3.NullValue = null;
            this.PrecioSalida.DefaultCellStyle = dataGridViewCellStyle3;
            this.PrecioSalida.HeaderText = "Precio";
            this.PrecioSalida.Name = "PrecioSalida";
            this.PrecioSalida.ReadOnly = true;
            this.PrecioSalida.Width = 60;
            // 
            // CantidadSalida
            // 
            this.CantidadSalida.DataPropertyName = "Cantidad";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.CantidadSalida.DefaultCellStyle = dataGridViewCellStyle4;
            this.CantidadSalida.HeaderText = "Cantidad";
            this.CantidadSalida.Name = "CantidadSalida";
            this.CantidadSalida.Width = 60;
            // 
            // TotalVenta
            // 
            this.TotalVenta.DataPropertyName = "Total";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.TotalVenta.DefaultCellStyle = dataGridViewCellStyle5;
            this.TotalVenta.HeaderText = "Total";
            this.TotalVenta.Name = "TotalVenta";
            this.TotalVenta.ReadOnly = true;
            this.TotalVenta.Width = 60;
            // 
            // toolStrip2
            // 
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFinalizarVenta,
            this.toolStripSeparator3,
            this.btnEliminarItem,
            this.lblItemsVendidos});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(559, 32);
            this.toolStrip2.TabIndex = 9;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnFinalizarVenta
            // 
            this.btnFinalizarVenta.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnFinalizarVenta.Image = ((System.Drawing.Image)(resources.GetObject("btnFinalizarVenta.Image")));
            this.btnFinalizarVenta.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFinalizarVenta.Margin = new System.Windows.Forms.Padding(3, 1, 0, 2);
            this.btnFinalizarVenta.Name = "btnFinalizarVenta";
            this.btnFinalizarVenta.Size = new System.Drawing.Size(102, 29);
            this.btnFinalizarVenta.Text = "Finalizar venta";
            this.btnFinalizarVenta.Click += new System.EventHandler(this.btnFinalizarVenta_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 32);
            // 
            // btnEliminarItem
            // 
            this.btnEliminarItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnEliminarItem.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminarItem.Image")));
            this.btnEliminarItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminarItem.Margin = new System.Windows.Forms.Padding(0, 3, 0, 2);
            this.btnEliminarItem.Name = "btnEliminarItem";
            this.btnEliminarItem.Size = new System.Drawing.Size(97, 27);
            this.btnEliminarItem.Text = "Eliminar item";
            this.btnEliminarItem.Click += new System.EventHandler(this.btnEliminarItem_Click);
            // 
            // lblItemsVendidos
            // 
            this.lblItemsVendidos.Name = "lblItemsVendidos";
            this.lblItemsVendidos.Size = new System.Drawing.Size(99, 29);
            this.lblItemsVendidos.Text = "Items vendidos: 0";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblTotalVenta);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.txbTotalDescuento);
            this.groupBox3.Controls.Add(this.txbSubTotal);
            this.groupBox3.Controls.Add(this.txbTotalIVA);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.txbTotalGravado);
            this.groupBox3.Controls.Add(this.txbTotalExcento);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox3.Location = new System.Drawing.Point(214, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(340, 154);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "SUMAS";
            // 
            // lblTotalVenta
            // 
            this.lblTotalVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalVenta.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalVenta.ForeColor = System.Drawing.Color.Green;
            this.lblTotalVenta.Location = new System.Drawing.Point(202, 32);
            this.lblTotalVenta.Name = "lblTotalVenta";
            this.lblTotalVenta.Size = new System.Drawing.Size(129, 40);
            this.lblTotalVenta.TabIndex = 2;
            this.lblTotalVenta.Text = "0.00";
            this.lblTotalVenta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(266, 16);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 13);
            this.label16.TabIndex = 11;
            this.label16.Text = "Total Venta:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(42, 110);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(62, 13);
            this.label15.TabIndex = 9;
            this.label15.Text = "Descuento:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(48, 84);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 13);
            this.label14.TabIndex = 8;
            this.label14.Text = "Sub-Total:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(77, 58);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(27, 13);
            this.label13.TabIndex = 7;
            this.label13.Text = "IVA:";
            // 
            // txbTotalDescuento
            // 
            this.txbTotalDescuento.Enabled = false;
            this.txbTotalDescuento.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTotalDescuento.Location = new System.Drawing.Point(110, 110);
            this.txbTotalDescuento.Name = "txbTotalDescuento";
            this.txbTotalDescuento.Size = new System.Drawing.Size(80, 22);
            this.txbTotalDescuento.TabIndex = 6;
            this.txbTotalDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txbSubTotal
            // 
            this.txbSubTotal.Enabled = false;
            this.txbSubTotal.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbSubTotal.Location = new System.Drawing.Point(110, 84);
            this.txbSubTotal.Name = "txbSubTotal";
            this.txbSubTotal.Size = new System.Drawing.Size(80, 22);
            this.txbSubTotal.TabIndex = 5;
            this.txbSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txbTotalIVA
            // 
            this.txbTotalIVA.Enabled = false;
            this.txbTotalIVA.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTotalIVA.Location = new System.Drawing.Point(110, 58);
            this.txbTotalIVA.Name = "txbTotalIVA";
            this.txbTotalIVA.Size = new System.Drawing.Size(80, 22);
            this.txbTotalIVA.TabIndex = 4;
            this.txbTotalIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(107, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "Excento:";
            // 
            // txbTotalGravado
            // 
            this.txbTotalGravado.Enabled = false;
            this.txbTotalGravado.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTotalGravado.Location = new System.Drawing.Point(24, 32);
            this.txbTotalGravado.Name = "txbTotalGravado";
            this.txbTotalGravado.Size = new System.Drawing.Size(80, 22);
            this.txbTotalGravado.TabIndex = 2;
            this.txbTotalGravado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txbTotalExcento
            // 
            this.txbTotalExcento.Enabled = false;
            this.txbTotalExcento.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTotalExcento.Location = new System.Drawing.Point(110, 32);
            this.txbTotalExcento.Name = "txbTotalExcento";
            this.txbTotalExcento.Size = new System.Drawing.Size(80, 22);
            this.txbTotalExcento.TabIndex = 1;
            this.txbTotalExcento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(21, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Gravado:";
            // 
            // PuntoVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 649);
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.Name = "PuntoVenta";
            this.Text = "PUNTO DE VENTA";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PuntoVenta_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumentos)).EndInit();
            this.BarraEstatusDocumentos.ResumeLayout(false);
            this.BarraEstatusDocumentos.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnRecargar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox txbBuscarTexto;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.StatusStrip BarraEstatusDocumentos;
        private System.Windows.Forms.ToolStripStatusLabel lblConteoDocumentos;
        private System.Windows.Forms.DataGridView dgvDocumentos;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Documento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Items;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnFinalizarVenta;
        private System.Windows.Forms.ToolStripButton btnEliminarItem;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnAgregarItem;
        private System.Windows.Forms.TextBox txbCantidad;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txbNombreProducto;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button btnBuscarProducto;
        private System.Windows.Forms.TextBox txbCodigoProducto;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblTotalVenta;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txbTotalDescuento;
        private System.Windows.Forms.TextBox txbSubTotal;
        private System.Windows.Forms.TextBox txbTotalIVA;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txbTotalGravado;
        private System.Windows.Forms.TextBox txbTotalExcento;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ToolStripLabel lblItemsVendidos;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioSalida;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadSalida;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalVenta;
    }
}