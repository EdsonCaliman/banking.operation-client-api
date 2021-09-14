using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Net.Core.Template.CrossCutting.Ioc.Modules;

namespace Net.Core.Template.CrossCutting.Ioc
{
    public static class IoC
    {
        public static IServiceCollection ConfigureContainer(this IServiceCollection services, IConfiguration configuration)
        {
            DataModule.Register(services, configuration);
            services.Register(configuration);
            return services;
        }
    }
}
