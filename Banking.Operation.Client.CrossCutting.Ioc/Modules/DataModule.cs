using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Net.Core.Template.CrossCutting.Ioc.Modules
{
    public static class DataModule
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            //services.AddScoped<IRepository, Repository>();
        }
    }
}
