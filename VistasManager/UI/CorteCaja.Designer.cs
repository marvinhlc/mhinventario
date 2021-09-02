namespace VistasManager.UI
{
    partial class CorteCaja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CorteCaja));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnCancelar = new System.Windows.Forms.ToolStripButton();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.grupoIdentificacion = new System.Windows.Forms.GroupBox();
            this.txbIDCorte = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txbTotalCaja = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txbTotalVentas = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbIDCaja = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbEfectivoInicial = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            // grupoIdentificacion
            // 
            this.grupoIdentificacion.Controls.Add(this.txbIDCorte);
            this.grupoIdentificacion.Controls.Add(this.label5);
            this.grupoIdentificacion.Controls.Add(this.txbTotalCaja);
            this.grupoIdentificacion.Controls.Add(this.label4);
            this.grupoIdentificacion.Controls.Add(this.txbTotalVentas);
            this.grupoIdentificacion.Controls.Add(this.label3);
            this.grupoIdentificacion.Controls.Add(this.txbIDCaja);
            this.grupoIdentificacion.Controls.Add(this.label2);
            this.grupoIdentificacion.Controls.Add(this.txbEfectivoInicial);
            this.grupoIdentificacion.Controls.Add(this.label1);
            this.grupoIdentificacion.Location = new System.Drawing.Point(6, 38);
            this.grupoIdentificacion.Name = "grupoIdentificacion";
            this.grupoIdentificacion.Size = new System.Drawing.Size(412, 121);
            this.grupoIdentificacion.TabIndex = 12;
            this.grupoIdentificacion.TabStop = false;
            this.grupoIdentificacion.Text = "CONFIGURACION";
            // 
            // txbIDCorte
            // 
            this.txbIDCorte.Enabled = false;
            this.txbIDCorte.Location = new System.Drawing.Point(88, 55);
            this.txbIDCorte.Name = "txbIDCorte";
            this.txbIDCorte.Size = new System.Drawing.Size(77, 20);
            this.txbIDCorte.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "ID. Corte:";
            // 
            // txbTotalCaja
            // 
            this.txbTotalCaja.Enabled = false;
            this.txbTotalCaja.Location = new System.Drawing.Point(290, 81);
            this.txbTotalCaja.Name = "txbTotalCaja";
            this.txbTotalCaja.Size = new System.Drawing.Size(99, 20);
            this.txbTotalCaja.TabIndex = 5;
            this.txbTotalCaja.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(212, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Total en caja:";
            // 
            // txbTotalVentas
            // 
            this.txbTotalVentas.Enabled = false;
            this.txbTotalVentas.Location = new System.Drawing.Point(290, 55);
            this.txbTotalVentas.Name = "txbTotalVentas";
            this.txbTotalVentas.Size = new System.Drawing.Size(99, 20);
            this.txbTotalVentas.TabIndex = 3;
            this.txbTotalVentas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(215, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Total ventas:";
            // 
            // txbIDCaja
            // 
            this.txbIDCaja.Enabled = false;
            this.txbIDCaja.Location = new System.Drawing.Point(88, 29);
            this.txbIDCaja.Name = "txbIDCaja";
            this.txbIDCaja.Size = new System.Drawing.Size(77, 20);
            this.txbIDCaja.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "No. de Caja:";
            // 
            // txbEfectivoInicial
            // 
            this.txbEfectivoInicial.Location = new System.Drawing.Point(290, 29);
            this.txbEfectivoInicial.Name = "txbEfectivoInicial";
            this.txbEfectivoInicial.Size = new System.Drawing.Size(99, 20);
            this.txbEfectivoInicial.TabIndex = 0;
            this.txbEfectivoInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txbEfectivoInicial.TextChanged += new System.EventHandler(this.txbEfectivoInicial_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(206, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Efectivo inicial:";
            // 
            // CorteCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 176);
            this.Controls.Add(this.grupoIdentificacion);
            this.Controls.Add(this.toolStrip1);
            this.Name = "CorteCaja";
            this.Text = "CORTE DE CAJA";
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
        private System.Windows.Forms.TextBox txbEfectivoInicial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbIDCaja;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbTotalVentas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbTotalCaja;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbIDCorte;
        private System.Windows.Forms.Label label5;
    }
}