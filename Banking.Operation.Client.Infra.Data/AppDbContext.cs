using Banking.Operation.Client.Domain.Client.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Banking.Operation.Client.Infra.Data
{
    [ExcludeFromCodeCoverage]
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<ClientEntity> Clients { get; set; }
    }
}
