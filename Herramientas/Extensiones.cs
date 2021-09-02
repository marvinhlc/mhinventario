using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Configuration;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Herramientas
{
    public static class Extensiones
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

        private const uint WM_SYSKEYDOWN = 0x104;

        public static Int32 Edad(this DateTime pFecha)
        {
            Int32 EdadAnyos = 0;
            EdadAnyos =DateTime.Today.AddTicks(-pFecha.Ticks).Year - 1;
            //EdadAnyos =Convert.ToInt32( (DateTime.Today -pFecha));
            //DateTime dat = Convert.ToDateTime(fnac);
            //DateTime nacimiento = new DateTime(dat.Year, dat.Month, dat.Day);
            //int edad = DateTime.;
            //return edad.ToString();

            return EdadAnyos;
        }

        public static List<T> GetControls<T>(this Control container) where T : Control
        {
            List<T> controls = new List<T>();
            foreach (Control c in container.Controls)
            {
                if (c is T)
                    controls.Add((T)c);
                controls.AddRange(GetControls<T>(c));
            }
            return controls;
        }

        #region BUTTONS
        public static string CallSaveFileDialog(this Button _control)
        {
            string _retorno = string.Empty;

            try
            {
                SaveFileDialog _dialogo = new SaveFileDialog();
                if (_dialogo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    _retorno = _dialogo.FileName.ToString();
                }
            }
            catch
            {
                _retorno = string.Empty;
            }

            return _retorno;
        }
        public static string CallOpenFileDialog(this Button _control)
        {
            string _retorno = string.Empty;

            try
            {
                OpenFileDialog _dialogo = new OpenFileDialog();
                if (_dialogo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    _retorno = _dialogo.FileName.ToString();
                }
            }
            catch
            {
                _retorno = string.Empty;
            }

            return _retorno;
        }
        #endregion

        #region STRING
        public static void ToMonto(this TextBox _control, Object _monto)
        {
            try
            {
                _control.Text = Convert.ToDouble(_monto).ToString("N2");
            }
            catch
            {
                _control.Clear();
            }
        }

        public static bool NoNOE(this string _str)
        {
            bool _ok = false;
            try
            {
                _ok = !string.IsNullOrEmpty(_str);
            }
            catch
            {
                _ok = false;
            }
            return _ok;
        }

        public static bool EsNOE(this string _str)
        {
            bool _ok = false;
            try
            {
                _ok = string.IsNullOrEmpty(_str);
            }
            catch
            {
                _ok = false;
            }
            return _ok;
        }

        public static string Separador(this string[] _str)
        {
            StringBuilder _cadena = new StringBuilder();
            bool _primera = true;

            foreach (string _item in _str)
            {
                if (_primera)
                {
                    _cadena.Append(string.Format("'{0}'", _item.Trim()));
                    _primera = false;
                }
                else
                {
                    _cadena.Append(string.Format(",'{0}'", _item.Trim()));
                }
            }

            return _cadena.ToString();
        }
        public static int TextoToEntero(this string _str)
        {
            int _valor = 0;
            try
            {
                _valor = Convert.ToInt32(_str);
            }
            catch
            {
                _valor = 0;
            }
            return _valor;
        }
        public static double TextoToDouble(this string _str)
        {
            double _valor = 0;
            try
            {
                _valor = Convert.ToDouble(_str);
            }
            catch
            {
                _valor = 0;
            }
            return _valor;
        }
        #endregion

        #region DATETIMEPICKER
        public static void Open(this DateTimePicker obj)
        {
            SendMessage(obj.Handle, WM_SYSKEYDOWN, (int)Keys.Down, 0);
        }

        public static void Hoy(this DateTimePicker _dtp)
        {
            try
            {
                _dtp.Value = DateTime.Now;
            }
            catch
            {
                //nada
            }
        }
        public static DateTime UltimoDiaMes(this DateTimePicker _dtp)
        {
            DateTime _fecha = new DateTime();
            DateTime _fechainicio = new DateTime();
            try
            {
                _fechainicio = _dtp.Value;
                _fecha = new DateTime(_fechainicio.Year, _fechainicio.Month, DateTime.DaysInMonth(_fechainicio.Year, _fechainicio.Month));
            }
            catch
            {
                _fecha = DateTime.Now;
            }
            return _fecha;
        }
        public static string FechaParaMySQL(this DateTimePicker _dtp)
        {
            string _cadena = string.Empty;
            try
            {
                DateTime _fecha = Convert.ToDateTime(_dtp.Value.ToShortDateString());
                _cadena = _fecha.ToString("yyyy-MM-dd");
            }
            catch
            {
                _cadena = string.Empty;
            }
            return _cadena;
        }
        public static string FechaFormatoLocal(this DateTimePicker _dtp)
        {
            string _cadena = string.Empty;
            try
            {
                DateTime _fecha = Convert.ToDateTime(_dtp.Value.ToShortDateString());
                _cadena = _fecha.ToString("dd-MM-yyyy");
            }
            catch
            {
                _cadena = string.Empty;
            }
            return _cadena;
        }
        #endregion

        #region TOOLSTRIPTEXTBOX
        public static void ToZeroDouble(this ToolStripTextBox _txb)
        {
            int _cero = 0;
            try
            {
                _txb.Text = _cero.ToString("N2");
            }
            catch
            {
                _txb.Text = string.Empty;
            }
        }
        public static void ToZero(this ToolStripTextBox _txb)
        {
            int _cero = 0;
            try
            {
                _txb.Text = _cero.ToString("N0");
            }
            catch
            {
                _txb.Text = string.Empty;
            }
        }
        #endregion

        #region TEXTBOX
        public static void ToZeroDouble(this TextBox _txb)
        {
            int _cero = 0;
            try
            {
                _txb.Text = _cero.ToString("N2");
            }
            catch
            {
                _txb.Text = string.Empty;
            }
        }
        public static void ToZero(this TextBox _txb)
        {
            int _cero = 0;
            try
            {
                _txb.Text = _cero.ToString("N0");
            }
            catch
            {
                _txb.Text = string.Empty;
            }
        }
        public static int TextoToEntero(this TextBox _txb)
        {
            int _valor = 0;
            try
            {
                _valor = Convert.ToInt32(_txb.Text);
            }
            catch
            {
                _valor = 0;
            }
            return _valor;
        }
        public static double TextoToDouble(this TextBox _txb)
        {
            double _valor = 0;
            try
            {
                _valor = Convert.ToDouble(_txb.Text);
            }
            catch
            {
                _valor = 0;
            }
            return _valor;
        }
        #endregion

        #region DATETIME
        public static string FechaParaMySQL(this DateTime _dt)
        {
            string _cadena = string.Empty;
            try
            {
                DateTime _fecha = _dt;
                _cadena = _fecha.ToString("yyyy-MM-dd");
            }
            catch
            {
                _cadena = string.Empty;
            }
            return _cadena;
        }
        #endregion

        #region TOOLSTRIPTEXTBOX
        public static int TextoToEntero(this ToolStripTextBox _txb)
        {
            int _valor = 0;
            try
            {
                _valor = Convert.ToInt32(_txb.Text);
            }
            catch
            {
                _valor = 0;
            }
            return _valor;
        }
        #endregion

        #region OBJECT
        public static int ToEntero(this object _obj)
        {
            int _valor = 0;
            try
            {
                _valor = Convert.ToInt32(_obj);
            }
            catch
            {
                _valor = 0;
            }
            return _valor;
        }
        public static double ToDouble(this object _obj)
        {
            double _valor = 0;
            try
            {
                _valor = Convert.ToDouble(_obj);
            }
            catch
            {
                _valor = 0;
            }
            return _valor;
        }
        public static string ToFormatDouble(this object _obj)
        {
            double _valor = 0;
            string _formateo = string.Empty;

            try
            {
                _valor = Convert.ToDouble(_obj);
                _formateo = string.Format("{0:N2}", _valor);
            }
            catch (Exception _err)
            {
                _valor = 0;
                _formateo = "0.00";
            }
            return _formateo;
        }
        public static byte[] ImageToBytes(this Image img)
        {
            byte[] _bytes = null;
            try
            {
                ImageConverter _conversor = new ImageConverter();
                _bytes = _conversor.ConvertTo(img, typeof(byte[])) as byte[];
            }
            catch
            {
                //nada
            }
            return _bytes;
        }
        public static double ToDoubleIfNull(this object _obj)
        {
            double _valor = 0;
            try
            {
                _valor = Convert.ToDouble(_obj);
            }
            catch (Exception _err)
            {
                _valor = 0;
            }
            return _valor;
        }
        public static byte[] ToBytes(this object hex)
        {
            byte[] _bytes = null;
            try
            {
                _bytes = (byte[])hex;
            }
            catch
            {
                //nada
            }
            return _bytes;
        }
        //public static byte[] StringToByteArray(this object hex)
        //{
        //    var bytes = new byte[1];
        //    try
        //    {
        //        int numberChars = hex.ToString().Length;
        //        bytes = new byte[numberChars / 2];
        //        for (int i = 0; i < numberChars; i += 2)
        //            bytes[i / 2] = Convert.ToByte(hex.ToString().Substring(i, 2), 16);
        //    }
        //    catch
        //    {
        //        //nada
        //    }
        //    return bytes;
        //}
        public static int TextoToEntero(this Object _obj)
        {
            int _valor = 0;
            try
            {
                _valor = Convert.ToInt32(_obj);
            }
            catch
            {
                _valor = 0;
            }
            return _valor;
        }
        public static double TextoToDouble(this Object _obj)
        {
            double _valor = 0;
            try
            {
                _valor = Convert.ToDouble(_obj);
            }
            catch
            {
                _valor = 0;
            }
            return _valor;
        }
        public static string FechaParaMySQL(this Object _obj)
        {
            string _cadena = string.Empty;
            try
            {
                DateTime _fecha = Convert.ToDateTime(_obj.ToString());
                _cadena = _fecha.ToString("yyyy-MM-dd");
            }
            catch
            {
                _cadena = string.Empty;
            }
            return _cadena;
        }
        public static string CeroToTexto(this Object _obj)
        {
            string _valor = string.Empty;
            int _cero = 0;
            TextBox _texb;
            try
            {
                _texb = (TextBox)_obj;
                _texb.Text = _cero.ToString("N2");
            }
            catch
            {
                _valor = string.Empty;
            }
            return _valor;
        }
        #endregion

        #region AUTO-CARGADORES
        public static void Conexiones(this ComboBox _control)
        {
            string[] _conexiones = new string[ConfigurationManager.ConnectionStrings.Count];
            int _index = 0;
            foreach (ConnectionStringSettings _item in ConfigurationManager.ConnectionStrings)
            {
                _conexiones[_index] = _item.Name.ToString();
                _index++;
            }

            //for (int i = 0; i < ConfigurationManager.ConnectionStrings.Count; i++)
            //{
            //    _conexiones[i] = ConfigurationManager.ConnectionStrings[i].Name.ToString();
            //}
            try
            {
                _control.DropDownStyle = ComboBoxStyle.DropDownList;
                _control.DataSource = _conexiones;
                _control.SelectedIndex = 0;
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        public static void ClasificacionPrecio(this ComboBox _control)
        {
            string[] _relleno = { "PRECIO 1", "PRECIO 2", "PRECIO 3", "PRECIO 4", "N/A" };
            try
            {
                _control.DropDownStyle = ComboBoxStyle.DropDownList;
                _control.DataSource = _relleno;
                _control.SelectedIndex = 3;
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        public static void TipoDocumento(this ComboBox _control)
        {
            string[] _relleno = { "CONSUMIDOR FINAL","CREDITO FISCAL","TICKET" };
            try
            {
                _control.DropDownStyle = ComboBoxStyle.DropDownList;
                _control.DataSource = _relleno;
                _control.SelectedIndex = 1;
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        public static void FormaPago(this ComboBox _control)
        {
            string[] _relleno = { "CONTADO", "CREDITO", "N/A" };
            try
            {
                _control.DropDownStyle = ComboBoxStyle.DropDownList;
                _control.DataSource = _relleno;
                _control.SelectedIndex = 0;
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        public static void EstadoAbiertoCerrado(this ComboBox _control)
        {
            string[] _relleno = { "ABIERTO", "CERRADO" };
            try
            {
                _control.DropDownStyle = ComboBoxStyle.DropDownList;
                _control.DataSource = _relleno;
                _control.SelectedIndex = 0;
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        public static void TipoTitular(this ComboBox _control)
        {
            string[] _relleno = {"GRANDE","MEDIANO","PEQUEÑO","CONSUMIDOR"};
            try
            {
                _control.DropDownStyle = ComboBoxStyle.DropDownList;
                _control.DataSource = _relleno;
                _control.SelectedIndex = 2;
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        public static void RolTitular(this ComboBox _control)
        {
            string[] _relleno = { "PROVEEDOR", "CLIENTE" };
            try
            {
                _control.DropDownStyle = ComboBoxStyle.DropDownList;
                _control.DataSource = _relleno;
                _control.SelectedIndex = 0;
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        public static void ReglaSiNo(this ComboBox _control)
        {
            string[] _relleno = { "SI", "NO" };
            try
            {
                _control.DropDownStyle = ComboBoxStyle.DropDownList;
                _control.DataSource = _relleno;
                _control.SelectedIndex = 1;
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }
        #endregion

        #region CONTROLES
        public enum _BARRA_ESTADO
        {
            DEFAULT,
            TOTAL_REGISTROS,
            NUMERO_REGISTROS_ENCONTRADOS,
            PERSONALIZADO
        }

        public static void NotificarEstado(this StatusStrip _control, _BARRA_ESTADO _pformato, object _pvalor = null)
        {
            StringBuilder _notificacion = new StringBuilder();
            try
            {
                switch (_pformato)
                {
                    case _BARRA_ESTADO.DEFAULT:
                        _notificacion.Append("Todo esta ok.");
                        break;
                    case _BARRA_ESTADO.TOTAL_REGISTROS:
                        _notificacion.AppendFormat("Total registros: {0}", _pvalor.ToString());
                        break;
                    case _BARRA_ESTADO.NUMERO_REGISTROS_ENCONTRADOS:
                        _notificacion.AppendFormat("{0} registros encontrados", _pvalor.ToString());
                        break;
                    case _BARRA_ESTADO.PERSONALIZADO:
                        _notificacion.Append(_pvalor.ToString());
                        break;
                }
                _control.Items[0].Text = _notificacion.ToString();
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        public static bool Saltar(this Control _control, KeyEventArgs e)
        {
            bool _ok = false;
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SendKeys.Send("{TAB}");
                    _ok = true;
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
            return _ok;
        }
        #endregion

        #region FORMS
        public enum _NOTIFICADORES
        {
            DEFAULT,
            REGISTRO_GUARDADO,
            REGISTRO_NO_GUARDADO,
            REGISTRO_ELIMINADO,
            CONFIRME_ELIMINAR_REGISTRO,
            CONFIFME_GUARDAR_REGISTRO,
            PERSONALIZADO
        }
        public static DialogResult Notificar(this Form _form, _NOTIFICADORES _pestilo, string _pmensaje = "")
        {
            StringBuilder _notificacion = new StringBuilder();
            DialogResult _resultado = DialogResult.Ignore;
            try
            {
                switch (_pestilo)
                {
                    case _NOTIFICADORES.PERSONALIZADO:
                        MessageBox.Show(_pmensaje, "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case _NOTIFICADORES.DEFAULT:
                        _notificacion.Append("Todo esta ok.");
                        MessageBox.Show(_notificacion.ToString(), "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case _NOTIFICADORES.REGISTRO_GUARDADO:
                        _notificacion.Append("Registro fué guardado satisfactoriamente!");
                        MessageBox.Show(_notificacion.ToString(), "GUARDAR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case _NOTIFICADORES.REGISTRO_NO_GUARDADO:
                        _notificacion.Append("UPS!, registro no fué guardado!");
                        MessageBox.Show(_notificacion.ToString(), "GUARDAR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case _NOTIFICADORES.REGISTRO_ELIMINADO:
                        _notificacion.Append("Registro fué eliminado correctamente!");
                        MessageBox.Show(_notificacion.ToString(), "ELIMINAR", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case _NOTIFICADORES.CONFIRME_ELIMINAR_REGISTRO:
                        _notificacion.Append("¿Está seguro de eliminar el registro?");
                        _resultado = MessageBox.Show(_notificacion.ToString(), "ELIMINAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        break;
                    case _NOTIFICADORES.CONFIFME_GUARDAR_REGISTRO:
                        _notificacion.Append("¿Desea guardar el registro?");
                        _resultado = MessageBox.Show(_notificacion.ToString(), "GUARDAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        break;
                    default: 
                        _resultado = DialogResult.Ignore;
                        break;
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }

            return _resultado;
        }
        #endregion

        #region DATAGRIDVIEWROW
        public static DataRow Notificar(this DataGridView _grid, StatusStrip _barra)
        {
            DataRow _valor = null;
            try
            {
                _barra.Items[0].Text = string.Format("{0} registros", _grid.Rows.Count);
            }
            catch
            {
                _valor = null;
            }
            return _valor;
        }

        public static DataRow ToDataRow(this DataGridViewRow _obj)
        {
            DataRow _valor = null;
            try
            {
                _valor = ((DataRowView)_obj.DataBoundItem).Row;
            }
            catch
            {
                _valor = null;
            }
            return _valor;
        }

        public static string ToValoresSeparadosPorComas(this List<DataGridViewRow> pOrigen, string pCampo)
        {
            StringBuilder _st = new StringBuilder();

            try
            {
                Boolean Primera = true;
                Boolean Vacia = true;
                _st.Append("(");
                foreach (DataGridViewRow Fila in pOrigen)
                {
                    try
                    {
                        DataGridViewCheckBoxCell cellSelecion = Fila.Cells["Marcar"] as DataGridViewCheckBoxCell;
                        if (Convert.ToBoolean(Convert.ToInt32(cellSelecion.Value)))
                        {
                            if (Primera)
                            {
                                if (Fila.Cells[pCampo].ValueType == typeof(string))
                                {
                                    _st.Append(string.Format("'{0}'", Fila.Cells[pCampo].Value.ToString()));
                                }
                                else
                                {
                                    _st.Append(Fila.Cells[pCampo].Value.ToString());
                                }
                                Primera = false;
                            }
                            else
                            {
                                if (Fila.Cells[pCampo].ValueType == typeof(string))
                                {
                                    _st.Append(string.Format(",'{0}'", Fila.Cells[pCampo].Value.ToString()));
                                }
                                else
                                {
                                    _st.Append("," + Fila.Cells[pCampo].Value.ToString());
                                }
                            }
                        }
                        Vacia = false;
                    }
                    catch (Exception)
                    {
                        Vacia = true;
                    }
                }
                _st.Append(")");
                if (Vacia)
                {
                    _st.Clear();
                }
            }
            catch
            {
                _st.Clear();
            }
            return _st.ToString();
        }

        public static string ToValoresSeparadosPorComas(this List<DataGridViewRow> pOrigen)
        {
            StringBuilder _st = new StringBuilder();

            try
            {
                Boolean Primera = true;
                Boolean Vacia = true;
                _st.Append("(");
                foreach (DataGridViewRow Fila in pOrigen)
                {
                    try
                    {
                        if (Primera)
                        {
                            if (Fila.Cells[0].ValueType == typeof(string))
                            {
                                _st.Append(string.Format("'{0}'", Fila.Cells[0].Value.ToString()));
                            }
                            else
                            {
                                _st.Append(Fila.Cells[0].Value.ToString());
                            }
                            Primera = false;
                        }
                        else
                        {
                            if (Fila.Cells[0].ValueType == typeof(string))
                            {
                                _st.Append(string.Format(",'{0}'", Fila.Cells[0].Value.ToString()));
                            }
                            else
                            {
                                _st.Append("," + Fila.Cells[0].Value.ToString());
                            }
                        }

                        Vacia = false;
                    }
                    catch (Exception)
                    {
                        Vacia = true;
                    }
                }
                
                _st.Append(")");

                if (Vacia)
                {
                    _st.Clear();
                }
            }
            catch
            {
                _st.Clear();
            }
            return _st.ToString();
        }
        #endregion

        #region DATAGRIDVIEW
        public static void ToNextColumna(this DataGridView _grid, DataGridViewCell _pcurrentcell = null)
        {
            int _col = 0;
            int _row = 0;
            DataGridViewCell _currentcell = null;

            try
            {
                if (_pcurrentcell != null)
                    _currentcell = _pcurrentcell;
                else
                    _currentcell = _grid.CurrentCell;

                _col = _currentcell.ColumnIndex;
                _row = _currentcell.RowIndex;
                if (_col != (_grid.Columns.Count - 1))
                {
                    _grid.CurrentCell = _grid[_col + 1, _row];
                }
            }
            catch
            {
                //nada
            }
        }

        public static double Totalizar(this DataGridView _grid, string _key = "")
        {
            double _total = 0;
            try
            {
                List<DataGridViewRow> _grows = (from item in _grid.Rows.Cast<DataGridViewRow>()
                                                where Convert.ToDouble(item.Cells[_key].Value) > 0 
                                                select item).ToList<DataGridViewRow>();
                foreach (DataGridViewRow _row in _grows)
                {
                    _total += _row.Cells[_key].Value.TextoToDouble();
                }
                _total += 0;
            }
            catch
            {
                _total = 0;
            }
            return _total;
        }

        public static int ExistenFilas(this DataGridView _grid)
        {
            int _filas = 0;
            try
            {
                List<DataGridViewRow> _grows = (from item in _grid.Rows.Cast<DataGridViewRow>()
                                                select item).ToList<DataGridViewRow>();
                _filas = _grows.Count;
            }
            catch
            {
                _filas = 0;
            }
            return _filas;
        }
        public static int ExistenFilasEditadas(this DataGridView _grid, string _pcolumna = "")
        {
            int _filas = 0;
            try
            {
                List<DataGridViewRow> _grows = (from item in _grid.Rows.Cast<DataGridViewRow>()
                                                where Convert.ToDouble(item.Cells[_pcolumna].Value) > 0
                                                select item).ToList<DataGridViewRow>();
                _filas = _grows.Count;
            }
            catch
            {
                _filas = 0;
            }
            return _filas;
        }
        #endregion

        #region CRISTAL REPORT
        public static void ToPDF(this CrystalDecisions.CrystalReports.Engine.ReportClass _repo, Form _win)
        {
            try
            {
                string _file = string.Empty;
                SaveFileDialog _dialogo = new SaveFileDialog();
                _dialogo.Filter = "PDF Portable Document Format|*.pdf";
                _dialogo.Title = "Guardar archivo";
                if (_dialogo.ShowDialog(_win) == System.Windows.Forms.DialogResult.OK)
                {
                    _file = _dialogo.FileName.ToString();
                }
                if (_file.NoNOE())
                {
                    _repo.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, _file);
                    _repo.Close();
                    MessageBox.Show("Exportación finalizada correctamente", "EXPORTAR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception _err)
            {
                MessageBox.Show(_err.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void ToExcel(this CrystalDecisions.CrystalReports.Engine.ReportClass _repo, Form _win)
        {
            try
            {
                string _file = string.Empty;
                SaveFileDialog _dialogo = new SaveFileDialog();
                _dialogo.Filter = "Xls Excel|*.xls";
                _dialogo.Title = "Guardar archivo";
                if (_dialogo.ShowDialog(_win) == System.Windows.Forms.DialogResult.OK)
                {
                    _file = _dialogo.FileName.ToString();
                }
                if (_file.NoNOE())
                {
                    _repo.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.Excel, _file);
                    _repo.Close();
                    MessageBox.Show("Exportación finalizada correctamente", "EXPORTAR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch(Exception _err)
            {
                MessageBox.Show(_err.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void ToPDF(this CrystalDecisions.CrystalReports.Engine.ReportClass _repo, UserControl _win)
        {
            try
            {
                string _file = string.Empty;
                SaveFileDialog _dialogo = new SaveFileDialog();
                _dialogo.Filter = "PDF Portable Document Format|*.pdf";
                _dialogo.Title = "Guardar archivo";
                if (_dialogo.ShowDialog(_win) == System.Windows.Forms.DialogResult.OK)
                {
                    _file = _dialogo.FileName.ToString();
                }
                if (_file.NoNOE())
                {
                    _repo.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, _file);
                    _repo.Close();
                    MessageBox.Show("Exportación finalizada correctamente", "EXPORTAR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception _err)
            {
                MessageBox.Show(_err.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void ToExcel(this CrystalDecisions.CrystalReports.Engine.ReportClass _repo, UserControl _win)
        {
            try
            {
                string _file = string.Empty;
                SaveFileDialog _dialogo = new SaveFileDialog();
                _dialogo.Filter = "Xls Excel|*.xls";
                _dialogo.Title = "Guardar archivo";
                if (_dialogo.ShowDialog(_win) == System.Windows.Forms.DialogResult.OK)
                {
                    _file = _dialogo.FileName.ToString();
                }
                if (_file.NoNOE())
                {
                    _repo.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.Excel, _file);
                    _repo.Close();
                    MessageBox.Show("Exportación finalizada correctamente", "EXPORTAR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception _err)
            {
                MessageBox.Show(_err.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

    }
}
