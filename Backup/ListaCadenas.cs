using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Backup
{
    public class ListaCadenas : BindingList<ItemCadena>
    {
        protected override void OnAddingNew(AddingNewEventArgs e)
        {
            //base.OnAddingNew(e);
            e.NewObject = new ItemCadena();
        }

        public List<ItemCadena> Todo()
        {
            return this.ToList<ItemCadena>();
        }
    }
}
