namespace VistasManager.UI
{
    partial class GastosImprimir
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GastosImprimir));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbbClasificaciones = new System.Windows.Forms.ComboBox();
            this.ckbActivarEstado = new System.Windows.Forms.CheckBox();
            this.dtpFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFechaInicial = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbReportes = new System.Windows.Forms.ComboBox();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnToPDF = new System.Windows.Forms.Button();
            this.btnToExcel = new System.Windows.Forms.Button();
            this.btnMostrarReporte = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbbReportes);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbbClasificaciones);
            this.groupBox1.Controls.Add(this.ckbActivarEstado);
            this.groupBox1.Controls.Add(this.dtpFechaFinal);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpFechaInicial);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(14, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(173, 250);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FILTROS";
            // 
            // cbbClasificaciones
            // 
            this.cbbClasificaciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbClasificaciones.DropDownWidth = 200;
            this.cbbClasificaciones.Enabled = false;
            this.cbbClasificaciones.FormattingEnabled = true;
            this.cbbClasificaciones.Items.AddRange(new object[] {
            "PENDIENTE",
            "ENTREGADO"});
            this.cbbClasificaciones.Location = new System.Drawing.Point(13, 157);
            this.cbbClasificaciones.Name = "cbbClasificaciones";
            this.cbbClasificaciones.Size = new System.Drawing.Size(141, 21);
            this.cbbClasificaciones.TabIndex = 5;
            // 
            // ckbActivarEstado
            // 
            this.ckbActivarEstado.AutoSize = true;
            this.ckbActivarEstado.Location = new System.Drawing.Point(13, 134);
            this.ckbActivarEstado.Name = "ckbActivarEstado";
            this.ckbActivarEstado.Size = new System.Drawing.Size(99, 17);
            this.ckbActivarEstado.TabIndex = 4;
            this.ckbActivarEstado.Text = "Clasificaciones:";
            this.ckbActivarEstado.UseVisualStyleBackColor = true;
            this.ckbActivarEstado.CheckedChanged += new System.EventHandler(this.ckbActivarEstado_CheckedChanged);
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
            this.label2.Size = new System.Drawing.Size(129, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha de entrega finaliza:";
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
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha de entrega inicia:";
            // 
            // cbbReportes
            // 
            this.cbbReportes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbReportes.DropDownWidth = 200;
            this.cbbReportes.FormattingEnabled = true;
            this.cbbReportes.Items.AddRange(new object[] {
            "RESUMEN DE GASTOS",
            "GASTOS DETALLADO"});
            this.cbbReportes.Location = new System.Drawing.Point(13, 207);
            this.cbbReportes.Name = "cbbReportes";
            this.cbbReportes.Size = new System.Drawing.Size(141, 21);
            this.cbbReportes.TabIndex = 6;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.Location = new System.Drawing.Point(195, 132);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(129, 34);
            this.btnImprimir.TabIndex = 34;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnToPDF
            // 
            this.btnToPDF.Image = ((System.Drawing.Image)(resources.GetObject("btnToPDF.Image")));
            this.btnToPDF.Location = new System.Drawing.Point(195, 92);
            this.btnToPDF.Name = "btnToPDF";
            this.btnToPDF.Size = new System.Drawing.Size(129, 34);
            this.btnToPDF.TabIndex = 33;
            this.btnToPDF.Text = "Exportar a PDF";
            this.btnToPDF.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnToPDF.UseVisualStyleBackColor = true;
            this.btnToPDF.Click += new System.EventHandler(this.btnToPDF_Click);
            // 
            // btnToExcel
            // 
            this.btnToExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnToExcel.Image")));
            this.btnToExcel.Location = new System.Drawing.Point(195, 52);
            this.btnToExcel.Name = "btnToExcel";
            this.btnToExcel.Size = new System.Drawing.Size(129, 34);
            this.btnToExcel.TabIndex = 32;
            this.btnToExcel.Text = "Exportar a Excel";
            this.btnToExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnToExcel.UseVisualStyleBackColor = true;
            this.btnToExcel.Click += new System.EventHandler(this.btnToExcel_Click);
            // 
            // btnMostrarReporte
            // 
            this.btnMostrarReporte.Image = ((System.Drawing.Image)(resources.GetObject("btnMostrarReporte.Image")));
            this.btnMostrarReporte.Location = new System.Drawing.Point(195, 12);
            this.btnMostrarReporte.Name = "btnMostrarReporte";
            this.btnMostrarReporte.Size = new System.Drawing.Size(129, 34);
            this.btnMostrarReporte.TabIndex = 31;
            this.btnMostrarReporte.Text = "Mostrar Reporte";
            this.btnMostrarReporte.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMostrarReporte.UseVisualStyleBackColor = true;
            this.btnMostrarReporte.Click += new System.EventHandler(this.btnMostrarReporte_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 191);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Reportes:";
            // 
            // GastosImprimir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 272);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnToPDF);
            this.Controls.Add(this.btnToExcel);
            this.Controls.Add(this.btnMostrarReporte);
            this.Controls.Add(this.groupBox1);
            this.Name = "GastosImprimir";
            this.Text = "REPORTES DE GASTOS";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnToPDF;
        private System.Windows.Forms.Button btnToExcel;
        private System.Windows.Forms.Button btnMostrarReporte;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbbClasificaciones;
        private System.Windows.Forms.CheckBox ckbActivarEstado;
        private System.Windows.Forms.DateTimePicker dtpFechaFinal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFechaInicial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbReportes;
        private System.Windows.Forms.Label label3;
    }
}