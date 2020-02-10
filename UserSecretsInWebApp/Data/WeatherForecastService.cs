using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading.Tasks;
using UserSecretsInWebApp.Models;

namespace UserSecretsInWebApp.Data
{
    public class WeatherForecastService
    {
        public IConfiguration Configuration { get; }

        private readonly Secrets _secretToDisplay;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public WeatherForecastService(IOptions<Secrets> secrets)
        {
            //This is how you can access the user secret in a page/service. In this example the secret is mapped to a "Secret" model
            _secretToDisplay = secrets.Value ?? throw new ArgumentException(nameof(secrets));
        }

        public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            var rng = new Random();
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).ToArray());
        }

        public string GetUserSecret()
        {
            return $"{_secretToDisplay.Password}";
        }
    }
}
