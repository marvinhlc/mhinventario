using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Migracion
{
    public class ListaProductos : BindingList<Registro>
    {
        protected override void OnAddingNew(AddingNewEventArgs e)
        {
            //base.OnAddingNew(e);
            e.NewObject = new Registro();
        }

        public List<Registro> Todo()
        {
            return this.ToList<Registro>();
        }
    }
}
