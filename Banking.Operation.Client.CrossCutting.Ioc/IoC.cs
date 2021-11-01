using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Net.Core.Template.CrossCutting.Ioc.Modules;
using System.Diagnostics.CodeAnalysis;

namespace Net.Core.Template.CrossCutting.Ioc
{
    [ExcludeFromCodeCoverage]
    public static class IoC
    {
        public static IServiceCollection ConfigureContainer(this IServiceCollection services, IConfiguration configuration)
        {
            DataModule.Register(services, configuration);
            services.Register();
            return services;
        }
    }
}
