using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portefeuille.Domain.WeatherForecast.Repositories
{
   public interface IWeatherForcastRepository
    {
        List<WeatherForecast> GetAll();
    }
}
