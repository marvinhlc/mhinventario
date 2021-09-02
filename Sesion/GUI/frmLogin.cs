using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sesion;
using System.Reflection;
using System.Configuration;
using Herramientas;

namespace Sesion.GUI
{
    public partial class frmLogin : Form
    {
        private Sesion.CLS.OmniSesion _sesion = Sesion.CLS.OmniSesion.Instancia;
        private Portable.Portador _portador = Portable.Portador.Instancia;

        String _Usuario;
        String _Credencial;
        Boolean _Autorizado = false;

        public Sesion.CLS.OmniSesion SESION
        {
            get { return _sesion; }
            
        }
        public Boolean Autorizado
        {
            get { return _Autorizado; }
        }

        public String Credencial
        {
            get { return _Credencial; }
            set { _Credencial = value; }
        }
        public String Usuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }
        public frmLogin()
        {
            InitializeComponent();
            MethodInfo m = typeof(Panel).GetMethod("SetStyle", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            Object[] parameters = new Object[2];
            parameters[0] = new ControlStyles();
            parameters[0] = ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint;
            parameters[1] = new bool();
            parameters[1] = true;
            m.Invoke(P1, parameters);
            m = typeof(Panel).GetMethod("UpdateStyles", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            m.Invoke(P1, null);
            lblLicenciaUSO.Text = string.Format("Software con licencia para {0}", _sesion.CONFIGAPP.MARCA_BLANCA.ToString());
            cbbConexion.Conexiones();
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                //txtUsuario.Text = "ADMIN";
                //txtCredencial.Text = "123";

                string algo = Sesion.CLS.Wallpaper.LeerWallpaper("Default");
                Image wp = null;
                wp = Image.FromFile(algo);
                BackgroundImage = wp;
            }
            catch 
            {
             //nada   
            }
            timer1.Start();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            lblNotif.Text = "Comprobando...";
            _portador.Conexion = cbbConexion.Text;
            if (_sesion.Validar(txtUsuario.Text,txtCredencial.Text))
            {
                lblNotif.Text = "Acceso permitido.";

                //MessageBox.Show(_user.InsertSQL());

                //Sesion.CLS.Usuario _nuevo = new CLS.Usuario();
                //_nuevo.IDUsuario.Valor = "MARVIN.LINARES.CARIDAD";
                //_nuevo.NombreCompleto.Valor = "MARVIN H. LINARES CARIDAD";
                //_nuevo.Password.Valor = "tribicuche";
                //_nuevo.Estado.Valor = "ACTIVO";
                //_nuevo.IDRol.Valor = 1;
                //_nuevo.Rol.Valor = "ADMINISTRADOR";

                //_nuevo.Nuevo();

                _Autorizado = true;
                timer1.Stop();
                timer1.Dispose();
                Close();
            }
            else
            {
                lblNotif.Text = "Usuario o Contraseña erróneos. Por favor vuelva intentarlo";
                txtCredencial.Focus();
                txtCredencial.SelectAll();
            }
        }
        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCredencial.Focus();
            }
        }
        private void txtCredencial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAceptar.PerformClick();
            }
        }
        private void btnAceptar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAceptar.PerformClick();
            }
        }
        private void btnCancelar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnCancelar.PerformClick();
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //lblReloj.Text = DateTime.Now.ToShortTimeString().ToUpper();
            //lblFecha.Text = DateTime.Now.ToLongDateString().ToUpper();
            lblFechaHora.Text = string.Format("{0} - hora: {1}", DateTime.Now.ToLongDateString(), DateTime.Now.ToShortTimeString());
        }

        private void PonerWallPaper()
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Imagenes (*.jpg;*.JPEG;*.PNG)|";
                open.FilterIndex = 0;
                open.Multiselect = false;
                open.AddExtension = true;
                open.RestoreDirectory = true;
                if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.BackgroundImage = Image.FromFile(open.FileName);
                    Sesion.CLS.Wallpaper.GuardarWallpaper("Default", open.FileName);
                    this.Refresh();
                }
            }
            catch
            {
            }

        }

        private void QuitarWallPaper()
        {
            try
            {
                this.BackgroundImage = null;
                Sesion.CLS.Wallpaper.GuardarWallpaper("Default", "");
                this.Refresh();
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void removerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuitarWallPaper();
        }

        private void cambiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PonerWallPaper();
        }

    }
}
