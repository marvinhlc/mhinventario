using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Herramientas;

namespace VistasManager.UI
{
    public partial class OrdenesImagenes : Estilos.FormMantenimiento
    {
        Sesion.CLS.OmniSesion _sesion = Sesion.CLS.OmniSesion.Instancia;
        ModelosManager.CLS.Ordenes _costura = new ModelosManager.CLS.Ordenes();
        ModelosManager.CLS.OrdenesImagenes _imagenes = new ModelosManager.CLS.OrdenesImagenes();

        DataTable _dtimagenes = new DataTable();
        BindingSource _bsimagenes = new BindingSource();

        EntityManager.DataBase _datos = new EntityManager.DataBase();

        int _idorden = 0;

        public OrdenesImagenes(int _pidorden = 0)
        {
            _idorden = _pidorden;
            _costura = new ModelosManager.CLS.Ordenes(_idorden);
            InitializeComponent();
            Iniciar();
        }

        private void Iniciar()
        {
            try
            {
                _dtimagenes = _costura.Imagenes();
                _bsimagenes.DataSource = _dtimagenes;

                dgvDetalle.AutoGenerateColumns = false;
                dgvDetalle.DataSource = _bsimagenes;
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            CapturarArchivoImagen();
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
                        ModelosManager.CLS.OrdenesImagenes _img = new ModelosManager.CLS.OrdenesImagenes();
                        _img.IDOrden.Valor = _idorden;
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

        private void btnEliminarImagen_Click(object sender, EventArgs e)
        {
            EliminarArchivoImagen();
        }

        private void EliminarArchivoImagen()
        {
            try
            {
                CLS.ExtensionesLocales.EliminarRegistro(dgvDetalle, _imagenes, Iniciar);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
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
