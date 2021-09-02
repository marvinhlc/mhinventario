using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Herramientas;

namespace VistasManager.UI
{
    public partial class GastosControlClasificaciones : Estilos.FormEditores
    {
        //DELEGADO PARA OPERACIONES EXTERNAS
        public delegate void EnviarExterno(ModelosManager.CLS.GastosClasificaciones _seleccionado);
        public event EnviarExterno doEnviarExterno;

        Sesion.CLS.OmniSesion _sesion = Sesion.CLS.OmniSesion.Instancia;
        ModelosManager.CLS.GastosClasificaciones _clasificaciones = new ModelosManager.CLS.GastosClasificaciones();
        DataTable _dtclasificaciones = new DataTable();
        BindingSource _bsclasificaciones = new BindingSource();

        EntityManager.DataBase _db = new EntityManager.DataBase();

        public GastosControlClasificaciones()
        {
            InitializeComponent();
            Iniciar();
        }

        public void Iniciar()
        {
            try
            {
                _dtclasificaciones = _clasificaciones.Todo();
                _bsclasificaciones.DataSource = _dtclasificaciones;
                dgvDatos.AutoGenerateColumns = false;
                dgvDatos.DataSource = _bsclasificaciones;
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvDatos.Columns[e.ColumnIndex].Name.Equals("Acciones"))
                {
                    DataRow _row = dgvDatos.CurrentRow.ToDataRow();
                    ModelosManager.CLS.GastosClasificaciones _seleccionado = new ModelosManager.CLS.GastosClasificaciones(_row);
                    if (doEnviarExterno != null)
                        doEnviarExterno(_seleccionado);
                    Close();
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            Iniciar();
        }

        private void txbBuscarTexto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _bsclasificaciones.Filter = string.Format("Descripcion LIKE '%{0}%'", txbBuscarTexto.Text);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void txbBuscarTexto_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    AgregarNuevo();
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void dgvDatos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                if (_bsclasificaciones.List.Count == 0)
                    btnAgregar.Visible = true;
                else
                    btnAgregar.Visible = false;
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarNuevo();
        }

        private void AgregarNuevo()
        {
            try
            {
                if (_bsclasificaciones.List.Count == 0)
                {
                    int _id = 0;
                    ModelosManager.CLS.GastosClasificaciones _nuevo = new ModelosManager.CLS.GastosClasificaciones();
                    _nuevo.Descripcion.Valor = txbBuscarTexto.Text;
                    _id = _db.Insertar(_nuevo);
                    if (_id > 0)
                    {
                        Iniciar();
                    }
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void dgvDatos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int _id = 0;
                DataRow _row = dgvDatos.CurrentRow.ToDataRow();
                ModelosManager.CLS.GastosClasificaciones _registro = new ModelosManager.CLS.GastosClasificaciones(_row);
                _id = _db.Actualizar(_registro);
                if (_id > 0)
                    Iniciar();
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void dgvDatos_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dgvDatos.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void btnEliminarItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_sesion.USUARIO.Kerveros(Sesion.CLS.Comandos.GASTOS_ELIMINAR, true))
                {
                    CLS.ExtensionesLocales.EliminarRegistro(dgvDatos, _clasificaciones, Iniciar);
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

    }
}
