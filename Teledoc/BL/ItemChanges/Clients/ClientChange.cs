using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ItemChanges.Clients
{
    public abstract class ClientChange:IChange<Client>
    {
        protected Client _client;
        public ClientChange()
        {
        }
        /// <summary>
        /// Create client
        /// </summary>
        /// <param name="item">client</param>
        
        public virtual void Change(Client item)
        {
            _client = item;
            if (item != null)
            {
                _client.ChangeDate = DateTime.UtcNow;
            }
        }
        /// <summary>
        /// GetClient
        /// </summary>
        /// <returns>Client</returns>
        public Client GetT()
        {
            return _client;
        }
    }
}
