using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ItemChanges.Clients
{
    public class CreateClient : ClientChange
    {
        /// <summary>
        /// Create new client
        /// </summary>
        public override void Change(Client item)
        {
            base.Change(item);
                _client.CreatingDate = DateTime.UtcNow;
        }
    }
}
