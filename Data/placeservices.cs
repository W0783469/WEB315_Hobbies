using System;
using System.Linq;
using System.Threading.Tasks;

namespace WEB315_Hobbies.Data
{
public class placeservices
    {
 private static readonly string[] placetype = new[]
        {
            "adventourous", "Treking", "Holy ", "Traditional","Abc"
        };
         private static readonly string[] location = new[]
        {
            "delhi", "jalandhar", "calcc ", "amritsar","ajj"
        };
           private static readonly int[] cost = new[]
        {
            1000, 2000, 3000 , 4000,5000
        };
  public Task<places[]> GetPlacesAsync(DateTime startDate)
  {
  var rng = new Random();
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new places
            {
                Date = startDate.AddDays(index),
                cost = cost[rng.Next(cost.Length)],
                placetype = placetype[rng.Next(placetype.Length)],
                location = location[rng.Next(location.Length)]
            }).ToArray());
        }
}

}