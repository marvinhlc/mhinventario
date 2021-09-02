using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Drawing;
using System.Data;
using System.Configuration;
using Herramientas;

namespace VistasManager.CLS
{
    public class Ticket
    {
        Sesion.CLS.ConfigApp _configapp = new Sesion.CLS.ConfigApp();
        private StreamWriter _writer;
        private StreamReader _reader;
        private StringBuilder _buffer;
        private string _nombre_fichero;
        private string _root_app;
        private DataTable _tabla;
        int _maximo_ancho = 32;
        int _margen_superior = 2;
        int _margen_inferior = 2;

        public enum MARGEN
        {
            SUPERIOR,
            INFERIOR
        }

        public Ticket(string _pnombre_fichero)
        {
            _nombre_fichero = _pnombre_fichero;
            _root_app = string.Format("{0}\\{1}",Application.StartupPath,_nombre_fichero);
            _buffer = new StringBuilder();
            _writer = new StreamWriter(_root_app);
        }

        public Ticket(string _pnombre_fichero, DataTable _ptabla)
        {
            _nombre_fichero = _pnombre_fichero;
            _tabla = _ptabla;
            _root_app = string.Format("{0}\\{1}", Application.StartupPath, _nombre_fichero);
            _buffer = new StringBuilder();
            _writer = new StreamWriter(_root_app);            
            ConstruirTicket();
        }

        public Ticket(DataTable _ptabla)
        {
            _nombre_fichero = "abono.txt";
            _tabla = _ptabla;
            _root_app = string.Format("{0}\\{1}", Application.StartupPath, _nombre_fichero);
            _buffer = new StringBuilder();
            _writer = new StreamWriter(_root_app);
            ConstruirTicketAbono();
        }

        public Ticket()
        {
            _nombre_fichero = "cajon.txt";
            _root_app = string.Format("{0}\\{1}", Application.StartupPath, _nombre_fichero);
            _buffer = new StringBuilder();
            _writer = new StreamWriter(_root_app);
        }

        public void AbrirCajon()
        {
            string _codigos = ConfigurationManager.AppSettings["COMANDOS_ABRIR_CAJON_PRINTER_0"].ToString();
            _writer.WriteLine(_codigos);
        }

