using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Preparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int flaps = int.Parse(Console.ReadLine());
            double averageMeters = double.Parse(Console.ReadLine());
            int averageFlaps = int.Parse(Console.ReadLine());

            double distance = ((flaps / 1000) * averageMeters);
            var seconds = (flaps / 100);
            var total = ((flaps / averageFlaps) * 5) + seconds;

            Console.WriteLine($"{distance:f2} m.");
            Console.WriteLine($"{total} s.");

        }
    }
}



