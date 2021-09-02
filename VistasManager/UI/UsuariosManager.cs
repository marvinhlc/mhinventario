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
    public partial class UsuariosManager : Estilos.FormMantenimiento
    {
        Sesion.CLS.OmniSesion _sesion = Sesion.CLS.OmniSesion.Instancia;
        EntityManager.DataBase _bd = new DataBase();

        DataTable _dtusuarios = new DataTable();
        BindingSource _bsusuarios = new BindingSource();
        DataTable _dtroles = new DataTable();
        BindingSource _bsroles = new BindingSource();
        DataTable _dtcomandos = new DataTable();
        BindingSource _bscomandos = new BindingSource();
        DataTable _dtpermisos = new DataTable();
        BindingSource _bspermisos = new BindingSource();

        ModelosManager.CLS.Usuarios _usuarios = new ModelosManager.CLS.Usuarios();
        ModelosManager.CLS.UsuariosRoles _roles = new ModelosManager.CLS.UsuariosRoles();
        ModelosManager.CLS.UsuariosComandos _comandos = new ModelosManager.CLS.UsuariosComandos();
        ModelosManager.CLS.UsuariosPermisos _permisos = new ModelosManager.CLS.UsuariosPermisos();

        enum _MODOS
        {
            TODO,
            PERMISOS
        }

        public UsuariosManager()
        {
            InitializeComponent();
            IniciarControles();
        }

        private void Actualizar(_MODOS _modo)
        {
            switch (_modo)
            {
                case _MODOS.PERMISOS:
                    _dtpermisos = _permisos.PermisosDeRoles();
                    _bspermisos.DataSource = _dtpermisos;

                    dgvPermisos.AutoGenerateColumns = false;
                    dgvPermisos.DataSource = _bspermisos;

                    _sesion.USUARIO.RecargarPermisos();
                    break;
            }
        }

        private void IniciarControles()
        {
            try
            {
                _dtusuarios = _usuarios.TodosLosUsuarios();
                _bsusuarios.DataSource = _dtusuarios;

                dgvUsuarios.AutoGenerateColumns = false;
                dgvUsuarios.DataSource = _bsusuarios;

                _dtcomandos = _comandos.Todo();
                _bscomandos.DataSource = _dtcomandos;

                dgvComandos.AutoGenerateColumns = false;
                dgvComandos.DataSource = _bscomandos;

                _dtpermisos = _permisos.PermisosDeRoles();
                _bspermisos.DataSource = _dtpermisos;

                dgvPermisos.AutoGenerateColumns = false;
                dgvPermisos.DataSource = _bspermisos;

                _dtroles = _roles.Todo();
                _bsroles.DataSource = _dtroles;

                cbbRoles.ComboBox.DataSource = _bsroles;
                cbbRoles.ComboBox.DisplayMember = "DescripcionRol";
                cbbRoles.ComboBox.ValueMember = "IDRol";
                cbbRoles.ComboBox.SelectedIndex = 0;

                FiltrarPermisosPorRoles();
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarRegistro();
        }

        private void EliminarRegistro()
        {
            try
            {
                if (this.Notificar(Extensiones._NOTIFICADORES.CONFIRME_ELIMINAR_REGISTRO) == System.Windows.Forms.DialogResult.Yes)
                {
                    DataRow _row = dgvUsuarios.CurrentRow.ToDataRow();
                    ModelosManager.CLS.Usuarios _user = new ModelosManager.CLS.Usuarios(_row);
                    if (_bd.Eliminar(_user) > 0)
                    {
                        IniciarControles();
                        this.Notificar(Extensiones._NOTIFICADORES.REGISTRO_ELIMINADO);
                    }
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                UI.UsuariosManagerEditor _editor = new UsuariosManagerEditor();
                _editor.doRefrescarFormularioExterno += IniciarControles;
                _editor.ShowDialog(this);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow _row = dgvUsuarios.CurrentRow.ToDataRow();
                ModelosManager.CLS.Usuarios _user = new ModelosManager.CLS.Usuarios(_row);
                UI.UsuariosManagerEditor _editor = new UsuariosManagerEditor(_user);
                _editor.doRefrescarFormularioExterno += IniciarControles;
                _editor.ShowDialog(this);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void Filtrar()
        {
            try
            {
                if (!string.IsNullOrEmpty(txbBuscador.Text))
                {
                    _bsusuarios.Filter = string.Format("IDUsuario LIKE '%{0}%'", txbBuscador.Text);
                }
                else
                {
                    _bsusuarios.RemoveFilter();
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void txbBuscador_TextChanged(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void cbbRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarPermisosPorRoles();
        }

        private void FiltrarPermisosPorRoles()
        {
            try
            {
                _bspermisos.Filter = string.Format("IDRol = {0}", cbbRoles.ComboBox.SelectedValue);
            }
            catch (Exception _err)
            {
                _bspermisos.RemoveFilter();
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnAgregarPermiso_Click(object sender, EventArgs e)
        {
            try
            {
                int _idrol = cbbRoles.ComboBox.SelectedValue.TextoToEntero();
                DataRow _row = dgvComandos.CurrentRow.ToDataRow();

                ModelosManager.CLS.UsuariosPermisos _nuevo = new ModelosManager.CLS.UsuariosPermisos();
                _nuevo.IDComando.Valor = _row["IDComando"];
                _nuevo.IDRol.Valor = cbbRoles.ComboBox.SelectedValue.TextoToEntero();
                _nuevo.IDPermiso.Valor = 0;

                if (_bd.Insertar(_nuevo) > 0)
                {
                    Actualizar(_MODOS.PERMISOS);
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnQuitarPermiso_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Está seguro de quitar éste permiso?", "PERMISOS", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    DataRow _row = dgvPermisos.CurrentRow.ToDataRow();
                    ModelosManager.CLS.UsuariosPermisos _permiso = new ModelosManager.CLS.UsuariosPermisos(_row);
                    if (_bd.Eliminar(_permiso) > 0)
                    {
                        Actualizar(_MODOS.PERMISOS);
                    }
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            IniciarControles();
        }
    }
}
