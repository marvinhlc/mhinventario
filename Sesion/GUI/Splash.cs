using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sesion.GUI
{
    public partial class Splash : Form
    {
        Sesion.CLS.OmniSesion _sesion = Sesion.CLS.OmniSesion.Instancia;
        private Boolean _Continuar;

        public Boolean Continuar
        {
            get { return _Continuar; }
            set { _Continuar = value; }
        }
        public Splash()
        {
            InitializeComponent();
            //this.TransparencyKey = Color.FromArgb(0xAA, 0x00, 0xFF);
            //this.BackColor = Color.FromArgb(0xAA, 0x00, 0xFF); 
            lblLicenciaUso.Text = _sesion.CONFIGAPP.MARCA_BLANCA.ToString();
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            bgwComprobacion.RunWorkerAsync();
        }
        private Boolean ProbarComunicacion()
        {
            Boolean resultado = true;

            return resultado;
        }
        private Boolean ProbarAmbienteEjecucion()
        {
            Boolean resultado = true;

            return resultado;
        }
        private Boolean VerificarLicencia()
        {
            Boolean resultado = true;

            return resultado;
        }

        private void bgwComprobacion_DoWork(object sender, DoWorkEventArgs e)
        {
            _Continuar = true;
            bgwComprobacion.ReportProgress(5, "Comprobando Comunicacion con el servidor");
            if (ProbarComunicacion())
            {
                System.Threading.Thread.Sleep(1000); //simulamos trabajo

                bgwComprobacion.ReportProgress(33, "Comprobando Ambiente de Ejecucion");
                if (ProbarAmbienteEjecucion())
                {
                    System.Threading.Thread.Sleep(1000); //simulamos trabajo
                    bgwComprobacion.ReportProgress(80, "Comprobando Licenciamiento");
                    if (VerificarLicencia())
                    {
                        System.Threading.Thread.Sleep(500);
                        bgwComprobacion.ReportProgress(100, "Completado");
                        System.Threading.Thread.Sleep(1000); //simulamos trabajo
                    }
                    else
                    {
                        _Continuar = false;
                    }
                }
                else
                {
                    _Continuar = false;
                }
            }
            else
            {
                _Continuar = false;
            }
        }

        private void bgwComprobacion_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            prbInicio.Value = e.ProgressPercentage;
            lblNotif.Text = e.UserState.ToString();
        }

        private void bgwComprobacion_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
