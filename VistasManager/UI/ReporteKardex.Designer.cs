namespace VistasManager.UI
{
    partial class ReporteKardex
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteKardex));
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBuscarProducto = new System.Windows.Forms.Button();
            this.txbNombreProducto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ckbActivarFechas = new System.Windows.Forms.CheckBox();
            this.dtpFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFechaInicial = new System.Windows.Forms.DateTimePicker();
            this.ckbActivarBodegas = new System.Windows.Forms.CheckBox();
            this.cbbBodegas = new System.Windows.Forms.ComboBox();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnToPDF = new System.Windows.Forms.Button();
            this.btnToExcel = new System.Windows.Forms.Button();
            this.btnMostrarReporte = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 328);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(346, 39);
            this.label3.TabIndex = 36;
            this.label3.Text = "NOTA: Si no ha activado los filtros se generará un inventario general completo, c" +
    "on todas las bodegas desde el inicio del año a la fecha.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnBuscarProducto);
            this.groupBox1.Controls.Add(this.txbNombreProducto);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ckbActivarFechas);
            this.groupBox1.Controls.Add(this.dtpFechaFinal);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpFechaInicial);
            this.groupBox1.Controls.Add(this.ckbActivarBodegas);
            this.groupBox1.Controls.Add(this.cbbBodegas);
            this.groupBox1.Location = new System.Drawing.Point(14, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(203, 294);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FILTROS";
            // 
            // btnBuscarProducto
            // 
            this.btnBuscarProducto.BackColor = System.Drawing.SystemColors.Control;
            this.btnBuscarProducto.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarProducto.Image")));
            this.btnBuscarProducto.Location = new System.Drawing.Point(81, 193);
            this.btnBuscarProducto.Name = "btnBuscarProducto";
            this.btnBuscarProducto.Size = new System.Drawing.Size(106, 24);
            this.btnBuscarProducto.TabIndex = 16;
            this.btnBuscarProducto.Text = "Productos";
            this.btnBuscarProducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscarProducto.UseVisualStyleBackColor = false;
            this.btnBuscarProducto.Click += new System.EventHandler(this.btnBuscarProducto_Click);
            // 
            // txbNombreProducto
            // 
            this.txbNombreProducto.Location = new System.Drawing.Point(16, 222);
            this.txbNombreProducto.Multiline = true;
            this.txbNombreProducto.Name = "txbNombreProducto";
            this.txbNombreProducto.ReadOnly = true;
            this.txbNombreProducto.Size = new System.Drawing.Size(171, 55);
            this.txbNombreProducto.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Nombre:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Fecha inicial:";
            // 
            // ckbActivarFechas
            // 
            this.ckbActivarFechas.AutoSize = true;
            this.ckbActivarFechas.Location = new System.Drawing.Point(6, 80);
            this.ckbActivarFechas.Name = "ckbActivarFechas";
            this.ckbActivarFechas.Size = new System.Drawing.Size(172, 17);
            this.ckbActivarFechas.TabIndex = 11;
            this.ckbActivarFechas.Text = "Establezca el rango de fechas:";
            this.ckbActivarFechas.UseVisualStyleBackColor = true;
            this.ckbActivarFechas.CheckedChanged += new System.EventHandler(this.ckbActivarFechas_CheckedChanged);
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFinal.Location = new System.Drawing.Point(81, 130);
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.Size = new System.Drawing.Size(106, 20);
            this.dtpFechaFinal.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Fecha final:";
            // 
            // dtpFechaInicial
            // 
            this.dtpFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicial.Location = new System.Drawing.Point(81, 104);
            this.dtpFechaInicial.Name = "dtpFechaInicial";
            this.dtpFechaInicial.Size = new System.Drawing.Size(106, 20);
            this.dtpFechaInicial.TabIndex = 8;
            this.dtpFechaInicial.ValueChanged += new System.EventHandler(this.dtpFechaInicial_ValueChanged);
            // 
            // ckbActivarBodegas
            // 
            this.ckbActivarBodegas.AutoSize = true;
            this.ckbActivarBodegas.Location = new System.Drawing.Point(6, 19);
            this.ckbActivarBodegas.Name = "ckbActivarBodegas";
            this.ckbActivarBodegas.Size = new System.Drawing.Size(142, 17);
            this.ckbActivarBodegas.TabIndex = 6;
            this.ckbActivarBodegas.Text = "Seleccione una bodega:";
            this.ckbActivarBodegas.UseVisualStyleBackColor = true;
            this.ckbActivarBodegas.CheckedChanged += new System.EventHandler(this.ckbActivarBodegas_CheckedChanged);
            // 
            // cbbBodegas
            // 
            this.cbbBodegas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbBodegas.FormattingEnabled = true;
            this.cbbBodegas.Items.AddRange(new object[] {
            "CLIENTES",
            "PROVEEDORES",
            "COMBINADO"});
            this.cbbBodegas.Location = new System.Drawing.Point(6, 40);
            this.cbbBodegas.Name = "cbbBodegas";
            this.cbbBodegas.Size = new System.Drawing.Size(181, 21);
            this.cbbBodegas.TabIndex = 5;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.Location = new System.Drawing.Point(225, 134);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(129, 34);
            this.btnImprimir.TabIndex = 35;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnToPDF
            // 
            this.btnToPDF.Image = ((System.Drawing.Image)(resources.GetObject("btnToPDF.Image")));
            this.btnToPDF.Location = new System.Drawing.Point(225, 94);
            this.btnToPDF.Name = "btnToPDF";
            this.btnToPDF.Size = new System.Drawing.Size(129, 34);
            this.btnToPDF.TabIndex = 34;
            this.btnToPDF.Text = "Exportar a PDF";
            this.btnToPDF.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnToPDF.UseVisualStyleBackColor = true;
            this.btnToPDF.Click += new System.EventHandler(this.btnToPDF_Click);
            // 
            // btnToExcel
            // 
            this.btnToExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnToExcel.Image")));
            this.btnToExcel.Location = new System.Drawing.Point(225, 54);
            this.btnToExcel.Name = "btnToExcel";
            this.btnToExcel.Size = new System.Drawing.Size(129, 34);
            this.btnToExcel.TabIndex = 33;
            this.btnToExcel.Text = "Exportar a Excel";
            this.btnToExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnToExcel.UseVisualStyleBackColor = true;
            this.btnToExcel.Click += new System.EventHandler(this.btnToExcel_Click);
            // 
            // btnMostrarReporte
            // 
            this.btnMostrarReporte.Image = ((System.Drawing.Image)(resources.GetObject("btnMostrarReporte.Image")));
            this.btnMostrarReporte.Location = new System.Drawing.Point(225, 14);
            this.btnMostrarReporte.Name = "btnMostrarReporte";
            this.btnMostrarReporte.Size = new System.Drawing.Size(129, 34);
            this.btnMostrarReporte.TabIndex = 32;
            this.btnMostrarReporte.Text = "Mostrar Reporte";
            this.btnMostrarReporte.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMostrarReporte.UseVisualStyleBackColor = true;
            this.btnMostrarReporte.Click += new System.EventHandler(this.btnMostrarReporte_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "Seleccione un producto:";
            // 
            // ReporteKardex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 376);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnToPDF);
            this.Controls.Add(this.btnToExcel);
            this.Controls.Add(this.btnMostrarReporte);
            this.Controls.Add(this.groupBox1);
            this.Name = "ReporteKardex";
            this.Text = "KARDEX";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnToPDF;
        private System.Windows.Forms.Button btnToExcel;
        private System.Windows.Forms.Button btnMostrarReporte;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ckbActivarFechas;
        private System.Windows.Forms.DateTimePicker dtpFechaFinal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFechaInicial;
        private System.Windows.Forms.CheckBox ckbActivarBodegas;
        private System.Windows.Forms.ComboBox cbbBodegas;
        private System.Windows.Forms.TextBox txbNombreProducto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBuscarProducto;
        private System.Windows.Forms.Label label5;
    }
}