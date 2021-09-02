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
    public partial class DocumentosInventario : Estilos.FormMantenimiento
    {
        Sesion.CLS.OmniSesion _sesion = Sesion.CLS.OmniSesion.Instancia;
        EntityManager.DataBase _bd = new EntityManager.DataBase();
        DataTable _dtdocumentos = new DataTable();
        BindingSource _bsdocumentos = new BindingSource();
        DataTable _dtdetalle = new DataTable();
        BindingSource _bsdetalle = new BindingSource();

        ModelosManager.CLS.DocumentosEncabezados _documentos = new ModelosManager.CLS.DocumentosEncabezados();
        ModelosManager.CLS.DocumentosDetalle _detalle = new ModelosManager.CLS.DocumentosDetalle();

        CLS.Enumeraciones.OPERACION _operacion = CLS.Enumeraciones.OPERACION.ENTRADAS;
        int _periodo = 0;

        public DocumentosInventario()
        {
            _periodo = _sesion.CONFIGAPP.PERIODO;
            InitializeComponent();
            Iniciar();
        }

        private void Iniciar()
        {
            try
            {
                _dtdocumentos = _documentos.DocumentosInventario(_periodo);
                _bsdocumentos.DataSource = _dtdocumentos;

                dgvCatalogo.AutoGenerateColumns = false;
                dgvCatalogo.DataSource = _bsdocumentos;

                _dtdetalle = _detalle.DetalleDocumentosInventario(_periodo);
                _bsdetalle.DataSource = _dtdetalle;
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void txbBuscarTexto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _bsdocumentos.Filter = string.Format("NumeroDocumento LIKE '%{0}%'", txbBuscarTexto.Text);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_sesion.USUARIO.Kerveros(Sesion.CLS.Comandos.ELIMINAR_DETALLE_DOCUMENTO_INVENTARIO, true))
                {
                    CLS.ExtensionesLocales.EliminarRegistro(dgvCatalogo, _documentos, Iniciar);
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void dgvCatalogo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                dgvCatalogo.Notificar(BarraEstado);
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            _operacion = CLS.Enumeraciones.OPERACION.ENTRADAS;
            Iniciar();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            _operacion = CLS.Enumeraciones.OPERACION.SALIDAS;
            Iniciar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                DocumentosInventarioEditor _editor = new DocumentosInventarioEditor();
                _editor.doRefrescarFormularioExterno += Iniciar;
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
                DataRow _row = dgvCatalogo.CurrentRow.ToDataRow();
                DocumentosInventarioGuardar _editor = new DocumentosInventarioGuardar(new ModelosManager.CLS.DocumentosEncabezados(_row));
                _editor.doRefrescarFormularioExterno += GuardarEncabezadoDocumento;
                _editor.ShowDialog(this);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private bool GuardarEncabezadoDocumento(ModelosManager.CLS.DocumentosEncabezados _docu)
        {
            bool _ok = false;
            try
            {
                _ok = (_bd.Actualizar(_docu) > 0);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
            finally
            {
                if (_ok)
                {
                    Iniciar();
                    MessageBox.Show("Documento fué guardado correctamente", "GUARDAR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            return _ok;
        }

        private void dgvCatalogo_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                dgvDetalle.DataSource = null;

                DataRow _row = dgvCatalogo.CurrentRow.ToDataRow();
                _bsdetalle.Filter = string.Format("IDDocumento = {0}", _row["IDDocumento"]);

                dgvDetalle.AutoGenerateColumns = false;
                dgvDetalle.DataSource = _bsdetalle;
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void dgvDetalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double _cantidad = 0;
            double _precio = 0;
            double _total = 0;
            try
            {
                DataGridViewRow _row = dgvDetalle.CurrentRow;

                _cantidad = _row.Cells["CantidadEntrada"].Value.TextoToDouble();
                _precio = _row.Cells["PrecioEntrada"].Value.TextoToDouble();
                _total = (_cantidad * _precio);
                _row.Cells["TotalDetalle"].Value = _total;

                int _id = _row.Cells["IDDetalleDocumento"].Value.TextoToEntero();
                ModelosManager.CLS.DocumentosDetalle _item = new ModelosManager.CLS.DocumentosDetalle(_id);
                if (_item.Existe)
                {
                    _item.CantidadEntrada.Valor = _cantidad;
                    _item.PrecioEntrada.Valor = _precio;
                    if (_bd.Actualizar(_item) > 0)
                    {
                        _dtdocumentos = _documentos.DocumentosInventario();
                        _bsdocumentos.DataSource = _dtdocumentos;
                    }
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void dgvDetalle_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (!dgvDetalle.IsCurrentCellDirty)
            {
                dgvDetalle.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (_sesion.USUARIO.Kerveros(Sesion.CLS.Comandos.ELIMINAR_DETALLE_DOCUMENTO_INVENTARIO, true))
                {
                    CLS.ExtensionesLocales.EliminarRegistro(dgvDetalle, _detalle, Iniciar);
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow _row = dgvCatalogo.CurrentRow.ToDataRow();
                DocumentosInventarioEditor _editor = new DocumentosInventarioEditor(_row["IDDocumento"].TextoToEntero());
                _editor.doRefrescarFormularioExterno += Iniciar;
                _editor.ShowDialog(this);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataRow _row = dgvCatalogo.CurrentRow.ToDataRow();
                _bsdetalle.Filter = string.Format("IDDocumento = {0} AND FullBusqueda LIKE '%{1}%'", _row["IDDocumento"].TextoToEntero(), txbFiltroDetalle.Text);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Esta seguro de limpiar (eliminar) el detalle del documento?", "LIMPIAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    DataRow _row = dgvCatalogo.CurrentRow.ToDataRow();
                    if (_detalle.LimpiarDetalle(_row["IDDocumento"].TextoToEntero()) > 0)
                    {
                        Iniciar();
                        MessageBox.Show("Documento fué limpiado correctamente", "LIMPIAR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

    }
}
