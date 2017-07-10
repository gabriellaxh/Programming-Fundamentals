using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Charity_Maraton
{
    class Program
    {
        static void Main(string[] args)
        {
           long days = int.Parse(Console.ReadLine());
           long numberOfRunners = int.Parse(Console.ReadLine());
           long averageLaps = int.Parse(Console.ReadLine());
           long lengthOfTrack = int.Parse(Console.ReadLine());
           long capacityOfTrack = int.Parse(Console.ReadLine());
            double money = double.Parse(Console.ReadLine());

            long totalrunners = capacityOfTrack * days;
            while (totalrunners > numberOfRunners)
            {
                totalrunners--;
            }
            long totalKMs = (totalrunners * averageLaps * lengthOfTrack) / 1000;
            double moneyRaised = totalKMs * money;
            Console.WriteLine($"Money raised: {moneyRaised:f2}");
        }
    }
}
