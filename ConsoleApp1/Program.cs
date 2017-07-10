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
            var beehives = Console.ReadLine().Split(' ').Select(long.Parse).ToList();

            var hornets = Console.ReadLine().Split(' ').Select(long.Parse).ToList();
            var hornetsPow = 0l;
            while (true)
            {
                if(hornets.Count <= 0)
                {
                    break;
                }
                for (int i = 0; i < hornets.Count; i++)
                {
                    hornetsPow += hornets[i];
                }
                for (int i = 0; i < beehives.Count; i++)
                {
                    if (hornetsPow > beehives[i])
                    {
                        beehives[i] -= hornetsPow;
                        if (beehives[i] <= 0)
                        {
                            beehives.RemoveAt(i);
                            i--;
                        }

                    }
                    else if (beehives[i] >= hornetsPow)
                    {
                        beehives[i] -= hornetsPow;
                        hornetsPow -= hornets[0];
                        hornets.RemoveAt(0);
                        if (beehives[i] <= 0)
                        {
                            beehives.RemoveAt(i);
                            i--;
                        }
                    }
                }
                if (beehives.Count <= 0)
                {
                    foreach (var hornet in hornets)
                    {
                        Console.Write(hornet + " ");
                    }
                    Console.WriteLine();
                    return;
                }
                else
                {
                    Console.WriteLine(string.Join(" ", beehives));
                    return;
                }

            }
        }
    }
}



