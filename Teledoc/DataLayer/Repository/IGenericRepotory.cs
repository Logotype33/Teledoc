using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public interface IGenericRepotory<TEntity> where TEntity : class
    {
        Task CreateAsync(TEntity item);
        public IEnumerable<Client> ClientWithFounders();
        Task<TEntity> FindByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAsync();
        IEnumerable<TEntity> Get();
        void Remove(TEntity item);
        Task RemoveById(int id);
        void Update(TEntity item);
        Task SaveAsync();
    }
}
