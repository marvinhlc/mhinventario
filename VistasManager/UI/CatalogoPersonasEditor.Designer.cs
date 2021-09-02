namespace VistasManager.UI
{
    partial class CatalogoPersonasEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CatalogoPersonasEditor));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnCancelar = new System.Windows.Forms.ToolStripButton();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.grupoIdentificacion = new System.Windows.Forms.GroupBox();
            this.Pais = new System.Windows.Forms.ComboBox();
            this.Giro = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.DUI = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.IVA = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.NIT = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Rol = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Tipo = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Contacto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.NombrePersona = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.IDPersona = new System.Windows.Forms.TextBox();
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
            this.toolStrip1.Size = new System.Drawing.Size(484, 32);
            this.toolStrip1.TabIndex = 8;
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
            this.grupoIdentificacion.Controls.Add(this.Pais);
            this.grupoIdentificacion.Controls.Add(this.Giro);
            this.grupoIdentificacion.Controls.Add(this.label11);
            this.grupoIdentificacion.Controls.Add(this.DUI);
            this.grupoIdentificacion.Controls.Add(this.label8);
            this.grupoIdentificacion.Controls.Add(this.IVA);
            this.grupoIdentificacion.Controls.Add(this.label7);
            this.grupoIdentificacion.Controls.Add(this.NIT);
            this.grupoIdentificacion.Controls.Add(this.label6);
            this.grupoIdentificacion.Controls.Add(this.label4);
            this.grupoIdentificacion.Controls.Add(this.Rol);
            this.grupoIdentificacion.Controls.Add(this.label10);
            this.grupoIdentificacion.Controls.Add(this.Tipo);
            this.grupoIdentificacion.Controls.Add(this.label9);
            this.grupoIdentificacion.Controls.Add(this.Contacto);
            this.grupoIdentificacion.Controls.Add(this.label5);
            this.grupoIdentificacion.Controls.Add(this.NombrePersona);
            this.grupoIdentificacion.Controls.Add(this.label3);
            this.grupoIdentificacion.Controls.Add(this.IDPersona);
            this.grupoIdentificacion.Controls.Add(this.label1);
            this.grupoIdentificacion.Location = new System.Drawing.Point(6, 38);
            this.grupoIdentificacion.Name = "grupoIdentificacion";
            this.grupoIdentificacion.Size = new System.Drawing.Size(478, 298);
            this.grupoIdentificacion.TabIndex = 10;
            this.grupoIdentificacion.TabStop = false;
            this.grupoIdentificacion.Text = "IDENTIFICACION";
            // 
            // Pais
            // 
            this.Pais.FormattingEnabled = true;
            this.Pais.Location = new System.Drawing.Point(128, 178);
            this.Pais.Name = "Pais";
            this.Pais.Size = new System.Drawing.Size(157, 21);
            this.Pais.TabIndex = 29;
            // 
            // Giro
            // 
            this.Giro.Location = new System.Drawing.Point(128, 151);
            this.Giro.Name = "Giro";
            this.Giro.Size = new System.Drawing.Size(157, 20);
            this.Giro.TabIndex = 28;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(93, 151);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "Giro:";
            // 
            // DUI
            // 
            this.DUI.Location = new System.Drawing.Point(128, 257);
            this.DUI.Name = "DUI";
            this.DUI.Size = new System.Drawing.Size(157, 20);
            this.DUI.TabIndex = 26;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(93, 257);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "DUI:";
            // 
            // IVA
            // 
            this.IVA.Location = new System.Drawing.Point(128, 231);
            this.IVA.Name = "IVA";
            this.IVA.Size = new System.Drawing.Size(157, 20);
            this.IVA.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(95, 231);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "IVA:";
            // 
            // NIT
            // 
            this.NIT.Location = new System.Drawing.Point(128, 205);
            this.NIT.Name = "NIT";
            this.NIT.Size = new System.Drawing.Size(157, 20);
            this.NIT.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(94, 205);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "NIT:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(90, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "País:";
            // 
            // Rol
            // 
            this.Rol.FormattingEnabled = true;
            this.Rol.Location = new System.Drawing.Point(128, 97);
            this.Rol.Name = "Rol";
            this.Rol.Size = new System.Drawing.Size(157, 21);
            this.Rol.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(40, 97);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Rol de persona:";
            // 
            // Tipo
            // 
            this.Tipo.FormattingEnabled = true;
            this.Tipo.Location = new System.Drawing.Point(128, 124);
            this.Tipo.Name = "Tipo";
            this.Tipo.Size = new System.Drawing.Size(157, 21);
            this.Tipo.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(91, 124);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Tipo:";
            // 
            // Contacto
            // 
            this.Contacto.Location = new System.Drawing.Point(128, 71);
            this.Contacto.Name = "Contacto";
            this.Contacto.Size = new System.Drawing.Size(322, 20);
            this.Contacto.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(72, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Contacto:";
            // 
            // NombrePersona
            // 
            this.NombrePersona.Location = new System.Drawing.Point(128, 45);
            this.NombrePersona.Name = "NombrePersona";
            this.NombrePersona.Size = new System.Drawing.Size(322, 20);
            this.NombrePersona.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nombre de persona:";
            // 
            // IDPersona
            // 
            this.IDPersona.Enabled = false;
            this.IDPersona.Location = new System.Drawing.Point(128, 19);
            this.IDPersona.Name = "IDPersona";
            this.IDPersona.Size = new System.Drawing.Size(115, 20);
            this.IDPersona.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID. Persona:";
            // 
            // CatalogoPersonasEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 348);
            this.Controls.Add(this.grupoIdentificacion);
            this.Controls.Add(this.toolStrip1);
            this.Name = "CatalogoPersonasEditor";
            this.Text = "EDITOR DE PERSONAS";
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
        private System.Windows.Forms.ComboBox Rol;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox Tipo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox Contacto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox NombrePersona;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox IDPersona;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Pais;
        private System.Windows.Forms.TextBox Giro;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox DUI;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox IVA;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox NIT;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
    }
}