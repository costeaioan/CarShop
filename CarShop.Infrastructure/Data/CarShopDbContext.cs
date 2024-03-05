using Carshop.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarShop.Infrastructure.Data
{
    public interface ICarShopContext
    {
        DbSet<T> Set<T>() where T : class;
        int SaveChanges();
    }

    public class CarShopDbContext :DbContext, ICarShopContext
    {
        public CarShopDbContext(DbContextOptions<CarShopDbContext> options) :base(options)
        {
            Database.EnsureCreated();
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Car> Cars { get; set; }

    }
}
