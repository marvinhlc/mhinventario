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
    public partial class BuscadorDocumentos : Estilos.FormDialogos
    {
        Sesion.CLS.OmniSesion _sesion = Sesion.CLS.OmniSesion.Instancia;
        DataTable _dtdocumentos = new DataTable();
        BindingSource _bsdocumentos = new BindingSource();
        ModelosManager.CLS.DocumentosEncabezados _documento = new ModelosManager.CLS.DocumentosEncabezados();

        public ModelosManager.CLS.DocumentosEncabezados Documento
        {
            get { return _documento; }
            set { _documento = value; }
        }

        private CLS.Enumeraciones.FILTRO_DOCUMENTO _tipo = CLS.Enumeraciones.FILTRO_DOCUMENTO.VENTAS;

        public BuscadorDocumentos(CLS.Enumeraciones.FILTRO_DOCUMENTO _ptipo = CLS.Enumeraciones.FILTRO_DOCUMENTO.VENTAS)
        {
            _tipo = _ptipo;
            InitializeComponent();
            Datos();
            Inicio();
        }

        private void Datos()
        {
            try
            {
                switch (_tipo)
                {
                    case CLS.Enumeraciones.FILTRO_DOCUMENTO.VENTAS:
                        _dtdocumentos = _documento.DocumentosVentasTodos(_sesion.CONFIGAPP.PERIODO);
                        break;
                    case CLS.Enumeraciones.FILTRO_DOCUMENTO.TIKET:
                        _dtdocumentos = _documento.DocumentosTicket(_sesion.CONFIGAPP.PERIODO);
                        break;
                    case CLS.Enumeraciones.FILTRO_DOCUMENTO.CONSUMIDOR_FINAL:
                        _dtdocumentos = _documento.DocumentosConsumidorFinal(_sesion.CONFIGAPP.PERIODO);
                        break;
                    case CLS.Enumeraciones.FILTRO_DOCUMENTO.CREDITO_FISCAL:
                        _dtdocumentos = _documento.DocumentosCreditoFiscal(_sesion.CONFIGAPP.PERIODO);
                        break;
                }

                _bsdocumentos.DataSource = _dtdocumentos;
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void Inicio()
        {
            try
            {
                dgvDocumentos.AutoGenerateColumns = false;
                dgvDocumentos.DataSource = _bsdocumentos;

                this.ActiveControl = txbBuscarTexto.Control;
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnRecargar_Click(object sender, EventArgs e)
        {
            Datos();
        }

        private void dgvDocumentos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                dgvDocumentos.Notificar(BarraEstado);
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

        private void txbBuscarTexto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                dgvDocumentos.Focus();
        }

        private void SeleccionarRegistro()
        {
            try
            {
                DataRow _row = dgvDocumentos.CurrentRow.ToDataRow();
                _documento = new ModelosManager.CLS.DocumentosEncabezados(_row["IDDocumento"].TextoToEntero());
                Close();
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void dgvDocumentos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SeleccionarRegistro();
        }

        private void dgvDocumentos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarRegistro();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            SeleccionarRegistro();
        }
    }
}
