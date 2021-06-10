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
        Task<TEntity> FindByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAsync();
        void Remove(TEntity item);
        void Update(TEntity item);
        Task SaveAsync();
    }
}
