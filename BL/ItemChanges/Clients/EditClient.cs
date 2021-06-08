using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ItemChanges.Clients
{
    public class EditClient : ClientChange
    {
        public override void Change(Client item)
        {
            base.Change(item);
            if (item.Type == ClientTypes.Entity.ToString())
            {
                item.Founders = null;
                item.Founders = new Collection<Founder>();
                foreach (var i in item.Founders)
                {
                    item.Founders.Add(i);
                }
            }
            else
            {
                item.Founders = null;
            }
        }
    }
}