        public void Escribir(string _ptexto)
        {
            try
            {
                _writer.WriteLine(_ptexto);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        public void Escribir(string _ptexto, int _replica)
        {
            try
            {
                for (int i = 0; i < _replica; i++)
                {
                    _writer.Write(_ptexto);   
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        public void Centrar(string _ptexto)
        {
            try
            {
                string _espacio = " ";
                int _replica = (_maximo_ancho - _ptexto.Length) / 2;
                for (int i = 0; i < _replica; i++)
                {
                    _writer.Write(_espacio);
                }
                _writer.WriteLine(_ptexto);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        public void Derecha(string _ptexto)
        {
            try
            {
                string _espacio = " ";
                int _replica = (_maximo_ancho - _ptexto.Length);
                for (int i = 0; i < _replica; i++)
                {
                    _writer.Write(_espacio);
                }
                _writer.WriteLine(_ptexto);
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        public void Margen(MARGEN _margen)
        {
            int _replica = 0;
            string _ptexto = "";

            try
            {
                if (_margen == MARGEN.SUPERIOR)
                    _replica = _margen_superior;
                if (_margen == MARGEN.INFERIOR)
                    _replica = _margen_inferior;

                for (int i = 0; i < _replica; i++)
                {
                    _writer.WriteLine(_ptexto);
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        public void Imprimir()
        {
            bool _ok = false;

            try
            {
                _reader = new StreamReader(_root_app);

                PrintDialog _dialogo = new PrintDialog();

                if (_dialogo != null)
                {
                    using (PrintDocument _imprimir = new PrintDocument())
                    {
                        _imprimir.PrinterSettings = _dialogo.PrinterSettings;
                        _imprimir.DocumentName = "ticket";
                        _imprimir.PrintPage += ImprimirPagina;
                        _imprimir.Print();
                    }
                }
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void ImprimirPagina(object o, PrintPageEventArgs e)
        {
            Graphics _graphics = e.Graphics;
            int _conteo = 0;
            float _ypos = 0;
            float _top = 10;
            float _left = 0;
            var _font = new Font("Courier New", 10);
            string _linea = string.Empty;

            try
            {
                while ((_linea = _reader.ReadLine()) != null)
                {
                    _ypos = _top + (_conteo * _font.GetHeight(_graphics));
                    e.Graphics.DrawString(_linea, _font, Brushes.Black, _left, _ypos, new StringFormat());
                    _conteo++;
                }
                _reader.Close();
            }
            catch (Exception _err)
            {
                _reader.Close();
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void ConstruirTicket()
        {
            double _cantidad = 0;
            double _subtotal_excento = 0;
            double _subtotal_gravado = 0;
            double _suma_excento = 0;
            double _suma_gravado = 0;
            double _iva = 0;
            double _total = 0;
            double _descuento = 0;
            string _fecha = string.Empty;
            string _numero = string.Empty;

            string _marca = _configapp.MARCA_BLANCA;

            this.Margen(MARGEN.SUPERIOR);
            this.Centrar(_marca);
            this.Centrar(DateTime.Now.ToString());
            this.Escribir("=", _maximo_ancho);
            this.Escribir("");

            foreach (DataRow _row in _tabla.Rows)
            {
                if (_row["NombreProducto"].ToString().Length > _maximo_ancho)
                    this.Escribir(_row["NombreProducto"].ToString().Substring(0, _maximo_ancho));
                else
                    this.Escribir(_row["NombreProducto"].ToString());

                double _total_item = (_row["CantidadSalida"].ToDouble() * _row["PrecioSalida"].ToDouble());
                this.Derecha(string.Format("{0} x {1:N4} = {2:N4}",
                    _row["CantidadSalida"].ToString(),
                    _row["PrecioSalida"].ToString(),
                    _total_item));

                _cantidad += _row["CantidadSalida"].TextoToDouble();
                _suma_excento += _row["Excento"].TextoToDouble();
                _suma_gravado += _row["Gravado"].TextoToDouble();
                _iva += _row["IvaRetenido"].TextoToDouble();
                _total += _row["Total"].TextoToDouble();
                _fecha = _row["FechaDocumento"].ToString();
                _numero = _row["NumeroDocumento"].ToString();
                _descuento += _row["Descuento"].ToDouble();
            }

            _subtotal_excento = _suma_excento;
            _subtotal_gravado = (_total - _iva);

            this.Escribir("=", _maximo_ancho);
            this.Escribir("");
            this.Derecha(string.Format("SUBTOTAL EXCENTO: {0:N4}",_subtotal_excento));
            this.Derecha(string.Format("SUBTOTAL GRAVADO: {0:N4}", _subtotal_gravado));
            this.Derecha(string.Format("TOTAL IVA: {0:N4}", _iva));
            this.Derecha(string.Format("DESCUENTO: {0:N4}", _descuento));
            this.Derecha(string.Format("TOTAL VENTA: {0:N4}", _total));
            this.Derecha(string.Format("FECHA: {0}", _fecha));
            this.Derecha(string.Format("TICKET #: {0}", _numero));
            this.Derecha(string.Format("No. ARTICULOS: {0}", _cantidad));
            this.Escribir("");
            this.Centrar("¡GRACIAS POR SU COMPRA!");
            this.Margen(MARGEN.INFERIOR);

            _writer.Close();
        }

        private void ConstruirTicketAbono()
        {
            double _cantidad = 0;
            double _subtotal_excento = 0;
            double _subtotal_gravado = 0;
            double _suma_excento = 0;
            double _suma_gravado = 0;
            double _iva = 0;
            double _total = 0;
            string _fecha = string.Empty;
            string _numero = string.Empty;

            string _marca = _configapp.MARCA_BLANCA;

            this.Margen(MARGEN.SUPERIOR);
            this.Centrar(_marca);
            this.Centrar(DateTime.Now.ToString());
            this.Escribir("=", _maximo_ancho);
            this.Escribir("");

            foreach (DataRow _row in _tabla.Rows)
            {
                if (_row["NombreProducto"].ToString().Length > _maximo_ancho)
                    this.Escribir(_row["NombreProducto"].ToString().Substring(0, _maximo_ancho));
                else
                    this.Escribir(_row["NombreProducto"].ToString());

                this.Derecha(string.Format("{0} x {1:N4} = {2:N4}",
                    _row["CantidadSalida"].ToString(),
                    _row["PrecioSalida"].ToString(),
                    _row["Total"].ToString())
                );

                _cantidad += _row["CantidadSalida"].TextoToDouble();
                _suma_excento += _row["Excento"].TextoToDouble();
                _suma_gravado += _row["Gravado"].TextoToDouble();
                _iva += _row["IvaRetenido"].TextoToDouble();
                _total += _row["Total"].TextoToDouble();
                _fecha = _row["FechaDocumento"].ToString();
                _numero = _row["NumeroDocumento"].ToString();
            }

            _subtotal_excento = _suma_excento;
            _subtotal_gravado = (_total - _iva);

            this.Escribir("=", _maximo_ancho);
            this.Escribir("");
            this.Derecha(string.Format("SUBTOTAL EXCENTO: {0:N4}", _subtotal_excento));
            this.Derecha(string.Format("SUBTOTAL GRAVADO: {0:N4}", _subtotal_gravado));
            this.Derecha(string.Format("TOTAL IVA: {0:N4}", _iva));
            this.Derecha(string.Format("TOTAL VENTA: {0:N4}", _total));
            this.Derecha(string.Format("FECHA: {0}", _fecha));
            this.Derecha(string.Format("TICKET #: {0}", _numero));
            this.Derecha(string.Format("No. ARTICULOS: {0}", _cantidad));
            this.Escribir("");
            this.Centrar("¡GRACIAS POR SU COMPRA!");
            this.Margen(MARGEN.INFERIOR);

            _writer.Close();
        }

    }
}
