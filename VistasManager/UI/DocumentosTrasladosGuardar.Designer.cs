namespace VistasManager.UI
{
    partial class DocumentosTrasladosGuardar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocumentosTrasladosGuardar));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnCancelar = new System.Windows.Forms.ToolStripButton();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.grupoInformacion = new System.Windows.Forms.GroupBox();
            this.IDDocumento = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Comentario = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.NumeroDocumento = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.FechaDocumento = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.grupoInformacion.SuspendLayout();
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
            this.grupoInformacion.Controls.Add(this.NumeroDocumento);
            this.grupoInformacion.Controls.Add(this.label4);
            this.grupoInformacion.Controls.Add(this.FechaDocumento);
            this.grupoInformacion.Controls.Add(this.label3);
            this.grupoInformacion.Location = new System.Drawing.Point(6, 38);
            this.grupoInformacion.Name = "grupoInformacion";
            this.grupoInformacion.Size = new System.Drawing.Size(469, 212);
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
            this.Comentario.Location = new System.Drawing.Point(134, 112);
            this.Comentario.Multiline = true;
            this.Comentario.Name = "Comentario";
            this.Comentario.Size = new System.Drawing.Size(302, 84);
            this.Comentario.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(65, 112);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Comentario:";
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
            // DocumentosTrasladosGuardar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 263);
            this.Controls.Add(this.grupoInformacion);
            this.Controls.Add(this.toolStrip1);
            this.Name = "DocumentosTrasladosGuardar";
            this.Text = "GUARDAR DOCUMENTO DE TRASLADOS";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.grupoInformacion.ResumeLayout(false);
            this.grupoInformacion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnCancelar;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.GroupBox grupoInformacion;
        private System.Windows.Forms.DateTimePicker FechaDocumento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox NumeroDocumento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Comentario;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox IDDocumento;
        private System.Windows.Forms.Label label9;
    }
}