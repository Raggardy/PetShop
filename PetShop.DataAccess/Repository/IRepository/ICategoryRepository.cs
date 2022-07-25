using PetShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.DataAccess.Repository.IRepository
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        // Implementing these methods here will lower trips to the database
        void Update(Category category);
        void Save();
    }
}
