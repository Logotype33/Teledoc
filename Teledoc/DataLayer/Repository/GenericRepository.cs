using DataLayer.Entityes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class GenericRepository<TEntity> : IGenericRepotory<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
        public async Task CreateAsync(TEntity item)
        {
            await _dbSet.AddAsync(item);
        }

        public async Task<TEntity> FindByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }
        public IEnumerable<TEntity> Get()
        {
            return _dbSet.AsNoTracking().ToList();
        }
        public void Remove(TEntity item)
        {
            _dbSet.Remove(item);
        }
        public async Task RemoveById(int id)
        {
            _dbSet.Remove(await _dbSet.FindAsync(id));
        }

        public void Update(TEntity item)
        {
            _context.Entry<TEntity>(item).State = EntityState.Modified;
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
        public IEnumerable<Client> ClientWithFounders()
        {
            return _context.Clients.Include(x => x.Founders).ThenInclude(x => x.Client);
        }
    }
}
