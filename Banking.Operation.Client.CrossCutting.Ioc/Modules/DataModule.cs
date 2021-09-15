using Banking.Operation.Client.Domain.Client.Repositories;
using Banking.Operation.Client.Infra.Data;
using Banking.Operation.Client.Infra.Data.Client.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Net.Core.Template.CrossCutting.Ioc.Modules
{

    public static class DataModule
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 26));

            services.AddDbContext<AppDbContext>(options => options.UseMySql(connectionString, serverVersion));

            services.AddScoped<IClientRepository, ClientRepository>();
        }
    }
}
