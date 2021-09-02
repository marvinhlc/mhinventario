namespace Backup
{
    partial class HacerBackup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HacerBackup));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSeleccionarRuta = new System.Windows.Forms.Button();
            this.txbRutaDistinta = new System.Windows.Forms.TextBox();
            this.txbRutaDelSistema = new System.Windows.Forms.TextBox();
            this.RutaDestino2 = new System.Windows.Forms.RadioButton();
            this.RutaDestino1 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblCadenaConexion = new System.Windows.Forms.Label();
            this.cbbConexiones = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.linkFicheroSalida = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTextoProgreso = new System.Windows.Forms.Label();
            this.BarraProgreso = new System.Windows.Forms.ProgressBar();
            this.btnHacerBackup = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSeleccionarRuta);
            this.groupBox1.Controls.Add(this.txbRutaDistinta);
            this.groupBox1.Controls.Add(this.txbRutaDelSistema);
            this.groupBox1.Controls.Add(this.RutaDestino2);
            this.groupBox1.Controls.Add(this.RutaDestino1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(511, 125);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Destino del Backup";
            // 
            // btnSeleccionarRuta
            // 
            this.btnSeleccionarRuta.Enabled = false;
            this.btnSeleccionarRuta.Image = ((System.Drawing.Image)(resources.GetObject("btnSeleccionarRuta.Image")));
            this.btnSeleccionarRuta.Location = new System.Drawing.Point(376, 68);
            this.btnSeleccionarRuta.Name = "btnSeleccionarRuta";
            this.btnSeleccionarRuta.Size = new System.Drawing.Size(115, 44);
            this.btnSeleccionarRuta.TabIndex = 4;
            this.btnSeleccionarRuta.Text = "Seleccionar";
            this.btnSeleccionarRuta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSeleccionarRuta.UseVisualStyleBackColor = true;
            this.btnSeleccionarRuta.Click += new System.EventHandler(this.btnSeleccionarRuta_Click);
            // 
            // txbRutaDistinta
            // 
            this.txbRutaDistinta.Enabled = false;
            this.txbRutaDistinta.Location = new System.Drawing.Point(34, 91);
            this.txbRutaDistinta.Name = "txbRutaDistinta";
            this.txbRutaDistinta.Size = new System.Drawing.Size(336, 20);
            this.txbRutaDistinta.TabIndex = 3;
            // 
            // txbRutaDelSistema
            // 
            this.txbRutaDelSistema.Enabled = false;
            this.txbRutaDelSistema.Location = new System.Drawing.Point(34, 42);
            this.txbRutaDelSistema.Name = "txbRutaDelSistema";
            this.txbRutaDelSistema.Size = new System.Drawing.Size(457, 20);
            this.txbRutaDelSistema.TabIndex = 2;
            // 
            // RutaDestino2
            // 
            this.RutaDestino2.AutoSize = true;
            this.RutaDestino2.Location = new System.Drawing.Point(16, 68);
            this.RutaDestino2.Name = "RutaDestino2";
            this.RutaDestino2.Size = new System.Drawing.Size(170, 17);
            this.RutaDestino2.TabIndex = 1;
            this.RutaDestino2.TabStop = true;
            this.RutaDestino2.Text = "Seleccionar un fichero distinto:";
            this.RutaDestino2.UseVisualStyleBackColor = true;
            this.RutaDestino2.CheckedChanged += new System.EventHandler(this.RutaDestino2_CheckedChanged);
            // 
            // RutaDestino1
            // 
            this.RutaDestino1.AutoSize = true;
            this.RutaDestino1.Location = new System.Drawing.Point(16, 19);
            this.RutaDestino1.Name = "RutaDestino1";
            this.RutaDestino1.Size = new System.Drawing.Size(211, 17);
            this.RutaDestino1.TabIndex = 0;
            this.RutaDestino1.TabStop = true;
            this.RutaDestino1.Text = "En la ruta y fichero habitual del sistema:";
            this.RutaDestino1.UseVisualStyleBackColor = true;
            this.RutaDestino1.CheckedChanged += new System.EventHandler(this.RutaDestino1_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblInfo);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.lblCadenaConexion);
            this.groupBox2.Controls.Add(this.cbbConexiones);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.linkFicheroSalida);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.lblTextoProgreso);
            this.groupBox2.Controls.Add(this.BarraProgreso);
            this.groupBox2.Controls.Add(this.btnHacerBackup);
            this.groupBox2.Location = new System.Drawing.Point(12, 143);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(511, 267);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ejecutar Backup";
            // 
            // lblInfo
            // 
            this.lblInfo.Location = new System.Drawing.Point(16, 201);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(340, 26);
            this.lblInfo.TabIndex = 8;
            this.lblInfo.Text = "Info";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox3
            // 
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox3.Location = new System.Drawing.Point(6, 151);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(499, 10);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            // 
            // lblCadenaConexion
            // 
            this.lblCadenaConexion.Location = new System.Drawing.Point(16, 56);
            this.lblCadenaConexion.Name = "lblCadenaConexion";
            this.lblCadenaConexion.Size = new System.Drawing.Size(475, 34);
            this.lblCadenaConexion.TabIndex = 12;
            this.lblCadenaConexion.Text = "Cadena de conexión...";
            // 
            // cbbConexiones
            // 
            this.cbbConexiones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbConexiones.FormattingEnabled = true;
            this.cbbConexiones.Location = new System.Drawing.Point(19, 32);
            this.cbbConexiones.Name = "cbbConexiones";
            this.cbbConexiones.Size = new System.Drawing.Size(192, 21);
            this.cbbConexiones.TabIndex = 11;
            this.cbbConexiones.SelectedIndexChanged += new System.EventHandler(this.cbbConexiones_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Conexión a la Base de Datos:";
            // 
            // linkFicheroSalida
            // 
            this.linkFicheroSalida.Location = new System.Drawing.Point(16, 113);
            this.linkFicheroSalida.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.linkFicheroSalida.Name = "linkFicheroSalida";
            this.linkFicheroSalida.Size = new System.Drawing.Size(472, 32);
            this.linkFicheroSalida.TabIndex = 9;
            this.linkFicheroSalida.TabStop = true;
            this.linkFicheroSalida.Text = "Fichero de salida...";
            this.linkFicheroSalida.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkFicheroSalida_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 95);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Archivo de salida:";
            // 
            // lblTextoProgreso
            // 
            this.lblTextoProgreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextoProgreso.Location = new System.Drawing.Point(17, 167);
            this.lblTextoProgreso.Name = "lblTextoProgreso";
            this.lblTextoProgreso.Size = new System.Drawing.Size(340, 34);
            this.lblTextoProgreso.TabIndex = 7;
            this.lblTextoProgreso.Text = "Progreso: 0%";
            this.lblTextoProgreso.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BarraProgreso
            // 
            this.BarraProgreso.Location = new System.Drawing.Point(16, 230);
            this.BarraProgreso.Name = "BarraProgreso";
            this.BarraProgreso.Size = new System.Drawing.Size(475, 23);
            this.BarraProgreso.TabIndex = 6;
            // 
            // btnHacerBackup
            // 
            this.btnHacerBackup.Image = ((System.Drawing.Image)(resources.GetObject("btnHacerBackup.Image")));
            this.btnHacerBackup.Location = new System.Drawing.Point(363, 180);
            this.btnHacerBackup.Name = "btnHacerBackup";
            this.btnHacerBackup.Size = new System.Drawing.Size(128, 44);
            this.btnHacerBackup.TabIndex = 5;
            this.btnHacerBackup.Text = "Hacer Backup";
            this.btnHacerBackup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHacerBackup.UseVisualStyleBackColor = true;
            this.btnHacerBackup.Click += new System.EventHandler(this.btnHacerBackup_Click);
            // 
            // HacerBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 422);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HacerBackup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HACER BACKUP - MySQL";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSeleccionarRuta;
        private System.Windows.Forms.TextBox txbRutaDistinta;
        private System.Windows.Forms.TextBox txbRutaDelSistema;
        private System.Windows.Forms.RadioButton RutaDestino2;
        private System.Windows.Forms.RadioButton RutaDestino1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnHacerBackup;
        private System.Windows.Forms.Label lblTextoProgreso;
        private System.Windows.Forms.ProgressBar BarraProgreso;
        private System.Windows.Forms.LinkLabel linkFicheroSalida;
        private System.Windows.Forms.ComboBox cbbConexiones;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCadenaConexion;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblInfo;
    }
}