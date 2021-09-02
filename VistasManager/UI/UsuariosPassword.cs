using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Herramientas;

namespace VistasManager.UI
{
    public partial class UsuariosPassword : Estilos.FormDialogos
    {
        Sesion.CLS.OmniSesion _sesion = Sesion.CLS.OmniSesion.Instancia;
        ModelosManager.CLS.Usuarios _usuario = new ModelosManager.CLS.Usuarios();
        ErrorProvider _errores = new ErrorProvider();
        EntityManager.DataBase _bd = new EntityManager.DataBase();

        public UsuariosPassword()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (AceptarCambios())
            {
                Close();
            }
        }

        private bool AceptarCambios()
        {
            bool _ok = false;
            try
            {
                _errores.Clear();
                string _idusuario = _sesion.USUARIO.IDUsuario.Valor.ToString();
                Sesion.CLS.Usuario _user = null;

                if (txbPasswordActual.Text.NoNOE())
                {
                    _user = new Sesion.CLS.Usuario(_idusuario, txbPasswordActual.Text);
                    if (_user.Loguear())
                    {
                        _usuario.IDUsuario.Valor = _user.IDUsuario.Valor;
                        if (txbNuevoPassword.Text.Equals(txbConfirmarPassword.Text))
                        {
                            _usuario.NombreCompleto.Modificador = DataManager.TypeManager.Modificador.NO_UPDATABLE;
                            _usuario.IDRol.Modificador = DataManager.TypeManager.Modificador.NO_UPDATABLE;
                            _usuario.Rol.Modificador = DataManager.TypeManager.Modificador.NO_UPDATABLE;
                            _usuario.Estado.Modificador = DataManager.TypeManager.Modificador.NO_UPDATABLE;
                            _usuario.Password.Valor = txbNuevoPassword.Text;

                            _ok = (_bd.Actualizar(_usuario) > 0);
                            if (_ok)
                            {
                                MessageBox.Show("El password se ha guardado correctamente", "USUARIO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        else
                        {
                            _errores.SetError(txbNuevoPassword, "No es válido");
                            _errores.SetError(txbConfirmarPassword, "No es válido");
                            MessageBox.Show("Los password no son iguales.", "USUARIO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                    else
                    {
                        _errores.SetError(txbPasswordActual, "No es válido");
                        MessageBox.Show("El password no es correcto", "USUARIO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                {
                    _errores.SetError(txbPasswordActual, "No es válido");
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
            return _ok;
        }

        private void txbPasswordActual_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txbNuevoPassword.Focus();
            }
        }

        private void txbNuevoPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txbConfirmarPassword.Focus();
            }
        }

        private void txbConfirmarPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AceptarCambios();
            }
        }

    }
}
