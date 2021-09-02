namespace VistasManager.UI
{
    partial class UsuariosManagerEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsuariosManagerEditor));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnCancelar = new System.Windows.Forms.ToolStripButton();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.BarraEstado = new System.Windows.Forms.StatusStrip();
            this.lblBarraEstado = new System.Windows.Forms.ToolStripStatusLabel();
            this.grupoIdentificacion = new System.Windows.Forms.GroupBox();
            this.Estado = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.NombreCompleto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.IDUsuario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grupoCategoria = new System.Windows.Forms.GroupBox();
            this.Rol = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.IDRol = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.TextBox();
            this.ConfirmarPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ckbActivarPassword = new System.Windows.Forms.CheckBox();
            this.toolStrip1.SuspendLayout();
            this.BarraEstado.SuspendLayout();
            this.grupoIdentificacion.SuspendLayout();
            this.grupoCategoria.SuspendLayout();
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
            this.toolStrip1.Size = new System.Drawing.Size(481, 32);
            this.toolStrip1.TabIndex = 7;
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
            // BarraEstado
            // 
            this.BarraEstado.AutoSize = false;
            this.BarraEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblBarraEstado});
            this.BarraEstado.Location = new System.Drawing.Point(3, 359);
            this.BarraEstado.Name = "BarraEstado";
            this.BarraEstado.Size = new System.Drawing.Size(481, 32);
            this.BarraEstado.TabIndex = 8;
            this.BarraEstado.Text = "statusStrip1";
            // 
            // lblBarraEstado
            // 
            this.lblBarraEstado.Name = "lblBarraEstado";
            this.lblBarraEstado.Size = new System.Drawing.Size(97, 27);
            this.lblBarraEstado.Text = "Editando registro";
            // 
            // grupoIdentificacion
            // 
            this.grupoIdentificacion.Controls.Add(this.ckbActivarPassword);
            this.grupoIdentificacion.Controls.Add(this.ConfirmarPassword);
            this.grupoIdentificacion.Controls.Add(this.label3);
            this.grupoIdentificacion.Controls.Add(this.Password);
            this.grupoIdentificacion.Controls.Add(this.Estado);
            this.grupoIdentificacion.Controls.Add(this.label9);
            this.grupoIdentificacion.Controls.Add(this.NombreCompleto);
            this.grupoIdentificacion.Controls.Add(this.label5);
            this.grupoIdentificacion.Controls.Add(this.IDUsuario);
            this.grupoIdentificacion.Controls.Add(this.label1);
            this.grupoIdentificacion.Location = new System.Drawing.Point(6, 38);
            this.grupoIdentificacion.Name = "grupoIdentificacion";
            this.grupoIdentificacion.Size = new System.Drawing.Size(475, 188);
            this.grupoIdentificacion.TabIndex = 9;
            this.grupoIdentificacion.TabStop = false;
            this.grupoIdentificacion.Text = "IDENTIFICACION";
            // 
            // Estado
            // 
            this.Estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Estado.FormattingEnabled = true;
            this.Estado.Items.AddRange(new object[] {
            "ACTIVO",
            "INACTIVO"});
            this.Estado.Location = new System.Drawing.Point(128, 80);
            this.Estado.Name = "Estado";
            this.Estado.Size = new System.Drawing.Size(164, 21);
            this.Estado.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(79, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Estado:";
            // 
            // NombreCompleto
            // 
            this.NombreCompleto.Location = new System.Drawing.Point(128, 54);
            this.NombreCompleto.Name = "NombreCompleto";
            this.NombreCompleto.Size = new System.Drawing.Size(322, 20);
            this.NombreCompleto.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Nombre completo:";
            // 
            // IDUsuario
            // 
            this.IDUsuario.Location = new System.Drawing.Point(128, 28);
            this.IDUsuario.Name = "IDUsuario";
            this.IDUsuario.Size = new System.Drawing.Size(164, 20);
            this.IDUsuario.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID. Usuario:";
            // 
            // grupoCategoria
            // 
            this.grupoCategoria.Controls.Add(this.Rol);
            this.grupoCategoria.Controls.Add(this.label7);
            this.grupoCategoria.Controls.Add(this.IDRol);
            this.grupoCategoria.Controls.Add(this.label8);
            this.grupoCategoria.Location = new System.Drawing.Point(6, 232);
            this.grupoCategoria.Name = "grupoCategoria";
            this.grupoCategoria.Size = new System.Drawing.Size(475, 94);
            this.grupoCategoria.TabIndex = 10;
            this.grupoCategoria.TabStop = false;
            this.grupoCategoria.Text = "ROL ASIGNADO";
            // 
            // Rol
            // 
            this.Rol.Enabled = false;
            this.Rol.Location = new System.Drawing.Point(128, 19);
            this.Rol.Name = "Rol";
            this.Rol.Size = new System.Drawing.Size(285, 20);
            this.Rol.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(64, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Rol actual:";
            // 
            // IDRol
            // 
            this.IDRol.FormattingEnabled = true;
            this.IDRol.Location = new System.Drawing.Point(128, 52);
            this.IDRol.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.IDRol.Name = "IDRol";
            this.IDRol.Size = new System.Drawing.Size(285, 21);
            this.IDRol.TabIndex = 1;
            this.IDRol.SelectedIndexChanged += new System.EventHandler(this.IDRol_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(32, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Roles asignables:";
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(128, 124);
            this.Password.Name = "Password";
            this.Password.PasswordChar = '*';
            this.Password.Size = new System.Drawing.Size(164, 20);
            this.Password.TabIndex = 3;
            // 
            // ConfirmarPassword
            // 
            this.ConfirmarPassword.Location = new System.Drawing.Point(128, 150);
            this.ConfirmarPassword.Name = "ConfirmarPassword";
            this.ConfirmarPassword.PasswordChar = '*';
            this.ConfirmarPassword.Size = new System.Drawing.Size(164, 20);
            this.ConfirmarPassword.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Confirmar password:";
            // 
            // ckbActivarPassword
            // 
            this.ckbActivarPassword.AutoSize = true;
            this.ckbActivarPassword.Location = new System.Drawing.Point(47, 124);
            this.ckbActivarPassword.Name = "ckbActivarPassword";
            this.ckbActivarPassword.Size = new System.Drawing.Size(75, 17);
            this.ckbActivarPassword.TabIndex = 19;
            this.ckbActivarPassword.Text = "Password:";
            this.ckbActivarPassword.UseVisualStyleBackColor = true;
            this.ckbActivarPassword.CheckedChanged += new System.EventHandler(this.ckbActivarPassword_CheckedChanged);
            // 
            // UsuariosManagerEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 394);
            this.Controls.Add(this.grupoCategoria);
            this.Controls.Add(this.grupoIdentificacion);
            this.Controls.Add(this.BarraEstado);
            this.Controls.Add(this.toolStrip1);
            this.Name = "UsuariosManagerEditor";
            this.Text = "USUARIOS - EDITOR";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.BarraEstado.ResumeLayout(false);
            this.BarraEstado.PerformLayout();
            this.grupoIdentificacion.ResumeLayout(false);
            this.grupoIdentificacion.PerformLayout();
            this.grupoCategoria.ResumeLayout(false);
            this.grupoCategoria.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnCancelar;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.StatusStrip BarraEstado;
        private System.Windows.Forms.ToolStripStatusLabel lblBarraEstado;
        private System.Windows.Forms.GroupBox grupoIdentificacion;
        private System.Windows.Forms.ComboBox Estado;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox NombreCompleto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox IDUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grupoCategoria;
        private System.Windows.Forms.TextBox Rol;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox IDRol;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox ConfirmarPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.CheckBox ckbActivarPassword;
    }
}