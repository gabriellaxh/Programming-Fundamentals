using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Globalization;

namespace ObjectsAndClasses
{
    class Program
    {

        static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            string[] phrases =
            {
                "Excellent product.","Such a great product.","I always use this product.","Best product of its category.","Exceptional product.","I can't live without this product."
            };
            string[] events =
            {
                "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!"
            };
            string[] authors =
            {
                "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva"
            };
            string[] cities =
            {
                "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse"
            };

            Random rnd = new Random();
            for (int i = 0; i < num; i++)
            {
                var phraseIndex = rnd.Next(0, phrases.Length);
                var eventIndex = rnd.Next(0, events.Length);
                var authorIndex = rnd.Next(0, authors.Length);
                var cityIndex = rnd.Next(0, cities.Length);

                Console.WriteLine($"{phrases[phraseIndex]} {events[eventIndex]} {authors[authorIndex]} – {cities[cityIndex]}.");
            }

        }
    }
}



