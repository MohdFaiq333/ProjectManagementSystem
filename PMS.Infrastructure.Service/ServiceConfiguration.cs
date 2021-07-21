using Microsoft.Extensions.DependencyInjection;
using PMS.Core.Service;
using PMS.Infrastructure.Service;
namespace PMS.Infrastructure.Service
{
   public static class ServiceConfiguration
    {
        public static void AddService(this IServiceCollection services)
        {
            services.AddSingleton<IPmsService, PmsService>();

        }
    }
}
