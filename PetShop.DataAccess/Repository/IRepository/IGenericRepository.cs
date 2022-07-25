using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.DataAccess.Repository.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetEntityById(Expression<Func<T, bool>> filter);
        Task<IEnumerable<T>> GetAll();
        void Add(T entity);
        void Delete(T entity);
        
    }
}
