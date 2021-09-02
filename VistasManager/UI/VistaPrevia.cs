using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VistasManager.UI
{
    public partial class VistaPrevia : Estilos.FormMantenimiento
    {
        CrystalDecisions.CrystalReports.Engine.ReportClass _repo = null;

        public VistaPrevia(CrystalDecisions.CrystalReports.Engine.ReportClass _prepo)
        {
            _repo = _prepo;
            InitializeComponent();
            Configurar();
        }

        private void Configurar()
        {
            try
            {
                crystalReportViewer1.ReportSource = _repo;
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }

        private void VistaPrevia_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (_repo != null)
                    _repo.Close();
            }
            catch (Exception _err)
            {
                Herramientas.Log.Registrar(_err.ToString());
            }
        }
    }
}
