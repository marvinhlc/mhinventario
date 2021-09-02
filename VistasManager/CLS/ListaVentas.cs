using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace VistasManager.CLS
{
    public class ListaVentas : BindingList<ItemVentas>
    {
        protected override void OnAddingNew(AddingNewEventArgs e)
        {
            //base.OnAddingNew(e);
            e.NewObject = new ItemVentas();
        }

        public List<ItemVentas> Todo()
        {
            return this.ToList<ItemVentas>();
        }
    }
}
