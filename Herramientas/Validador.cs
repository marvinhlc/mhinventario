using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Herramientas
{
    public class Validador
    {
        private TextBox ControlaValidar = new TextBox();
        private ArrayList Controles = new ArrayList();
        private ErrorProvider _errores = new ErrorProvider();

        public Validador(ErrorProvider _perrores)
        {
            _errores = _perrores;
        }

        public void AgregarControl(Object Control)
        {
            Controles.Add(Control);
        }

        public bool Comprobar()
        {
            int _Contador = 0;
            _errores.Clear();

            try
            {
                foreach (Object Control in Controles)
                {
                    String tipo = Control.GetType().ToString();

                    if (tipo == "System.Windows.Forms.TextBox")
                    {
                        ControlaValidar = (TextBox)Control;
                        if (string.IsNullOrEmpty(ControlaValidar.Text))
                        {
                            _Contador++;
                            _errores.SetError(ControlaValidar, "No es válido");
                        }
                    }
                    if (tipo == "System.String")
                    {
                        if (string.IsNullOrEmpty(Control.ToString()))
                        {
                            _Contador++;
                        }
                    }
                    if (tipo == "System.Int32")
                    {
                        if (string.IsNullOrEmpty(Control.ToString()))
                        {
                            _Contador++;
                        }
                        else
                        {
                            if (Control.Equals(0))
                            {
                                _Contador++;
                            }
                        }
                    }
                    if (tipo == "System.DateTime")
                    {
                        if (string.IsNullOrEmpty(Control.ToString()))
                        {
                            _Contador++;
                        }
                    }

                }
            }
            catch
            {
                _Contador = 1;
            }

            return _Contador == 0;
        }
    }
}
