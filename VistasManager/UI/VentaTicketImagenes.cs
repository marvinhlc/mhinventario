using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Herramientas;

namespace VistasManager.UI
{
    public partial class VentaTicketImagenes : Estilos.FormMantenimiento
    {
        Sesion.CLS.OmniSesion _sesion = Sesion.CLS.OmniSesion.Instancia;
        ModelosManager.CLS.DocumentosImagenes _galeria = new ModelosManager.CLS.DocumentosImagenes();
        ModelosManager.CLS.DocumentosEncabezados _documentos = new ModelosManager.CLS.DocumentosEncabezados();

        DataTable _dtimagenes = new DataTable();
        BindingSource _bsimagenes = new BindingSource();

        EntityManager.DataBase _datos = new EntityManager.DataBase();

        int _iddocumento = 0;
        bool _noeditable = false;

        public VentaTicketImagenes(int _piddoc)
        {
            _iddocumento = _piddoc;
            _documentos = new ModelosManager.CLS.DocumentosEncabezados(_iddocumento);
            _noeditable = true;
            InitializeComponent();
            Iniciar();
        }

        public VentaTicketImagenes()
        {
            InitializeComponent();
            Iniciar();
        }

        private void Iniciar()
        {
            try
            {
                if (_noeditable)
                {
                    txbNumeroFactura.Text = _documentos.NumeroDocumento.Valor.ToString();
                    txbNumeroFactura.Enabled = false;
                    btnBuscar.Enabled = false;
                }
                else
                {
                    txbNumeroFactura.Enabled = true;
                    btnBuscar.Enabled = true;
                }

                _dtimagenes = _galeria.ObtenerDatosPorIDDocumento(_iddocumento);
                _bsimagenes.DataSource = _dtimagenes;

                dgvDetalle.AutoGenerateColumns = false;
                dgvDetalle.DataSource = _bsimagenes;
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            CapturarArchivoImagen();
        }

        private void btnEliminarImagen_Click(object sender, EventArgs e)
        {
            EliminarArchivoImagen();
        }

        private void CapturarArchivoImagen()
        {
            int _conta = 0;
            try
            {
                OpenFileDialog _openFileDialog1 = new OpenFileDialog();
                _openFileDialog1.Title = "Seleccione una imagen";
                _openFileDialog1.Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF| All files (*.*)|*.*";  
                _openFileDialog1.Multiselect = true;
                if (_openFileDialog1.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    foreach (String _file in _openFileDialog1.FileNames)
                    {
                        Image _fichero = Image.FromFile(_file);
                        ModelosManager.CLS.DocumentosImagenes _img = new ModelosManager.CLS.DocumentosImagenes();
                        _img.IDDocumento.Valor = _iddocumento;
                        _img.Archivo.Valor = System.IO.Path.GetFileName(_file);
                        _img.Imagen.Valor = _fichero.ImageToBytes();
                        if (_datos.Insertar(_img) > 0)
                        {
                            _conta++;
                        }
                    }

                    Iniciar();
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void EliminarArchivoImagen()
        {
            try
            {
                CLS.ExtensionesLocales.EliminarRegistro(dgvDetalle, _galeria, Iniciar);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void dgvDetalle_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                pbImagen.Image = null;
                DataRow _row = dgvDetalle.CurrentRow.ToDataRow();
                Bitmap _bmp;
                using (MemoryStream _memoria = new MemoryStream(_row["Imagen"].ToBytes()))
                {
                    _bmp = new Bitmap(_memoria);
                    pbImagen.Image = _bmp;
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            LanzarBuscadorDocumentos();
        }

        private void LanzarBuscadorDocumentos()
        {
            try
            {
                BuscadorDocumentos _buscador = new BuscadorDocumentos(CLS.Enumeraciones.FILTRO_DOCUMENTO.VENTAS);
                _buscador.ShowDialog(this);
                if (_buscador.Documento.Existe)
                {
                    _documentos = _buscador.Documento;
                    _iddocumento = _documentos.IDDocumento.Valor.TextoToEntero();
                    txbNumeroFactura.Text = _iddocumento.ToString();
                    Iniciar();
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void txbNumeroFactura_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _documentos = new ModelosManager.CLS.DocumentosEncabezados(txbNumeroFactura.Text, _sesion.CONFIGAPP.PERIODO);
                if (_documentos.Existe)
                {
                    _iddocumento = _documentos.IDDocumento.Valor.TextoToEntero();
                    Iniciar();
                }
            }
        }

        private void dgvDetalle_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                lblNotificar.Text = string.Format("{0} imágenes", _bsimagenes.List.Count);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }
    }
}
