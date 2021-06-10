using DataLayer;
using DataLayer.Entityes;
using DataLayer.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teledoc.DataLayer.Repository
{
    public class ClientAdapterRepo : GenericRepository<Client>, IClientAdapterRepo
    {
        public ClientAdapterRepo(ApplicationDbContext context) :base(context)
        {

        }
        public IEnumerable<Client> ClientWithFounders()
        {
            return _context.Clients.Include(x => x.Founders).ThenInclude(x => x.Client);
        }
        public void DontChangeCreatingDate(Client client)
        {
            _context.Entry<Client>(client).Property(x => x.CreatingDate).IsModified = false;
        }
    }
}
