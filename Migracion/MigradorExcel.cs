using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Migracion
{
    public partial class MigradorExcel : Form
    {
        MigradorTool _mitool = new MigradorTool();
        DataSet _ds = new DataSet();
        DataTable _dtcatalogo = new DataTable();

        public MigradorExcel()
        {
            InitializeComponent();
        }

        private void EscribirResultado(int _ptotal, int _pconteo)
        {
            int _progreso = (_pconteo * 100) / _ptotal;
            lblProgreso.Text = string.Format("Total: {0} Conteo: {1} Progreso: {2}%", _ptotal, _pconteo, _progreso);
            lblProgreso.Refresh();
            this.Refresh();
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog _dialogo = new OpenFileDialog();
                if (_dialogo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    lblNombreFichero.Text = _dialogo.FileName.ToString();
                    _mitool.doRefrescarFormularioExterno += EscribirResultado;
                    _ds = _mitool.ObtenerRangoDesdeFicheroXls(lblNombreFichero.Text);
                    if (_ds != null)
                    {
                        _dtcatalogo = _ds.Tables["tabla_catalogo"];
                        if (_dtcatalogo != null)
                        {
                            dgvDatos.DataSource = _dtcatalogo;
                        }
                    }
                }
            }
            catch (Exception _err)
            {
                MessageBox.Show(_err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            bool _ok = true;
            if (MessageBox.Show("¿Desea eliminar los registros antes de procesar la migración?", "MIGRAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                _ok = _mitool.EliminarRegistros();
            }

            if (_ok)
            {
                if (_mitool.ProcesarCatalogoProductos(_dtcatalogo))
                {
                    MessageBox.Show("Procesado correctamente");
                }
            }
        }
    }
}
