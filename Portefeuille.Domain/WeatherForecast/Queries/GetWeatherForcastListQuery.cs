using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portefeuille.Domain.WeatherForecast.Queries
{
    public class GetWeatherForcastListQuery : IQuery<List<WeatherForecast>>
    {

        // In this case no parameter are passed 
        public GetWeatherForcastListQuery()
        {

        }
    }
}
