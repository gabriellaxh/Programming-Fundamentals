using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SinoTheWalker
{
    class Program
    {
        public static int Alltime { get; private set; }

        static void Main(string[] args)
        {
            string[] drivers = Console.ReadLine().Split(' ');
            double[] zones = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            int[] checkpoints = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            foreach (var driver in drivers)
            {
                double fuel = (double)driver[0];
                for (int i = 0; i < zones.Length; i++)
                {
                    if (checkpoints.Contains(i))
                    {
                        fuel += zones[i];
                    }
                    else
                    {
                        fuel -= zones[i];
                    }
                    if (fuel <= 0)
                    {
                        Console.WriteLine($"{driver} - reached {i}");
                        break;
                    }
                }
                if (fuel > 0)
                {
                    Console.WriteLine($"{driver} - fuel left {fuel:f2}");
                }
            }
        }

    }
}
