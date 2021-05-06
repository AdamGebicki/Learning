using System.Collections.Generic;

namespace Restaurant
{
    public interface IWeatherForecastServices
    {
        IEnumerable<WeatherForecast> Get();
        IEnumerable<WeatherForecast> Get(int howMany, int min, int max);
    }
}