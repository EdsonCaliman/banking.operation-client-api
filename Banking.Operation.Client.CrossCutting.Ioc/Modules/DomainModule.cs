using Banking.Operation.Client.Domain.Client.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Net.Core.Template.CrossCutting.Ioc.Modules
{
    [ExcludeFromCodeCoverage]
    public static class DomainModule
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddScoped<IClientService, ClientService>();
        }
    }
}
