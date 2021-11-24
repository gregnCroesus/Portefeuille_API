using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Portefeuille.Domain.WeatherForecast;
using Portefeuille.Domain.WeatherForecast.Queries;
using Portefeuille.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portefeuille.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly Messages _messages;

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, Messages messages)
        {
            _logger = logger;
            _messages = messages;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return  _messages.Dispatch(new GetWeatherForcastListQuery());
        }
    }
}
