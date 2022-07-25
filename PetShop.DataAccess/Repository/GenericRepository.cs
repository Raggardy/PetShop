using Microsoft.EntityFrameworkCore;
using PetShop.DataAccess.Repository.IRepository;
using System.Linq.Expressions;

namespace PetShop.DataAccess.Repository
{

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ShopDbContext _context;
        internal DbSet<T> dbSet;

        public GenericRepository(ShopDbContext context)
        {
            _context = context;
            this.dbSet = _context.Set<T>();
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            IQueryable<T> query = dbSet;
            return await query.ToListAsync();
        }

        public async Task<T> GetEntityById(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            return await query.FirstOrDefaultAsync();
        }
    }
}
