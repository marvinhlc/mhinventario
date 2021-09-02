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
using EntityManager;

namespace VistasManager.UI
{
    public partial class UsuariosManagerEditor : Estilos.FormEditores
    {
        EntityManager.DataBase _datos = new DataBase();

        //DELEGADO PARA OPERACIONES EXTERNAS
        public delegate void RefresarFormularioExterno();
        public event RefresarFormularioExterno doRefrescarFormularioExterno;

        ModelosManager.CLS.Usuarios _usuario = new ModelosManager.CLS.Usuarios();
        ErrorProvider _error = new ErrorProvider();

        public UsuariosManagerEditor(ModelosManager.CLS.Usuarios _puser = null)
        {
            InitializeComponent();
            if (_puser != null)
            {
                _usuario = _puser;
            }
            else
            {
                _usuario = new ModelosManager.CLS.Usuarios();
            }
            IniciarControles();
        }

        private void IniciarControles()
        {
            try
            {
                IDRol.Roles();
                Estado.Estado();
                Rol.Clear();
                ckbActivarPassword.Checked = false;
                Password.Enabled = false;
                ConfirmarPassword.Enabled = false;

                if (_usuario.Existe)
                {
                    grupoIdentificacion.Mapear(_usuario);
                    grupoCategoria.Mapear(_usuario);

                    IDUsuario.Enabled = false;
                }
                else
                {
                    IDUsuario.Enabled = true;
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Guardar()
        {
            bool _ok = false;
            bool _valido = false;
            try
            {
                grupoIdentificacion.Sincronizar(_usuario);
                grupoCategoria.Sincronizar(_usuario);

                if (ckbActivarPassword.Checked)
                {
                    if (Password.Text.Equals(ConfirmarPassword.Text))
                    {
                        _usuario.Password.Modificador = DataManager.TypeManager.Modificador.PASSWORD_SHA1;
                        _valido = true;
                    }
                    else
                    {
                        _usuario.Password.Modificador = DataManager.TypeManager.Modificador.NO_UPDATABLE;
                        _error.SetError(Password, "Password no es válido");
                        _valido = false;
                    }
                }
                else
                {
                    _usuario.Password.Modificador = DataManager.TypeManager.Modificador.NO_UPDATABLE;
                    _valido = true;
                }

                if (string.IsNullOrEmpty(Rol.Text))
                {
                    _valido = false;
                    _error.SetError(Rol, "Debe seleccionar un rol");
                }

                if (_valido)
                {
                    if (_usuario.Existe)
                    {
                        _ok = (_datos.Actualizar(_usuario) > 0);
                    }
                    else
                    {
                        _ok = (_datos.Insertar(_usuario) > 0);
                    }
                }
                else
                {
                    MessageBox.Show("Los datos del usuario no son válidos", "GUARDAR", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
            finally
            {
                if (_ok)
                {
                    if (doRefrescarFormularioExterno != null)
                    {
                        doRefrescarFormularioExterno();
                    }
                    this.Notificar(Extensiones._NOTIFICADORES.REGISTRO_GUARDADO);
                    Close();
                }
            }
        }

        private void IDRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Rol.Text = IDRol.Text;
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void ckbActivarPassword_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Password.Enabled = ckbActivarPassword.Checked;
                ConfirmarPassword.Enabled = ckbActivarPassword.Checked;

                Password.Focus();
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }
    }
}
