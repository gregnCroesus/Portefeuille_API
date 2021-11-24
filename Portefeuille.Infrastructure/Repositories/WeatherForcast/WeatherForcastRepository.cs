using Portefeuille.Domain.WeatherForecast;
using Portefeuille.Domain.WeatherForecast.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portefeuille.Infrastructure.Repositories.WeatherForcast
{
    public class WeatherForcastRepository : IWeatherForcastRepository
    {

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        public List<WeatherForecast> GetAll()
        {
            var rng = new Random();

            var res = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToList();

            
            return res;
          
        }
    }
}
