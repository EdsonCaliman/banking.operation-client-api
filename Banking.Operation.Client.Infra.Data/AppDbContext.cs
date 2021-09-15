using Banking.Operation.Client.Domain.Client.Entities;
using Microsoft.EntityFrameworkCore;

namespace Banking.Operation.Client.Infra.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<ClientEntity> Clients { get; set; }
    }
}
