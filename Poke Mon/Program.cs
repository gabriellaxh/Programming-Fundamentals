using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            long counttargets = 0;
            double oldN = (double)n;
            while (n >= m)
            {
                n -= m;
                counttargets++;

                if (n == oldN / 2)
                {
                    if (y < 1 || y > n)
                    {
                        continue;
                    }
                    n /= y;
                }
            }
            Console.WriteLine($"{n}");
            Console.WriteLine($"{counttargets}");
        }
    }
}
