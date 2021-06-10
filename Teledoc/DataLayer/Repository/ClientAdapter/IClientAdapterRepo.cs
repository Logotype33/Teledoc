using DataLayer.Entityes;
using DataLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teledoc.DataLayer.Repository
{
    public interface IClientAdapterRepo: IGenericRepotory<Client>
    {
        public IEnumerable<Client> ClientWithFounders();
        public void DontChangeCreatingDate(Client client);
    }
}
