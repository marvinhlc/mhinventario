namespace VistasManager.UI
{
    partial class PuntoVentaImpresion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PuntoVentaImpresion));
            this.label1 = new System.Windows.Forms.Label();
            this.btnFacturaSimplificada = new System.Windows.Forms.Button();
            this.btnTicket = new System.Windows.Forms.Button();
            this.btnCreditoFiscal = new System.Windows.Forms.Button();
            this.btnConsumidorFinal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 167);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label1.Size = new System.Drawing.Size(314, 79);
            this.label1.TabIndex = 14;
            this.label1.Text = "Seleccione el tipo de documento que desea generar haciendo click en los botones o" +
    " presionando la tecla de fución (F3, F4, F5 ó F6).";
            // 
            // btnFacturaSimplificada
            // 
            this.btnFacturaSimplificada.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFacturaSimplificada.Image = ((System.Drawing.Image)(resources.GetObject("btnFacturaSimplificada.Image")));
            this.btnFacturaSimplificada.Location = new System.Drawing.Point(166, 88);
            this.btnFacturaSimplificada.Name = "btnFacturaSimplificada";
            this.btnFacturaSimplificada.Size = new System.Drawing.Size(154, 76);
            this.btnFacturaSimplificada.TabIndex = 13;
            this.btnFacturaSimplificada.Text = "F6 - FACTURA SIMPLIFICADA";
            this.btnFacturaSimplificada.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFacturaSimplificada.UseVisualStyleBackColor = true;
            this.btnFacturaSimplificada.Click += new System.EventHandler(this.btnFacturaSimplificada_Click);
            // 
            // btnTicket
            // 
            this.btnTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTicket.Image = ((System.Drawing.Image)(resources.GetObject("btnTicket.Image")));
            this.btnTicket.Location = new System.Drawing.Point(6, 88);
            this.btnTicket.Name = "btnTicket";
            this.btnTicket.Size = new System.Drawing.Size(154, 76);
            this.btnTicket.TabIndex = 12;
            this.btnTicket.Text = "F5 - TICKET";
            this.btnTicket.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTicket.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTicket.UseVisualStyleBackColor = true;
            this.btnTicket.Click += new System.EventHandler(this.btnTicket_Click);
            // 
            // btnCreditoFiscal
            // 
            this.btnCreditoFiscal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreditoFiscal.Image = ((System.Drawing.Image)(resources.GetObject("btnCreditoFiscal.Image")));
            this.btnCreditoFiscal.Location = new System.Drawing.Point(166, 6);
            this.btnCreditoFiscal.Name = "btnCreditoFiscal";
            this.btnCreditoFiscal.Size = new System.Drawing.Size(154, 76);
            this.btnCreditoFiscal.TabIndex = 11;
            this.btnCreditoFiscal.Text = "F4 - CREDITO FISCAL";
            this.btnCreditoFiscal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCreditoFiscal.UseVisualStyleBackColor = true;
            this.btnCreditoFiscal.Click += new System.EventHandler(this.btnCreditoFiscal_Click);
            // 
            // btnConsumidorFinal
            // 
            this.btnConsumidorFinal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsumidorFinal.Image = ((System.Drawing.Image)(resources.GetObject("btnConsumidorFinal.Image")));
            this.btnConsumidorFinal.Location = new System.Drawing.Point(6, 6);
            this.btnConsumidorFinal.Name = "btnConsumidorFinal";
            this.btnConsumidorFinal.Size = new System.Drawing.Size(154, 76);
            this.btnConsumidorFinal.TabIndex = 10;
            this.btnConsumidorFinal.Text = "F3 - CONSUMIDOR FINAL";
            this.btnConsumidorFinal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConsumidorFinal.UseVisualStyleBackColor = true;
            this.btnConsumidorFinal.Click += new System.EventHandler(this.btnConsumidorFinal_Click);
            // 
            // PuntoVentaImpresion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 253);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFacturaSimplificada);
            this.Controls.Add(this.btnTicket);
            this.Controls.Add(this.btnCreditoFiscal);
            this.Controls.Add(this.btnConsumidorFinal);
            this.KeyPreview = true;
            this.Name = "PuntoVentaImpresion";
            this.Text = "IMPRIMIR VENTA";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PuntoVentaImpresion_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFacturaSimplificada;
        private System.Windows.Forms.Button btnTicket;
        private System.Windows.Forms.Button btnCreditoFiscal;
        private System.Windows.Forms.Button btnConsumidorFinal;
    }
}