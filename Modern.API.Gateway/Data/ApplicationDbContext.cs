using Microsoft.EntityFrameworkCore;
using Modern.Models;

namespace Modern.API.Gateway.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<EngineInfo> EngineInfos { get; set; }
    }
}
