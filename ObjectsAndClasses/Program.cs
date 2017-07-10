using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Globalization;
using System.IO;

namespace PopulationCounter

{
    class Program
    {
        static void Main()
        {
            var countryANDcity = new Dictionary<string, Dictionary<string, long>>();
            var OnlyCountry = new Dictionary<string, long>();

            string input = Console.ReadLine();
            while (input != "report")
            {
                string[] info = input.Split('|');
                string city = info[0];
                string country = info[1];
                long population = long.Parse(info[2]);

                if (!countryANDcity.ContainsKey(country))
                {
                    countryANDcity[country] = new Dictionary<string, long>();
                    OnlyCountry[country] = 0;
                }
                if (!countryANDcity[country].ContainsKey(city))
                {
                    countryANDcity[country][city] = 0;
                }

                OnlyCountry[country] += population;
                countryANDcity[country][city] += population;

                input = Console.ReadLine();
            }
            foreach (var country in OnlyCountry.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{country.Key} (total population: {country.Value})");
                foreach (var city in countryANDcity[country.Key].OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"=> {city.Key}: {city.Value}");
                }
               
            }
        }


    }
}

