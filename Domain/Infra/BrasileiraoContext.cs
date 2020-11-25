using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Domain.Infra
{
    public class BrasileiraoContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Player> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;User Id=sa;PWD=Admin123(!);Initial Catalog=Brasileirao");
        }
        
    }
}