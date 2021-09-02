namespace Sesion.GUI
{
    partial class frmLogin
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtCredencial = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.P1 = new System.Windows.Forms.Panel();
            this.cbbConexion = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.bgwReloj = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblFechaHora = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblImagen = new System.Windows.Forms.ToolStripDropDownButton();
            this.removerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblLicenciaUSO = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblNotif = new System.Windows.Forms.ToolStripStatusLabel();
            this.P1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(25, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(25, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Credencial";
            // 
            // txtUsuario
            // 
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtUsuario.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(22, 174);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(281, 27);
            this.txtUsuario.TabIndex = 0;
            this.txtUsuario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUsuario_KeyDown);
            // 
            // txtCredencial
            // 
            this.txtCredencial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCredencial.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCredencial.Location = new System.Drawing.Point(22, 229);
            this.txtCredencial.Name = "txtCredencial";
            this.txtCredencial.PasswordChar = '*';
            this.txtCredencial.Size = new System.Drawing.Size(281, 27);
            this.txtCredencial.TabIndex = 1;
            this.txtCredencial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCredencial_KeyDown);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(166, 317);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(137, 47);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cerrar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            this.btnCancelar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnCancelar_KeyDown);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(22, 317);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(137, 47);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Entrar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            this.btnAceptar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnAceptar_KeyDown);
            // 
            // P1
            // 
            this.P1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.P1.BackColor = System.Drawing.Color.Gainsboro;
            this.P1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.P1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.P1.Controls.Add(this.cbbConexion);
            this.P1.Controls.Add(this.label3);
            this.P1.Controls.Add(this.label1);
            this.P1.Controls.Add(this.label2);
            this.P1.Controls.Add(this.txtUsuario);
            this.P1.Controls.Add(this.txtCredencial);
            this.P1.Controls.Add(this.btnAceptar);
            this.P1.Controls.Add(this.btnCancelar);
            this.P1.Controls.Add(this.pictureBox3);
            this.P1.Location = new System.Drawing.Point(379, 117);
            this.P1.Name = "P1";
            this.P1.Size = new System.Drawing.Size(325, 385);
            this.P1.TabIndex = 10;
            // 
            // cbbConexion
            // 
            this.cbbConexion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbConexion.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbConexion.FormattingEnabled = true;
            this.cbbConexion.Location = new System.Drawing.Point(22, 284);
            this.cbbConexion.Name = "cbbConexion";
            this.cbbConexion.Size = new System.Drawing.Size(281, 27);
            this.cbbConexion.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(25, 259);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 22);
            this.label3.TabIndex = 10;
            this.label3.Text = "Conexión:";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(3, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(319, 130);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 9;
            this.pictureBox3.TabStop = false;
            // 
            // bgwReloj
            // 
            this.bgwReloj.WorkerSupportsCancellation = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.BackColor = System.Drawing.Color.Gainsboro;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblFechaHora,
            this.lblImagen,
            this.lblLicenciaUSO,
            this.lblNotif});
            this.statusStrip1.Location = new System.Drawing.Point(0, 662);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1063, 35);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 18;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblFechaHora
            // 
            this.lblFechaHora.Image = ((System.Drawing.Image)(resources.GetObject("lblFechaHora.Image")));
            this.lblFechaHora.Name = "lblFechaHora";
            this.lblFechaHora.Size = new System.Drawing.Size(90, 30);
            this.lblFechaHora.Text = "Fecha y hora";
            // 
            // lblImagen
            // 
            this.lblImagen.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removerToolStripMenuItem,
            this.cambiarToolStripMenuItem});
            this.lblImagen.Image = ((System.Drawing.Image)(resources.GetObject("lblImagen.Image")));
            this.lblImagen.Margin = new System.Windows.Forms.Padding(25, 3, 0, 2);
            this.lblImagen.Name = "lblImagen";
            this.lblImagen.Size = new System.Drawing.Size(129, 30);
            this.lblImagen.Text = "Imagen de Fondo";
            // 
            // removerToolStripMenuItem
            // 
            this.removerToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("removerToolStripMenuItem.Image")));
            this.removerToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.removerToolStripMenuItem.Name = "removerToolStripMenuItem";
            this.removerToolStripMenuItem.Size = new System.Drawing.Size(135, 38);
            this.removerToolStripMenuItem.Text = "Quitar";
            this.removerToolStripMenuItem.Click += new System.EventHandler(this.removerToolStripMenuItem_Click);
            // 
            // cambiarToolStripMenuItem
            // 
            this.cambiarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cambiarToolStripMenuItem.Image")));
            this.cambiarToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cambiarToolStripMenuItem.Name = "cambiarToolStripMenuItem";
            this.cambiarToolStripMenuItem.Size = new System.Drawing.Size(135, 38);
            this.cambiarToolStripMenuItem.Text = "Cambiar";
            this.cambiarToolStripMenuItem.Click += new System.EventHandler(this.cambiarToolStripMenuItem_Click);
            // 
            // lblLicenciaUSO
            // 
            this.lblLicenciaUSO.Margin = new System.Windows.Forms.Padding(10, 3, 0, 2);
            this.lblLicenciaUSO.Name = "lblLicenciaUSO";
            this.lblLicenciaUSO.Size = new System.Drawing.Size(92, 30);
            this.lblLicenciaUSO.Text = "Licencia de USO";
            // 
            // lblNotif
            // 
            this.lblNotif.Name = "lblNotif";
            this.lblNotif.Size = new System.Drawing.Size(702, 30);
            this.lblNotif.Spring = true;
            this.lblNotif.Text = "Ingrese su Nombre de Usuario y Credencial en los espacios asignados";
            this.lblNotif.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1063, 697);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.P1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio de Sesion ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.P1.ResumeLayout(false);
            this.P1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtCredencial;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Panel P1;
        private System.ComponentModel.BackgroundWorker bgwReloj;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbbConexion;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblFechaHora;
        private System.Windows.Forms.ToolStripDropDownButton lblImagen;
        private System.Windows.Forms.ToolStripMenuItem removerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambiarToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel lblNotif;
        private System.Windows.Forms.ToolStripStatusLabel lblLicenciaUSO;
    }
}