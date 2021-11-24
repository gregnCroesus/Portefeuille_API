using Microsoft.Extensions.DependencyInjection;
using Portefeuille.Domain.WeatherForecast.Repositories;
using Portefeuille.Infrastructure.Repositories.WeatherForcast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portefeuille.Modules
{
    public class RepositoryModule
    {

        #region Development

        public static void ConfigureDevelopmentServices(IServiceCollection services)
        {
            // If you need to configure stubs, it's here. Stubs are not used right now.
            ConfigureServices(services);

            // Configure Stub Providers
            //StubModule.ConfigureDevelopmentServices(services);

            // TODO : Stub the marine traffic API calls.

            // Configure Stub Repositories
            // Ex: services.AddTransient<IOrderRepository, OrderRepositoryStub>();
        }

        #endregion

        #region StagingAndProduction

        public static void ConfigureServices(IServiceCollection services)
        {
            // Configure Repositories and Database Factories Here:

            services.AddTransient<IWeatherForcastRepository, WeatherForcastRepository>();
            
        }
        #endregion
    }
}
