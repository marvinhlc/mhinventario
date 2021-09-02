namespace VistasManager.UI
{
    partial class ReporteDocumentoSalidas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteDocumentoSalidas));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbbReporte = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbTipoDocumento = new System.Windows.Forms.ComboBox();
            this.ckbActivarTipo = new System.Windows.Forms.CheckBox();
            this.cbbProveedores = new System.Windows.Forms.ComboBox();
            this.ckbActivarProveedores = new System.Windows.Forms.CheckBox();
            this.dtpFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFechaInicial = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnToExcel = new System.Windows.Forms.Button();
            this.btnToPDF = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbbReporte);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbbTipoDocumento);
            this.groupBox1.Controls.Add(this.ckbActivarTipo);
            this.groupBox1.Controls.Add(this.cbbProveedores);
            this.groupBox1.Controls.Add(this.ckbActivarProveedores);
            this.groupBox1.Controls.Add(this.dtpFechaFinal);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpFechaInicial);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(304, 291);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FILTROS";
            // 
            // cbbReporte
            // 
            this.cbbReporte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbReporte.Enabled = false;
            this.cbbReporte.FormattingEnabled = true;
            this.cbbReporte.Items.AddRange(new object[] {
            "VENTA"});
            this.cbbReporte.Location = new System.Drawing.Point(13, 254);
            this.cbbReporte.Name = "cbbReporte";
            this.cbbReporte.Size = new System.Drawing.Size(129, 21);
            this.cbbReporte.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 238);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Reporte:";
            // 
            // cbbTipoDocumento
            // 
            this.cbbTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTipoDocumento.Enabled = false;
            this.cbbTipoDocumento.FormattingEnabled = true;
            this.cbbTipoDocumento.Location = new System.Drawing.Point(13, 204);
            this.cbbTipoDocumento.Name = "cbbTipoDocumento";
            this.cbbTipoDocumento.Size = new System.Drawing.Size(129, 21);
            this.cbbTipoDocumento.TabIndex = 7;
            // 
            // ckbActivarTipo
            // 
            this.ckbActivarTipo.AutoSize = true;
            this.ckbActivarTipo.Location = new System.Drawing.Point(13, 181);
            this.ckbActivarTipo.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.ckbActivarTipo.Name = "ckbActivarTipo";
            this.ckbActivarTipo.Size = new System.Drawing.Size(172, 17);
            this.ckbActivarTipo.TabIndex = 6;
            this.ckbActivarTipo.Text = "Especificar tipo de documento:";
            this.ckbActivarTipo.UseVisualStyleBackColor = true;
            this.ckbActivarTipo.CheckedChanged += new System.EventHandler(this.ckbActivarTipo_CheckedChanged);
            // 
            // cbbProveedores
            // 
            this.cbbProveedores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbProveedores.Enabled = false;
            this.cbbProveedores.FormattingEnabled = true;
            this.cbbProveedores.Location = new System.Drawing.Point(13, 147);
            this.cbbProveedores.Name = "cbbProveedores";
            this.cbbProveedores.Size = new System.Drawing.Size(270, 21);
            this.cbbProveedores.TabIndex = 5;
            // 
            // ckbActivarProveedores
            // 
            this.ckbActivarProveedores.AutoSize = true;
            this.ckbActivarProveedores.Location = new System.Drawing.Point(13, 124);
            this.ckbActivarProveedores.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.ckbActivarProveedores.Name = "ckbActivarProveedores";
            this.ckbActivarProveedores.Size = new System.Drawing.Size(130, 17);
            this.ckbActivarProveedores.TabIndex = 4;
            this.ckbActivarProveedores.Text = "Especificar un cliente:";
            this.ckbActivarProveedores.UseVisualStyleBackColor = true;
            this.ckbActivarProveedores.CheckedChanged += new System.EventHandler(this.ckbActivarProveedores_CheckedChanged);
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFinal.Location = new System.Drawing.Point(13, 91);
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.Size = new System.Drawing.Size(129, 20);
            this.dtpFechaFinal.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 75);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha final:";
            // 
            // dtpFechaInicial
            // 
            this.dtpFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicial.Location = new System.Drawing.Point(13, 42);
            this.dtpFechaInicial.Name = "dtpFechaInicial";
            this.dtpFechaInicial.Size = new System.Drawing.Size(129, 20);
            this.dtpFechaInicial.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha inicial:";
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(320, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 34);
            this.button1.TabIndex = 17;
            this.button1.Text = "Mostrar Reporte";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnToExcel
            // 
            this.btnToExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnToExcel.Image")));
            this.btnToExcel.Location = new System.Drawing.Point(320, 53);
            this.btnToExcel.Name = "btnToExcel";
            this.btnToExcel.Size = new System.Drawing.Size(129, 34);
            this.btnToExcel.TabIndex = 18;
            this.btnToExcel.Text = "Exportar a Excel";
            this.btnToExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnToExcel.UseVisualStyleBackColor = true;
            this.btnToExcel.Click += new System.EventHandler(this.btnToExcel_Click);
            // 
            // btnToPDF
            // 
            this.btnToPDF.Image = ((System.Drawing.Image)(resources.GetObject("btnToPDF.Image")));
            this.btnToPDF.Location = new System.Drawing.Point(320, 93);
            this.btnToPDF.Name = "btnToPDF";
            this.btnToPDF.Size = new System.Drawing.Size(129, 34);
            this.btnToPDF.TabIndex = 19;
            this.btnToPDF.Text = "Exportar a PDF";
            this.btnToPDF.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnToPDF.UseVisualStyleBackColor = true;
            this.btnToPDF.Click += new System.EventHandler(this.btnToPDF_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.Location = new System.Drawing.Point(320, 133);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(129, 34);
            this.btnImprimir.TabIndex = 20;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // ReporteDocumentoSalidas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 318);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnToPDF);
            this.Controls.Add(this.btnToExcel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Name = "ReporteDocumentoSalidas";
            this.Text = "REPORTE DE DOCUMENTOS DE  VENTAS";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpFechaFinal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFechaInicial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbProveedores;
        private System.Windows.Forms.CheckBox ckbActivarProveedores;
        private System.Windows.Forms.ComboBox cbbTipoDocumento;
        private System.Windows.Forms.CheckBox ckbActivarTipo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnToExcel;
        private System.Windows.Forms.Button btnToPDF;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.ComboBox cbbReporte;
        private System.Windows.Forms.Label label3;
    }
}