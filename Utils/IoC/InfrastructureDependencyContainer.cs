using Infrastructure.Utils.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Utils.IoC
{
    public class InfrastructureDependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // HttpClient
            services.AddSingleton<IHttpClientCustom, HttpClientCustom>();
        }
    }
}
