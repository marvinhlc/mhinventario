namespace Sesion.GUI
{
    partial class Splash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Splash));
            this.prbInicio = new System.Windows.Forms.ProgressBar();
            this.lblNotif = new System.Windows.Forms.Label();
            this.bgwComprobacion = new System.ComponentModel.BackgroundWorker();
            this.lblLicenciaUso = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // prbInicio
            // 
            this.prbInicio.Location = new System.Drawing.Point(163, 274);
            this.prbInicio.Name = "prbInicio";
            this.prbInicio.Size = new System.Drawing.Size(310, 15);
            this.prbInicio.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.prbInicio.TabIndex = 0;
            // 
            // lblNotif
            // 
            this.lblNotif.BackColor = System.Drawing.Color.Transparent;
            this.lblNotif.Font = new System.Drawing.Font("Segoe UI Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotif.ForeColor = System.Drawing.Color.White;
            this.lblNotif.Location = new System.Drawing.Point(163, 251);
            this.lblNotif.Name = "lblNotif";
            this.lblNotif.Size = new System.Drawing.Size(310, 20);
            this.lblNotif.TabIndex = 1;
            this.lblNotif.Text = "Iniciando Aplicacion";
            this.lblNotif.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bgwComprobacion
            // 
            this.bgwComprobacion.WorkerReportsProgress = true;
            this.bgwComprobacion.WorkerSupportsCancellation = true;
            this.bgwComprobacion.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwComprobacion_DoWork);
            this.bgwComprobacion.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwComprobacion_ProgressChanged);
            this.bgwComprobacion.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwComprobacion_RunWorkerCompleted);
            // 
            // lblLicenciaUso
            // 
            this.lblLicenciaUso.BackColor = System.Drawing.Color.Transparent;
            this.lblLicenciaUso.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenciaUso.ForeColor = System.Drawing.Color.White;
            this.lblLicenciaUso.Location = new System.Drawing.Point(25, 209);
            this.lblLicenciaUso.Name = "lblLicenciaUso";
            this.lblLicenciaUso.Size = new System.Drawing.Size(448, 22);
            this.lblLicenciaUso.TabIndex = 2;
            this.lblLicenciaUso.Text = "LICENCIA DE USO";
            this.lblLicenciaUso.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(163, 191);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Se autoriza el uso de éste software a";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Splash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(498, 300);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblLicenciaUso);
            this.Controls.Add(this.lblNotif);
            this.Controls.Add(this.prbInicio);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Splash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Splash";
            this.Load += new System.EventHandler(this.Splash_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar prbInicio;
        private System.Windows.Forms.Label lblNotif;
        private System.ComponentModel.BackgroundWorker bgwComprobacion;
        private System.Windows.Forms.Label lblLicenciaUso;
        private System.Windows.Forms.Label label1;
    }
}