using Microsoft.EntityFrameworkCore;
using PetShop.Web.Models;

namespace PetShop.Web.Data
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
    }
}
