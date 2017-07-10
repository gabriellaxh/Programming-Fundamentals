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
            var time = Console.ReadLine().Split(':');
            long h = int.Parse(time[0]) * 3600;
            long m = int.Parse(time[1]) * 60;
            long s = int.Parse(time[2]);
            long totalTime = h + m + s;

            long steps = int.Parse(Console.ReadLine());
            long secPerStep = int.Parse(Console.ReadLine());

            long Alltime = totalTime + (steps * secPerStep);
            long hour = (Alltime / 3600) % 24;
            long min = (Alltime / 60) % 60;
            long sec = Alltime % 60;


            Console.WriteLine($"Time Arrival: {hour:00}:{min:00}:{sec:00}");
        }
    }
}
