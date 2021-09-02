using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Herramientas
{
    public static class Log
    {
        public static void Registrar(string _pmsgexcepcion)
        {
            Trace.TraceInformation(_pmsgexcepcion);
            Trace.Flush();
        }
    }
}
