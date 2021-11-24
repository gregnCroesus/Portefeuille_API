using Portefeuille.Domain.WeatherForecast.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portefeuille.Domain.WeatherForecast.Queries.Fetchers
{
    public class GetWeatherForcastListQueryHandler : IQueryHandler<GetWeatherForcastListQuery, List<WeatherForecast>>
    {
        private readonly IWeatherForcastRepository _weatherForcastRepository;

        public GetWeatherForcastListQueryHandler(IWeatherForcastRepository weatherForcastRepository)
        {
            _weatherForcastRepository = weatherForcastRepository;
        }

        public List<WeatherForecast> Handle(GetWeatherForcastListQuery query)
        {

            return this._weatherForcastRepository.GetAll();
        }
    }
}
