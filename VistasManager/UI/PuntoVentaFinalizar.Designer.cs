namespace VistasManager.UI
{
    partial class PuntoVentaFinalizar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PuntoVentaFinalizar));
            this.grupoCliente = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txbDuiTitular = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txbGiroTitular = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txbIDTitular = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txbIvaTitular = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txbNitTitular = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txbPaisTitular = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txbNombreTitular = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnBuscarPersona = new System.Windows.Forms.Button();
            this.txbFiltroTitular = new System.Windows.Forms.TextBox();
            this.grupoDocumento = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txbCambio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbEfectivo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbTotalDocu = new System.Windows.Forms.TextBox();
            this.txbPlazoDocu = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.cbbFormaPagoDocu = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpFechaDocu = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.txbNumeroDocu = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCancelar = new System.Windows.Forms.ToolStripButton();
            this.grupoCliente.SuspendLayout();
            this.grupoDocumento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txbPlazoDocu)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grupoCliente
            // 
            this.grupoCliente.Controls.Add(this.label14);
            this.grupoCliente.Controls.Add(this.txbDuiTitular);
            this.grupoCliente.Controls.Add(this.label1);
            this.grupoCliente.Controls.Add(this.txbGiroTitular);
            this.grupoCliente.Controls.Add(this.label11);
            this.grupoCliente.Controls.Add(this.txbIDTitular);
            this.grupoCliente.Controls.Add(this.label20);
            this.grupoCliente.Controls.Add(this.txbIvaTitular);
            this.grupoCliente.Controls.Add(this.label12);
            this.grupoCliente.Controls.Add(this.txbNitTitular);
            this.grupoCliente.Controls.Add(this.label10);
            this.grupoCliente.Controls.Add(this.txbPaisTitular);
            this.grupoCliente.Controls.Add(this.label9);
            this.grupoCliente.Controls.Add(this.txbNombreTitular);
            this.grupoCliente.Controls.Add(this.label8);
            this.grupoCliente.Controls.Add(this.btnBuscarPersona);
            this.grupoCliente.Controls.Add(this.txbFiltroTitular);
            this.grupoCliente.Location = new System.Drawing.Point(6, 6);
            this.grupoCliente.Name = "grupoCliente";
            this.grupoCliente.Size = new System.Drawing.Size(297, 312);
            this.grupoCliente.TabIndex = 6;
            this.grupoCliente.TabStop = false;
            this.grupoCliente.Text = "Datos del Cliente";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(16, 24);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(109, 13);
            this.label14.TabIndex = 54;
            this.label14.Text = "Buscar (NIT,IVA,DUI)";
            // 
            // txbDuiTitular
            // 
            this.txbDuiTitular.Enabled = false;
            this.txbDuiTitular.Location = new System.Drawing.Point(15, 236);
            this.txbDuiTitular.Name = "txbDuiTitular";
            this.txbDuiTitular.Size = new System.Drawing.Size(129, 20);
            this.txbDuiTitular.TabIndex = 10;
            this.txbDuiTitular.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbDuiTitular_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 220);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 53;
            this.label1.Text = "DUI:";
            // 
            // txbGiroTitular
            // 
            this.txbGiroTitular.Enabled = false;
            this.txbGiroTitular.Location = new System.Drawing.Point(15, 275);
            this.txbGiroTitular.Name = "txbGiroTitular";
            this.txbGiroTitular.Size = new System.Drawing.Size(264, 20);
            this.txbGiroTitular.TabIndex = 9;
            this.txbGiroTitular.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbGiroTitular_KeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 259);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 13);
            this.label11.TabIndex = 45;
            this.label11.Text = "Giro:";
            // 
            // txbIDTitular
            // 
            this.txbIDTitular.Enabled = false;
            this.txbIDTitular.Location = new System.Drawing.Point(15, 80);
            this.txbIDTitular.Name = "txbIDTitular";
            this.txbIDTitular.Size = new System.Drawing.Size(126, 20);
            this.txbIDTitular.TabIndex = 4;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(15, 64);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(76, 13);
            this.label20.TabIndex = 48;
            this.label20.Text = "ID. Proveedor:";
            // 
            // txbIvaTitular
            // 
            this.txbIvaTitular.Enabled = false;
            this.txbIvaTitular.Location = new System.Drawing.Point(150, 197);
            this.txbIvaTitular.Name = "txbIvaTitular";
            this.txbIvaTitular.Size = new System.Drawing.Size(129, 20);
            this.txbIvaTitular.TabIndex = 8;
            this.txbIvaTitular.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbIvaTitular_KeyDown);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(152, 181);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 13);
            this.label12.TabIndex = 46;
            this.label12.Text = "Registro IVA:";
            // 
            // txbNitTitular
            // 
            this.txbNitTitular.Enabled = false;
            this.txbNitTitular.Location = new System.Drawing.Point(15, 197);
            this.txbNitTitular.Name = "txbNitTitular";
            this.txbNitTitular.Size = new System.Drawing.Size(129, 20);
            this.txbNitTitular.TabIndex = 7;
            this.txbNitTitular.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbNitTitular_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 181);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 13);
            this.label10.TabIndex = 44;
            this.label10.Text = "NIT:";
            // 
            // txbPaisTitular
            // 
            this.txbPaisTitular.Enabled = false;
            this.txbPaisTitular.Location = new System.Drawing.Point(15, 158);
            this.txbPaisTitular.Name = "txbPaisTitular";
            this.txbPaisTitular.Size = new System.Drawing.Size(264, 20);
            this.txbPaisTitular.TabIndex = 6;
            this.txbPaisTitular.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbPaisTitular_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 142);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 43;
            this.label9.Text = "Pais:";
            // 
            // txbNombreTitular
            // 
            this.txbNombreTitular.Enabled = false;
            this.txbNombreTitular.Location = new System.Drawing.Point(15, 119);
            this.txbNombreTitular.Name = "txbNombreTitular";
            this.txbNombreTitular.Size = new System.Drawing.Size(264, 20);
            this.txbNombreTitular.TabIndex = 5;
            this.txbNombreTitular.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbNombreTitular_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 103);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 13);
            this.label8.TabIndex = 42;
            this.label8.Text = "Nombre de proveedor:";
            // 
            // btnBuscarPersona
            // 
            this.btnBuscarPersona.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarPersona.Image")));
            this.btnBuscarPersona.Location = new System.Drawing.Point(174, 31);
            this.btnBuscarPersona.Name = "btnBuscarPersona";
            this.btnBuscarPersona.Size = new System.Drawing.Size(75, 36);
            this.btnBuscarPersona.TabIndex = 11;
            this.btnBuscarPersona.Text = "Busar";
            this.btnBuscarPersona.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscarPersona.UseVisualStyleBackColor = true;
            this.btnBuscarPersona.Click += new System.EventHandler(this.btnBuscarPersona_Click);
            // 
            // txbFiltroTitular
            // 
            this.txbFiltroTitular.Location = new System.Drawing.Point(15, 40);
            this.txbFiltroTitular.Name = "txbFiltroTitular";
            this.txbFiltroTitular.Size = new System.Drawing.Size(153, 20);
            this.txbFiltroTitular.TabIndex = 0;
            this.txbFiltroTitular.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbFiltroTitular_KeyDown);
            // 
            // grupoDocumento
            // 
            this.grupoDocumento.Controls.Add(this.label13);
            this.grupoDocumento.Controls.Add(this.txbCambio);
            this.grupoDocumento.Controls.Add(this.label2);
            this.grupoDocumento.Controls.Add(this.txbEfectivo);
            this.grupoDocumento.Controls.Add(this.label3);
            this.grupoDocumento.Controls.Add(this.txbTotalDocu);
            this.grupoDocumento.Controls.Add(this.txbPlazoDocu);
            this.grupoDocumento.Controls.Add(this.label4);
            this.grupoDocumento.Controls.Add(this.cbbFormaPagoDocu);
            this.grupoDocumento.Controls.Add(this.label5);
            this.grupoDocumento.Controls.Add(this.dtpFechaDocu);
            this.grupoDocumento.Controls.Add(this.label6);
            this.grupoDocumento.Controls.Add(this.txbNumeroDocu);
            this.grupoDocumento.Controls.Add(this.label7);
            this.grupoDocumento.Location = new System.Drawing.Point(309, 6);
            this.grupoDocumento.Name = "grupoDocumento";
            this.grupoDocumento.Size = new System.Drawing.Size(281, 194);
            this.grupoDocumento.TabIndex = 7;
            this.grupoDocumento.TabStop = false;
            this.grupoDocumento.Text = "Documento";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(159, 128);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(45, 13);
            this.label13.TabIndex = 13;
            this.label13.Text = "Cambio:";
            // 
            // txbCambio
            // 
            this.txbCambio.Enabled = false;
            this.txbCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbCambio.Location = new System.Drawing.Point(158, 144);
            this.txbCambio.Name = "txbCambio";
            this.txbCambio.Size = new System.Drawing.Size(100, 31);
            this.txbCambio.TabIndex = 12;
            this.txbCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(159, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Efectivo:";
            // 
            // txbEfectivo
            // 
            this.txbEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbEfectivo.Location = new System.Drawing.Point(158, 87);
            this.txbEfectivo.Name = "txbEfectivo";
            this.txbEfectivo.Size = new System.Drawing.Size(100, 31);
            this.txbEfectivo.TabIndex = 10;
            this.txbEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txbEfectivo.TextChanged += new System.EventHandler(this.txbEfectivo_TextChanged);
            this.txbEfectivo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbEfectivo_KeyDown);
            this.txbEfectivo.Validating += new System.ComponentModel.CancelEventHandler(this.txbEfectivo_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(159, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Total venta:";
            // 
            // txbTotalDocu
            // 
            this.txbTotalDocu.Enabled = false;
            this.txbTotalDocu.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTotalDocu.Location = new System.Drawing.Point(158, 37);
            this.txbTotalDocu.Name = "txbTotalDocu";
            this.txbTotalDocu.Size = new System.Drawing.Size(100, 31);
            this.txbTotalDocu.TabIndex = 8;
            this.txbTotalDocu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txbPlazoDocu
            // 
            this.txbPlazoDocu.Location = new System.Drawing.Point(16, 155);
            this.txbPlazoDocu.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.txbPlazoDocu.Name = "txbPlazoDocu";
            this.txbPlazoDocu.Size = new System.Drawing.Size(100, 20);
            this.txbPlazoDocu.TabIndex = 7;
            this.txbPlazoDocu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Plazo (dias):";
            // 
            // cbbFormaPagoDocu
            // 
            this.cbbFormaPagoDocu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbFormaPagoDocu.FormattingEnabled = true;
            this.cbbFormaPagoDocu.Items.AddRange(new object[] {
            "CONTADO",
            "CREDITO"});
            this.cbbFormaPagoDocu.Location = new System.Drawing.Point(16, 115);
            this.cbbFormaPagoDocu.Name = "cbbFormaPagoDocu";
            this.cbbFormaPagoDocu.Size = new System.Drawing.Size(100, 21);
            this.cbbFormaPagoDocu.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Forma de pago:";
            // 
            // dtpFechaDocu
            // 
            this.dtpFechaDocu.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDocu.Location = new System.Drawing.Point(16, 76);
            this.dtpFechaDocu.Name = "dtpFechaDocu";
            this.dtpFechaDocu.Size = new System.Drawing.Size(100, 20);
            this.dtpFechaDocu.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Fecha:";
            // 
            // txbNumeroDocu
            // 
            this.txbNumeroDocu.Enabled = false;
            this.txbNumeroDocu.Location = new System.Drawing.Point(16, 39);
            this.txbNumeroDocu.Name = "txbNumeroDocu";
            this.txbNumeroDocu.Size = new System.Drawing.Size(100, 20);
            this.txbNumeroDocu.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "No. Documento:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGuardar,
            this.toolStripSeparator1,
            this.btnCancelar});
            this.toolStrip1.Location = new System.Drawing.Point(3, 329);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(590, 32);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 32);
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
            // PuntoVentaFinalizar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 364);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.grupoDocumento);
            this.Controls.Add(this.grupoCliente);
            this.Name = "PuntoVentaFinalizar";
            this.Text = "FINALIZAR VENTA";
            this.grupoCliente.ResumeLayout(false);
            this.grupoCliente.PerformLayout();
            this.grupoDocumento.ResumeLayout(false);
            this.grupoDocumento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txbPlazoDocu)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grupoCliente;
        private System.Windows.Forms.TextBox txbDuiTitular;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbIDTitular;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txbIvaTitular;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txbGiroTitular;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txbNitTitular;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txbPaisTitular;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txbNombreTitular;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnBuscarPersona;
        private System.Windows.Forms.TextBox txbFiltroTitular;
        private System.Windows.Forms.GroupBox grupoDocumento;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txbCambio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbEfectivo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbTotalDocu;
        private System.Windows.Forms.NumericUpDown txbPlazoDocu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbbFormaPagoDocu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpFechaDocu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txbNumeroDocu;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnCancelar;
        private System.Windows.Forms.Label label14;
    }
}