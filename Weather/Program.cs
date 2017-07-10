using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegEx
{
    class Program
    {
        static void Main(string[] args)
        {
            var regex = new Regex(@"(?<city>[A-Z]{2})(?<temp>\d+\.\d+)(?<weather>[a-zA-z]+)\|");
            var cities = new Dictionary<string, WeatherInfo>();
            var input = Console.ReadLine();
            while (input != "end")
            {

                var weatherMatch = regex.Match(input);
                if (!weatherMatch.Success)
                {
                    input = Console.ReadLine();
                    continue;
                }

                var city = weatherMatch.Groups["city"].Value;
                var temp = double.Parse(weatherMatch.Groups["temp"].Value);
                var weather = weatherMatch.Groups["weather"].Value;

                var weatherInfo = new WeatherInfo
                {
                    AverageTemp = temp,
                    Weather = weather
                };

                cities[city] = weatherInfo;

                input = Console.ReadLine();
            }
            foreach (var city in cities.OrderBy(a => a.Value.AverageTemp))
            {
                Console.WriteLine($"{city.Key} => {city.Value.AverageTemp:f2} => {city.Value.Weather}");
            }
        }
        class WeatherInfo
        {
            public double AverageTemp { get; set; }
            public string Weather { get; set; }
        }
    }
}
