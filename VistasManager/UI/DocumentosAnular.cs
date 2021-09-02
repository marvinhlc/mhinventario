using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Herramientas;
using EntityManager;

namespace VistasManager.UI
{
    public partial class DocumentosAnular : Estilos.FormDialogos
    {
        Sesion.CLS.OmniSesion _sesion = Sesion.CLS.OmniSesion.Instancia;
        ModelosManager.CLS.DocumentosEncabezados _documento = new ModelosManager.CLS.DocumentosEncabezados();
        ModelosManager.CLS.DocumentosDetalle _detalle = new ModelosManager.CLS.DocumentosDetalle();

        CLS.ListaVentas _ventas = new CLS.ListaVentas();

        public DocumentosAnular()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarDocumento();
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            AnularDocumento();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BuscarDocumento();
            }
        }

        private void BuscarDocumento()
        {
            DataTable _tabla = new DataTable();

            try
            {
                dgvDetalle.DataSource = null;

                _documento = new ModelosManager.CLS.DocumentosEncabezados(txbNumero.Text, _sesion.CONFIGAPP.PERIODO.TextoToEntero());
                if (_documento.Existe)
                {
                    _detalle = new ModelosManager.CLS.DocumentosDetalle();
                    _tabla = _detalle.DetalleDocumentosPorIDDocumento(_documento.IDDocumento.Valor.TextoToEntero());
                    if (_tabla.Rows.Count > 0)
                    {
                        _ventas.Clear();
                        CLS.ItemVentas _item = null;
                        foreach (DataRow _row in _tabla.Rows)
                        {
                            _item = new CLS.ItemVentas(_row);
                            _ventas.Add(_item);
                        }

                        dgvDetalle.AutoGenerateColumns = false;
                        dgvDetalle.DataSource = _ventas;
                    }
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void dgvDetalle_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            double _total = 0;
            int _items = 0;

            try
            {
                foreach (DataGridViewRow _row in dgvDetalle.Rows)
                {
                    CLS.ItemVentas _item = _row.DataBoundItem as CLS.ItemVentas;
                    _total = _total + (_item.Total);
                    _items++;
                }

                lbltotal.Text = string.Format("Total ${0}", _total);
                lblitems.Text = string.Format("{0} items", _items);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void AnularDocumento()
        {
            try
            {
                if (MessageBox.Show("¿Está seguro de anular el documento?", "ANULAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (_documento.Existe)
                    {
                        if (_documento.Anular())
                        {
                            MessageBox.Show("Documento ha sido anulado correctamente", "ANULAR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            Close();
                        }
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
