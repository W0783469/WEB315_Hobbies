using System;
using System.Linq;
using System.Threading.Tasks;

namespace WEB315_Hobbies.Data
{
    public class WeatherForecastService
    {
         private static readonly string[] placetype = new[]
        {
            "adventourous sport", "Treking", "River rafting ", "Traditional","Listening music"
        };
         private static readonly string[] location = new[]
        {
            "Delhi", "Jalandhar", "Shimla ", "Amritsar","Japan"
        };
           private static readonly int[] cost = new[]
        {
            1000, 2000, 3000 , 4000,5000
        };

        public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            var rng = new Random();
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                cost = cost[rng.Next(cost.Length)],
                placetype = placetype[rng.Next(placetype.Length)],
                location = location[rng.Next(location.Length)]
            }).ToArray());
        }
    }
}
