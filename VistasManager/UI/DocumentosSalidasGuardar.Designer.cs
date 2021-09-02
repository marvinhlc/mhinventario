namespace VistasManager.UI
{
    partial class DocumentosSalidasGuardar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocumentosSalidasGuardar));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnCancelar = new System.Windows.Forms.ToolStripButton();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.grupoInformacion = new System.Windows.Forms.GroupBox();
            this.IDDocumento = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Comentario = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Documento = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.DiasPlazo = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.FormaPago = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.NumeroDocumento = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.FechaDocumento = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.NombreTitular = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.IDPersona = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grupoCliente = new System.Windows.Forms.GroupBox();
            this.toolStrip1.SuspendLayout();
            this.grupoInformacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DiasPlazo)).BeginInit();
            this.grupoCliente.SuspendLayout();
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
            this.toolStrip1.Size = new System.Drawing.Size(475, 32);
            this.toolStrip1.TabIndex = 10;
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
            // grupoInformacion
            // 
            this.grupoInformacion.Controls.Add(this.IDDocumento);
            this.grupoInformacion.Controls.Add(this.label9);
            this.grupoInformacion.Controls.Add(this.Comentario);
            this.grupoInformacion.Controls.Add(this.label8);
            this.grupoInformacion.Controls.Add(this.Documento);
            this.grupoInformacion.Controls.Add(this.label7);
            this.grupoInformacion.Controls.Add(this.DiasPlazo);
            this.grupoInformacion.Controls.Add(this.label6);
            this.grupoInformacion.Controls.Add(this.FormaPago);
            this.grupoInformacion.Controls.Add(this.label5);
            this.grupoInformacion.Controls.Add(this.NumeroDocumento);
            this.grupoInformacion.Controls.Add(this.label4);
            this.grupoInformacion.Controls.Add(this.FechaDocumento);
            this.grupoInformacion.Controls.Add(this.label3);
            this.grupoInformacion.Location = new System.Drawing.Point(6, 38);
            this.grupoInformacion.Name = "grupoInformacion";
            this.grupoInformacion.Size = new System.Drawing.Size(469, 295);
            this.grupoInformacion.TabIndex = 11;
            this.grupoInformacion.TabStop = false;
            this.grupoInformacion.Text = "INFORMACION DE DOCUMENTO";
            // 
            // IDDocumento
            // 
            this.IDDocumento.Enabled = false;
            this.IDDocumento.Location = new System.Drawing.Point(134, 34);
            this.IDDocumento.Name = "IDDocumento";
            this.IDDocumento.Size = new System.Drawing.Size(118, 20);
            this.IDDocumento.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(46, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "ID. Documento:";
            // 
            // Comentario
            // 
            this.Comentario.Location = new System.Drawing.Point(134, 193);
            this.Comentario.Multiline = true;
            this.Comentario.Name = "Comentario";
            this.Comentario.Size = new System.Drawing.Size(302, 84);
            this.Comentario.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(65, 193);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Comentario:";
            // 
            // Documento
            // 
            this.Documento.FormattingEnabled = true;
            this.Documento.Location = new System.Drawing.Point(134, 166);
            this.Documento.Name = "Documento";
            this.Documento.Size = new System.Drawing.Size(150, 21);
            this.Documento.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 166);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Tipo de documento:";
            // 
            // DiasPlazo
            // 
            this.DiasPlazo.Location = new System.Drawing.Point(134, 140);
            this.DiasPlazo.Name = "DiasPlazo";
            this.DiasPlazo.Size = new System.Drawing.Size(118, 20);
            this.DiasPlazo.TabIndex = 5;
            this.DiasPlazo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(69, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Dias plazo:";
            // 
            // FormaPago
            // 
            this.FormaPago.FormattingEnabled = true;
            this.FormaPago.Location = new System.Drawing.Point(134, 112);
            this.FormaPago.Name = "FormaPago";
            this.FormaPago.Size = new System.Drawing.Size(118, 21);
            this.FormaPago.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Forma de pago:";
            // 
            // NumeroDocumento
            // 
            this.NumeroDocumento.Location = new System.Drawing.Point(134, 86);
            this.NumeroDocumento.Name = "NumeroDocumento";
            this.NumeroDocumento.Size = new System.Drawing.Size(118, 20);
            this.NumeroDocumento.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Numero de documento:";
            // 
            // FechaDocumento
            // 
            this.FechaDocumento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechaDocumento.Location = new System.Drawing.Point(134, 60);
            this.FechaDocumento.Name = "FechaDocumento";
            this.FechaDocumento.Size = new System.Drawing.Size(117, 20);
            this.FechaDocumento.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fecha de documento:";
            // 
            // NombreTitular
            // 
            this.NombreTitular.Enabled = false;
            this.NombreTitular.Location = new System.Drawing.Point(134, 57);
            this.NombreTitular.Name = "NombreTitular";
            this.NombreTitular.Size = new System.Drawing.Size(302, 20);
            this.NombreTitular.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre de cliente:";
            // 
            // IDPersona
            // 
            this.IDPersona.Enabled = false;
            this.IDPersona.Location = new System.Drawing.Point(134, 31);
            this.IDPersona.Name = "IDPersona";
            this.IDPersona.Size = new System.Drawing.Size(118, 20);
            this.IDPersona.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID. Cliente:";
            // 
            // grupoCliente
            // 
            this.grupoCliente.Controls.Add(this.NombreTitular);
            this.grupoCliente.Controls.Add(this.label2);
            this.grupoCliente.Controls.Add(this.IDPersona);
            this.grupoCliente.Controls.Add(this.label1);
            this.grupoCliente.Location = new System.Drawing.Point(6, 339);
            this.grupoCliente.Name = "grupoCliente";
            this.grupoCliente.Size = new System.Drawing.Size(469, 97);
            this.grupoCliente.TabIndex = 18;
            this.grupoCliente.TabStop = false;
            this.grupoCliente.Text = "CLIENTE";
            // 
            // DocumentosSalidasGuardar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 454);
            this.Controls.Add(this.grupoCliente);
            this.Controls.Add(this.grupoInformacion);
            this.Controls.Add(this.toolStrip1);
            this.Name = "DocumentosSalidasGuardar";
            this.Text = "GUARDAR DOCUMENTO DE SALIDAS";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.grupoInformacion.ResumeLayout(false);
            this.grupoInformacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DiasPlazo)).EndInit();
            this.grupoCliente.ResumeLayout(false);
            this.grupoCliente.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnCancelar;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.GroupBox grupoInformacion;
        private System.Windows.Forms.TextBox NombreTitular;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox IDPersona;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker FechaDocumento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox NumeroDocumento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox FormaPago;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown DiasPlazo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox Documento;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Comentario;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox IDDocumento;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox grupoCliente;
    }
}