namespace VistasManager.UI
{
    partial class VentaDevolucion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VentaDevolucion));
            this.grupoDocumento = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txbSaldo = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txbCambio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbEfectivo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbTotalDocu = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.grupoDocumento.SuspendLayout();
            this.SuspendLayout();
            // 
            // grupoDocumento
            // 
            this.grupoDocumento.Controls.Add(this.label1);
            this.grupoDocumento.Controls.Add(this.txbSaldo);
            this.grupoDocumento.Controls.Add(this.label13);
            this.grupoDocumento.Controls.Add(this.txbCambio);
            this.grupoDocumento.Controls.Add(this.label2);
            this.grupoDocumento.Controls.Add(this.txbEfectivo);
            this.grupoDocumento.Controls.Add(this.label3);
            this.grupoDocumento.Controls.Add(this.txbTotalDocu);
            this.grupoDocumento.Location = new System.Drawing.Point(6, 6);
            this.grupoDocumento.Name = "grupoDocumento";
            this.grupoDocumento.Size = new System.Drawing.Size(304, 184);
            this.grupoDocumento.TabIndex = 8;
            this.grupoDocumento.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(52, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 25);
            this.label1.TabIndex = 15;
            this.label1.Text = "Saldo:";
            // 
            // txbSaldo
            // 
            this.txbSaldo.Enabled = false;
            this.txbSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbSaldo.Location = new System.Drawing.Point(127, 133);
            this.txbSaldo.Name = "txbSaldo";
            this.txbSaldo.Size = new System.Drawing.Size(154, 31);
            this.txbSaldo.TabIndex = 14;
            this.txbSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(35, 96);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(86, 25);
            this.label13.TabIndex = 13;
            this.label13.Text = "Cambio:";
            // 
            // txbCambio
            // 
            this.txbCambio.Enabled = false;
            this.txbCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbCambio.Location = new System.Drawing.Point(127, 96);
            this.txbCambio.Name = "txbCambio";
            this.txbCambio.Size = new System.Drawing.Size(154, 31);
            this.txbCambio.TabIndex = 12;
            this.txbCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 25);
            this.label2.TabIndex = 11;
            this.label2.Text = "Efectivo:";
            // 
            // txbEfectivo
            // 
            this.txbEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbEfectivo.Location = new System.Drawing.Point(127, 59);
            this.txbEfectivo.Name = "txbEfectivo";
            this.txbEfectivo.Size = new System.Drawing.Size(154, 31);
            this.txbEfectivo.TabIndex = 10;
            this.txbEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txbEfectivo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txbEfectivo_KeyDown);
            this.txbEfectivo.Validating += new System.ComponentModel.CancelEventHandler(this.txbEfectivo_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "Total venta:";
            // 
            // txbTotalDocu
            // 
            this.txbTotalDocu.Enabled = false;
            this.txbTotalDocu.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTotalDocu.Location = new System.Drawing.Point(127, 22);
            this.txbTotalDocu.Name = "txbTotalDocu";
            this.txbTotalDocu.Size = new System.Drawing.Size(154, 31);
            this.txbTotalDocu.TabIndex = 8;
            this.txbTotalDocu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.Location = new System.Drawing.Point(321, 6);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(87, 23);
            this.btnAceptar.TabIndex = 9;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(321, 35);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(87, 23);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.button2_Click);
            // 
            // VentaDevolucion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 206);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.grupoDocumento);
            this.Name = "VentaDevolucion";
            this.Text = "TOTAL EFECTIVO Y CAMBIO";
            this.grupoDocumento.ResumeLayout(false);
            this.grupoDocumento.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grupoDocumento;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txbCambio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbEfectivo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbTotalDocu;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbSaldo;
    }
}