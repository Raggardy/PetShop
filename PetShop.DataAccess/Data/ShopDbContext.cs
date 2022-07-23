using Microsoft.EntityFrameworkCore;
using PetShop.Models;


namespace PetShop.DataAccess
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
    }
}
