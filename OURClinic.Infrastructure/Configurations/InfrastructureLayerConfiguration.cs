using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OURCart.Infrastructure.Util;

namespace OURCart.Infrastructure.Configurations
{
    public class InfrastructureLayerConfiguration
    {
      
        public static IServiceCollection RunCongiguration( IServiceCollection services, IConfiguration configuration)
        {
           
            services.AddDbContext<OurCartDBContext>(options =>
          options.UseSqlServer(configuration.GetConnectionString("OurCartDatabase")));
           

            return services;
        }
    }
}
