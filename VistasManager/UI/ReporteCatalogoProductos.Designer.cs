namespace VistasManager.UI
{
    partial class ReporteCatalogoProductos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteCatalogoProductos));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbbSubcategoria = new System.Windows.Forms.ComboBox();
            this.ckbActivarSubcategoria = new System.Windows.Forms.CheckBox();
            this.cbbCategoria = new System.Windows.Forms.ComboBox();
            this.ckbActivarCategoria = new System.Windows.Forms.CheckBox();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnToPDF = new System.Windows.Forms.Button();
            this.btnToExcel = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbbSubcategoria);
            this.groupBox1.Controls.Add(this.ckbActivarSubcategoria);
            this.groupBox1.Controls.Add(this.cbbCategoria);
            this.groupBox1.Controls.Add(this.ckbActivarCategoria);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(304, 159);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FILTROS";
            // 
            // cbbSubcategoria
            // 
            this.cbbSubcategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSubcategoria.Enabled = false;
            this.cbbSubcategoria.FormattingEnabled = true;
            this.cbbSubcategoria.Location = new System.Drawing.Point(6, 106);
            this.cbbSubcategoria.Name = "cbbSubcategoria";
            this.cbbSubcategoria.Size = new System.Drawing.Size(270, 21);
            this.cbbSubcategoria.TabIndex = 7;
            // 
            // ckbActivarSubcategoria
            // 
            this.ckbActivarSubcategoria.AutoSize = true;
            this.ckbActivarSubcategoria.Location = new System.Drawing.Point(6, 83);
            this.ckbActivarSubcategoria.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.ckbActivarSubcategoria.Name = "ckbActivarSubcategoria";
            this.ckbActivarSubcategoria.Size = new System.Drawing.Size(92, 17);
            this.ckbActivarSubcategoria.TabIndex = 6;
            this.ckbActivarSubcategoria.Text = "Subcategoria:";
            this.ckbActivarSubcategoria.UseVisualStyleBackColor = true;
            this.ckbActivarSubcategoria.CheckedChanged += new System.EventHandler(this.ckbActivarSubcategoria_CheckedChanged);
            // 
            // cbbCategoria
            // 
            this.cbbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCategoria.Enabled = false;
            this.cbbCategoria.FormattingEnabled = true;
            this.cbbCategoria.Location = new System.Drawing.Point(6, 49);
            this.cbbCategoria.Name = "cbbCategoria";
            this.cbbCategoria.Size = new System.Drawing.Size(270, 21);
            this.cbbCategoria.TabIndex = 5;
            this.cbbCategoria.SelectedIndexChanged += new System.EventHandler(this.cbbCategoria_SelectedIndexChanged);
            // 
            // ckbActivarCategoria
            // 
            this.ckbActivarCategoria.AutoSize = true;
            this.ckbActivarCategoria.Location = new System.Drawing.Point(6, 26);
            this.ckbActivarCategoria.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.ckbActivarCategoria.Name = "ckbActivarCategoria";
            this.ckbActivarCategoria.Size = new System.Drawing.Size(74, 17);
            this.ckbActivarCategoria.TabIndex = 4;
            this.ckbActivarCategoria.Text = "Categoria:";
            this.ckbActivarCategoria.UseVisualStyleBackColor = true;
            this.ckbActivarCategoria.CheckedChanged += new System.EventHandler(this.ckbActivarCategoria_CheckedChanged);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.Location = new System.Drawing.Point(320, 133);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(129, 34);
            this.btnImprimir.TabIndex = 24;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnToPDF
            // 
            this.btnToPDF.Image = ((System.Drawing.Image)(resources.GetObject("btnToPDF.Image")));
            this.btnToPDF.Location = new System.Drawing.Point(320, 93);
            this.btnToPDF.Name = "btnToPDF";
            this.btnToPDF.Size = new System.Drawing.Size(129, 34);
            this.btnToPDF.TabIndex = 23;
            this.btnToPDF.Text = "Exportar a PDF";
            this.btnToPDF.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnToPDF.UseVisualStyleBackColor = true;
            this.btnToPDF.Click += new System.EventHandler(this.btnToPDF_Click);
            // 
            // btnToExcel
            // 
            this.btnToExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnToExcel.Image")));
            this.btnToExcel.Location = new System.Drawing.Point(320, 53);
            this.btnToExcel.Name = "btnToExcel";
            this.btnToExcel.Size = new System.Drawing.Size(129, 34);
            this.btnToExcel.TabIndex = 22;
            this.btnToExcel.Text = "Exportar a Excel";
            this.btnToExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnToExcel.UseVisualStyleBackColor = true;
            this.btnToExcel.Click += new System.EventHandler(this.btnToExcel_Click);
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(320, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 34);
            this.button1.TabIndex = 21;
            this.button1.Text = "Mostrar Reporte";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ReporteCatalogoProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 200);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnToPDF);
            this.Controls.Add(this.btnToExcel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Name = "ReporteCatalogoProductos";
            this.Text = "REPORTE CATALOGO DE PRODUCTOS";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbbSubcategoria;
        private System.Windows.Forms.CheckBox ckbActivarSubcategoria;
        private System.Windows.Forms.ComboBox cbbCategoria;
        private System.Windows.Forms.CheckBox ckbActivarCategoria;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnToPDF;
        private System.Windows.Forms.Button btnToExcel;
        private System.Windows.Forms.Button button1;
    }
}