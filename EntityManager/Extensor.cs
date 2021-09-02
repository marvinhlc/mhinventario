using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace EntityManager
{
    public static class Extensor
    {
        #region COMUNES
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
        #endregion

        #region MAPEADOR DE CONTROLES
        public static void Mapear(this Control pControl, Entidad _entidad)
        {
            try
            {
                foreach (Descriptor _item in _entidad.Columnas)
                {
                    try
                    {
                        switch (pControl.Controls[_item.Campo].GetType().Name)
                        {
                            case "TextBox":
                                TextBox _textbox = pControl.Controls[_item.Campo] as TextBox;
                                _textbox.Text = _item.Valor.ToString();
                                break;
                            case "DateTimePicker":
                                DateTimePicker _picker = pControl.Controls[_item.Campo] as DateTimePicker;
                                if (string.IsNullOrEmpty(_item.Valor.ToString()))
                                {
                                    _picker.Format = DateTimePickerFormat.Custom;
                                    _picker.CustomFormat = " ";
                                }
                                else
                                {
                                    _picker.Format = DateTimePickerFormat.Short;
                                    _picker.Value = Convert.ToDateTime(_item.Valor);
                                }
                                break;
                            case "ComboBox":
                                ComboBox _combo = pControl.Controls[_item.Campo] as ComboBox;
                                if (_item.Tipo == DataManager.TypeManager.Tipo.ENTERO || _item.Tipo == DataManager.TypeManager.Tipo.DOUBLE)
                                {
                                    _combo.SelectedValue = _item.Valor;
                                }
                                else
                                {
                                    _combo.Text = _item.Valor.ToString();
                                }
                                break;
                            case "NumericUpDown":
                                NumericUpDown _numero = pControl.Controls[_item.Campo] as NumericUpDown;
                                _numero.Value = Convert.ToDecimal(_item.Valor);
                                break;
                            default:
                                break;
                        }
                    }
                    catch
                    {
                        //ASUMIMOS QUE FALLA PORQUE NO ESTA MAPEADO, NO REGISTRAMOS FALLA EN LOG
                    }
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        public static void Sincronizar(this Control pControl, Entidad _entidad)
        {
            try
            {
                foreach (Descriptor _item in _entidad.Columnas)
                {
                    try
                    {
                        switch (pControl.Controls[_item.Campo].GetType().Name)
                        {
                            case "TextBox":
                                TextBox _textbox = pControl.Controls[_item.Campo] as TextBox;
                                _item.Valor = _textbox.Text;
                                break;
                            case "DateTimePicker":
                                DateTimePicker _picker = pControl.Controls[_item.Campo] as DateTimePicker;
                                _item.Valor = _picker.Value;
                                break;
                            case "ComboBox":
                                ComboBox _combo = pControl.Controls[_item.Campo] as ComboBox;
                                _item.Valor = _combo.SelectedValue;
                                break;
                            case "NumericUpDown":
                                NumericUpDown _number = pControl.Controls[_item.Campo] as NumericUpDown;
                                _item.Valor = _number.Value;
                                break;
                            default:
                                break;
                        }
                    }
                    catch (Exception _err)
                    {
                        Herramientas.Log.Registrar(_err.ToString());
                    }
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }
        #endregion

        #region AUTO-CARGADORES
        public static void Estado(this ComboBox _control, string _pkey = "Estado")
        {
            DataManager.Operacion _datos = new DataManager.Operacion();
            DataTable _tabla = new DataTable();

            try
            {
                _tabla.Columns.Add("Estado", typeof(string));
                _tabla.Rows.Add("ACTIVO");
                _tabla.Rows.Add("INACTIVO");

                _control.DropDownStyle = ComboBoxStyle.DropDownList;
                _control.DataSource = _tabla;
                _control.DisplayMember = "Estado";
                _control.ValueMember = _pkey;
                _control.SelectedIndex = 0;
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        public static void Roles(this ComboBox _control, string _pkey = "IDRol")
        {
            string _SQL = @"SELECT 
	                        a.IDRol,
	                        a.DescripcionRol
                        FROM usuarios_roles a
                        ORDER BY a.DescripcionRol;";
            DataManager.Operacion _datos = new DataManager.Operacion();
            DataTable _tabla = new DataTable();

            try
            {
                _tabla = _datos.Consultar(_SQL);

                _control.DropDownStyle = ComboBoxStyle.DropDownList;
                _control.DataSource = _tabla;
                _control.DisplayMember = "DescripcionRol";
                _control.ValueMember = _pkey;
                _control.SelectedIndex = 0;
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        public static void Categorias(this ComboBox _control, string _pkey = "IDCategoria")
        {
            string _SELECT_PAISES = @"SELECT a.IDCategoria,a.Categoria,a.FechaCreacion FROM productos_categorias a ORDER BY a.Categoria;";
            DataManager.Operacion _datos = new DataManager.Operacion();
            DataTable _tabla = new DataTable();

            try
            {
                _tabla = _datos.Consultar(_SELECT_PAISES);

                _control.DropDownStyle = ComboBoxStyle.DropDownList;
                _control.DataSource = _tabla;
                _control.DisplayMember = "Categoria";
                _control.ValueMember = _pkey;
                _control.SelectedIndex = 0;
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        public static void Paises(this ComboBox _control, string _pkey = "NombrePais")
        {
            string _SELECT_PAISES = @"SELECT a.IDPais,UPPER(a.NombrePais) AS NombrePais FROM geo_paises a ORDER BY a.NombrePais;";
            DataManager.Operacion _datos = new DataManager.Operacion();
            DataTable _tabla = new DataTable();

            try
            {
                _tabla = _datos.Consultar(_SELECT_PAISES);

                _control.DropDownStyle = ComboBoxStyle.DropDownList;
                _control.DataSource = _tabla;
                _control.DisplayMember = "NombrePais";
                _control.ValueMember = _pkey;
                _control.Text = "El Salvador";
                _control.DropDownWidth = 300;
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }
        #endregion
    }
}
