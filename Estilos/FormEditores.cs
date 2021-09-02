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

namespace Estilos
{
    public partial class FormEditores : Form
    {
        List<MapeoTabulacion> _mapeo = new List<MapeoTabulacion>();

        public FormEditores()
        {
            InitializeComponent();
        }

        public void Mapear(Control _porigen, Control _pdestino)
        {
            MapeoTabulacion _nuevo = new MapeoTabulacion(_porigen, _pdestino);
            _mapeo.Add(_nuevo);
        }

        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{
        //    if (keyData != Keys.Enter)
        //    {
        //        return base.ProcessCmdKey(ref msg, keyData);
        //    }

        //    Control _ctrl = this.ActiveControl;

        //    var resultado = (from b in _mapeo
        //                     where b.Orgien.Name == _ctrl.Name
        //                     select b).ToList();

        //    MapeoTabulacion _existe = resultado.FirstOrDefault();
        //    if (_existe != null)
        //    {
        //        _existe.Destino.Focus();
        //        return true;
        //    }
        //    return base.ProcessCmdKey(ref msg, keyData);
        //}

        //private void FormEditores_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        Control _ctrl = (Control)sender;

        //        var resultado = (from b in _mapeo
        //                         where b.Orgien.Name == _ctrl.Name
        //                         select b).ToList();

        //        MapeoTabulacion _existe = resultado.FirstOrDefault();
        //        if (_existe != null)
        //        {
        //            _existe.Destino.Focus();
        //        }
        //    }
        //}
    }

    public class MapeoTabulacion
    {
        Control _orgien;

        public Control Orgien
        {
            get { return _orgien; }
            set { _orgien = value; }
        }
        Control _destino;

        public Control Destino
        {
            get { return _destino; }
            set { _destino = value; }
        }

        public MapeoTabulacion(Control _c1, Control _c2)
        {
            _orgien = _c1;
            _destino = _c2;
        }
    }
}
