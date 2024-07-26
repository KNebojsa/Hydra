using Hydra.WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hydra.WebApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<AppUser> Users { get; set; }
    }
}