using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using PMS.Core.Repository;
using PMS.Infrastructure.Repository;

namespace PMS.Infrastructure.Repository
{
  public static class RepositoryConfiguration
    {
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddSingleton<IPmsRepository,PmsRepository>();
        }
    }
}
