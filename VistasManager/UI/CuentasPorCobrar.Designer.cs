namespace VistasManager.UI
{
    partial class CuentasPorCobrar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CuentasPorCobrar));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BarraEstado = new System.Windows.Forms.StatusStrip();
            this.lblBarraEstado = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotalSaldo = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotalAbonos = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDiferencia = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grupoCliente = new System.Windows.Forms.GroupBox();
            this.txbDuiTitular = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbGiroTitular = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txbIDTitular = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbIvaTitular = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txbNitTitular = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txbPaisTitular = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txbNombreTitular = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.IDDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreTitular = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Efectivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cambio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Saldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Abonos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnAbonos = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.txbFiltroDetalle = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnVerAbonos = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.BarraEstado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.grupoCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BarraEstado
            // 
            this.BarraEstado.AutoSize = false;
            this.BarraEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblBarraEstado,
            this.lblTotalSaldo,
            this.lblTotalAbonos,
            this.lblDiferencia});
            this.BarraEstado.Location = new System.Drawing.Point(3, 526);
            this.BarraEstado.Name = "BarraEstado";
            this.BarraEstado.Size = new System.Drawing.Size(824, 32);
            this.BarraEstado.TabIndex = 14;
            this.BarraEstado.Text = "statusStrip1";
            // 
            // lblBarraEstado
            // 
            this.lblBarraEstado.Name = "lblBarraEstado";
            this.lblBarraEstado.Size = new System.Drawing.Size(61, 27);
            this.lblBarraEstado.Text = "0 registros";
            // 
            // lblTotalSaldo
            // 
            this.lblTotalSaldo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalSaldo.Name = "lblTotalSaldo";
            this.lblTotalSaldo.Size = new System.Drawing.Size(484, 27);
            this.lblTotalSaldo.Spring = true;
            this.lblTotalSaldo.Text = "Total: 0.00";
            this.lblTotalSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalAbonos
            // 
            this.lblTotalAbonos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalAbonos.Margin = new System.Windows.Forms.Padding(25, 3, 0, 2);
            this.lblTotalAbonos.Name = "lblTotalAbonos";
            this.lblTotalAbonos.Size = new System.Drawing.Size(107, 27);
            this.lblTotalAbonos.Text = "Abonos: 0.00";
            this.lblTotalAbonos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDiferencia
            // 
            this.lblDiferencia.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblDiferencia.Margin = new System.Windows.Forms.Padding(25, 3, 0, 2);
            this.lblDiferencia.Name = "lblDiferencia";
            this.lblDiferencia.Size = new System.Drawing.Size(107, 27);
            this.lblDiferencia.Text = "a Pagar: 0.00";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.grupoCliente);
            this.splitContainer1.Panel1.Controls.Add(this.btnBuscarCliente);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvDetalle);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip2);
            this.splitContainer1.Size = new System.Drawing.Size(824, 523);
            this.splitContainer1.SplitterDistance = 223;
            this.splitContainer1.TabIndex = 15;
            // 
            // grupoCliente
            // 
            this.grupoCliente.Controls.Add(this.txbDuiTitular);
            this.grupoCliente.Controls.Add(this.label2);
            this.grupoCliente.Controls.Add(this.txbGiroTitular);
            this.grupoCliente.Controls.Add(this.label11);
            this.grupoCliente.Controls.Add(this.txbIDTitular);
            this.grupoCliente.Controls.Add(this.label3);
            this.grupoCliente.Controls.Add(this.txbIvaTitular);
            this.grupoCliente.Controls.Add(this.label12);
            this.grupoCliente.Controls.Add(this.txbNitTitular);
            this.grupoCliente.Controls.Add(this.label10);
            this.grupoCliente.Controls.Add(this.txbPaisTitular);
            this.grupoCliente.Controls.Add(this.label9);
            this.grupoCliente.Controls.Add(this.txbNombreTitular);
            this.grupoCliente.Controls.Add(this.label8);
            this.grupoCliente.Location = new System.Drawing.Point(3, 3);
            this.grupoCliente.Name = "grupoCliente";
            this.grupoCliente.Size = new System.Drawing.Size(430, 217);
            this.grupoCliente.TabIndex = 8;
            this.grupoCliente.TabStop = false;
            this.grupoCliente.Text = "DATOS DE CLIENTE";
            // 
            // txbDuiTitular
            // 
            this.txbDuiTitular.Enabled = false;
            this.txbDuiTitular.Location = new System.Drawing.Point(127, 146);
            this.txbDuiTitular.Name = "txbDuiTitular";
            this.txbDuiTitular.Size = new System.Drawing.Size(140, 20);
            this.txbDuiTitular.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 53;
            this.label2.Text = "DUI:";
            // 
            // txbGiroTitular
            // 
            this.txbGiroTitular.Enabled = false;
            this.txbGiroTitular.Location = new System.Drawing.Point(127, 172);
            this.txbGiroTitular.Name = "txbGiroTitular";
            this.txbGiroTitular.Size = new System.Drawing.Size(275, 20);
            this.txbGiroTitular.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(92, 172);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 13);
            this.label11.TabIndex = 45;
            this.label11.Text = "Giro:";
            // 
            // txbIDTitular
            // 
            this.txbIDTitular.Enabled = false;
            this.txbIDTitular.Location = new System.Drawing.Point(127, 19);
            this.txbIDTitular.Name = "txbIDTitular";
            this.txbIDTitular.Size = new System.Drawing.Size(140, 20);
            this.txbIDTitular.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 48;
            this.label3.Text = "ID. Cliente:";
            // 
            // txbIvaTitular
            // 
            this.txbIvaTitular.Enabled = false;
            this.txbIvaTitular.Location = new System.Drawing.Point(127, 120);
            this.txbIvaTitular.Name = "txbIvaTitular";
            this.txbIvaTitular.Size = new System.Drawing.Size(140, 20);
            this.txbIvaTitular.TabIndex = 7;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(52, 120);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 13);
            this.label12.TabIndex = 46;
            this.label12.Text = "Registro IVA:";
            // 
            // txbNitTitular
            // 
            this.txbNitTitular.Enabled = false;
            this.txbNitTitular.Location = new System.Drawing.Point(127, 94);
            this.txbNitTitular.Name = "txbNitTitular";
            this.txbNitTitular.Size = new System.Drawing.Size(140, 20);
            this.txbNitTitular.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(93, 94);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 13);
            this.label10.TabIndex = 44;
            this.label10.Text = "NIT:";
            // 
            // txbPaisTitular
            // 
            this.txbPaisTitular.Enabled = false;
            this.txbPaisTitular.Location = new System.Drawing.Point(127, 71);
            this.txbPaisTitular.Name = "txbPaisTitular";
            this.txbPaisTitular.Size = new System.Drawing.Size(275, 20);
            this.txbPaisTitular.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(91, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 43;
            this.label9.Text = "Pais:";
            // 
            // txbNombreTitular
            // 
            this.txbNombreTitular.Enabled = false;
            this.txbNombreTitular.Location = new System.Drawing.Point(127, 45);
            this.txbNombreTitular.Name = "txbNombreTitular";
            this.txbNombreTitular.Size = new System.Drawing.Size(275, 20);
            this.txbNombreTitular.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 13);
            this.label8.TabIndex = 42;
            this.label8.Text = "Nombre de cliente:";
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarCliente.Image")));
            this.btnBuscarCliente.Location = new System.Drawing.Point(439, 12);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(105, 30);
            this.btnBuscarCliente.TabIndex = 2;
            this.btnBuscarCliente.Text = "Buscar Cliente";
            this.btnBuscarCliente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscarCliente.UseVisualStyleBackColor = true;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.AllowUserToResizeRows = false;
            this.dgvDetalle.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDDocumento,
            this.NumeroDocumento,
            this.FechaDocumento,
            this.NombreTitular,
            this.TotalVenta,
            this.Efectivo,
            this.Cambio,
            this.Saldo,
            this.Abonos});
            this.dgvDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetalle.Location = new System.Drawing.Point(0, 32);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.RowHeadersVisible = false;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDetalle.Size = new System.Drawing.Size(824, 264);
            this.dgvDetalle.TabIndex = 17;
            this.dgvDetalle.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvDetalle_DataBindingComplete);
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
            // FechaDocumento
            // 
            this.FechaDocumento.DataPropertyName = "FechaDocumento";
            this.FechaDocumento.HeaderText = "Fecha";
            this.FechaDocumento.Name = "FechaDocumento";
            this.FechaDocumento.ReadOnly = true;
            this.FechaDocumento.Width = 80;
            // 
            // NombreTitular
            // 
            this.NombreTitular.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NombreTitular.DataPropertyName = "NombreTitular";
            this.NombreTitular.HeaderText = "Cliente";
            this.NombreTitular.MinimumWidth = 100;
            this.NombreTitular.Name = "NombreTitular";
            this.NombreTitular.ReadOnly = true;
            // 
            // TotalVenta
            // 
            this.TotalVenta.DataPropertyName = "TotalVenta";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            this.TotalVenta.DefaultCellStyle = dataGridViewCellStyle1;
            this.TotalVenta.HeaderText = "Total Venta";
            this.TotalVenta.Name = "TotalVenta";
            this.TotalVenta.ReadOnly = true;
            this.TotalVenta.Width = 80;
            // 
            // Efectivo
            // 
            this.Efectivo.DataPropertyName = "Efectivo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.Efectivo.DefaultCellStyle = dataGridViewCellStyle2;
            this.Efectivo.HeaderText = "Efectivo";
            this.Efectivo.Name = "Efectivo";
            this.Efectivo.ReadOnly = true;
            this.Efectivo.Width = 80;
            // 
            // Cambio
            // 
            this.Cambio.DataPropertyName = "Cambio";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.Cambio.DefaultCellStyle = dataGridViewCellStyle3;
            this.Cambio.HeaderText = "Cambio";
            this.Cambio.Name = "Cambio";
            this.Cambio.ReadOnly = true;
            this.Cambio.Width = 80;
            // 
            // Saldo
            // 
            this.Saldo.DataPropertyName = "Saldo";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.Saldo.DefaultCellStyle = dataGridViewCellStyle4;
            this.Saldo.HeaderText = "Saldo";
            this.Saldo.Name = "Saldo";
            this.Saldo.ReadOnly = true;
            this.Saldo.Width = 80;
            // 
            // Abonos
            // 
            this.Abonos.DataPropertyName = "Abonos";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.Abonos.DefaultCellStyle = dataGridViewCellStyle5;
            this.Abonos.HeaderText = "Abonos";
            this.Abonos.Name = "Abonos";
            this.Abonos.ReadOnly = true;
            this.Abonos.Width = 80;
            // 
            // toolStrip2
            // 
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAbonos,
            this.toolStripLabel2,
            this.txbFiltroDetalle,
            this.toolStripSeparator4,
            this.toolStripSeparator3,
            this.btnVerAbonos,
            this.toolStripButton1});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(824, 32);
            this.toolStrip2.TabIndex = 13;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnAbonos
            // 
            this.btnAbonos.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnAbonos.Image = ((System.Drawing.Image)(resources.GetObject("btnAbonos.Image")));
            this.btnAbonos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAbonos.Name = "btnAbonos";
            this.btnAbonos.Size = new System.Drawing.Size(66, 29);
            this.btnAbonos.Text = "Abonar";
            this.btnAbonos.Click += new System.EventHandler(this.btnAbonos_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripLabel2.Image")));
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(61, 29);
            this.toolStripLabel2.Text = "Buscar:";
            // 
            // txbFiltroDetalle
            // 
            this.txbFiltroDetalle.AutoSize = false;
            this.txbFiltroDetalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbFiltroDetalle.Name = "txbFiltroDetalle";
            this.txbFiltroDetalle.Size = new System.Drawing.Size(220, 23);
            this.txbFiltroDetalle.TextChanged += new System.EventHandler(this.txbFiltroDetalle_TextChanged);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 32);
            // 
            // btnVerAbonos
            // 
            this.btnVerAbonos.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnVerAbonos.Image = ((System.Drawing.Image)(resources.GetObject("btnVerAbonos.Image")));
            this.btnVerAbonos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnVerAbonos.Name = "btnVerAbonos";
            this.btnVerAbonos.Size = new System.Drawing.Size(109, 29);
            this.btnVerAbonos.Text = "Mantniemiento";
            this.btnVerAbonos.Click += new System.EventHandler(this.btnVerAbonos_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(117, 29);
            this.toolStripButton1.Text = "Estado de cuenta";
            // 
            // CuentasPorCobrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 561);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.BarraEstado);
            this.Name = "CuentasPorCobrar";
            this.Text = "CUENTAS POR COBRAR";
            this.BarraEstado.ResumeLayout(false);
            this.BarraEstado.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.grupoCliente.ResumeLayout(false);
            this.grupoCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.StatusStrip BarraEstado;
        private System.Windows.Forms.ToolStripStatusLabel lblBarraEstado;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.GroupBox grupoCliente;
        private System.Windows.Forms.TextBox txbDuiTitular;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbGiroTitular;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txbIDTitular;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbIvaTitular;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txbNitTitular;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txbPaisTitular;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txbNombreTitular;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnAbonos;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox txbFiltroDetalle;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreTitular;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Efectivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cambio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Saldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Abonos;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalAbonos;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalSaldo;
        private System.Windows.Forms.ToolStripStatusLabel lblDiferencia;
        private System.Windows.Forms.ToolStripButton btnVerAbonos;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}