using Microsoft.EntityFrameworkCore;
using TheWag.Api.WagDB.EFModels;

namespace TheWag.Api.WagDB
{
    public class TheWagDBContext : DbContext
    {
        public TheWagDBContext(DbContextOptions<TheWagDBContext> options)
        : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Product_Tag> Product_Tags { get; set; }
    }
}
