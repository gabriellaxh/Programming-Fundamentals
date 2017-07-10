using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogsAggregator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var nameAndIPs = new Dictionary<string, List<string>>();
            var nameAndMins = new Dictionary<string, int>();


            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split(' ');
                string IP = info[0];
                string name = info[1];
                int duration = int.Parse(info[2]);

                if (!nameAndIPs.ContainsKey(name))
                {
                    nameAndIPs[name] = new List<string>();
                }
                nameAndIPs[name].Add(IP);

                if (!nameAndMins.ContainsKey(name))
                {
                    nameAndMins[name] = 0;
                }
                nameAndMins[name] += duration;
            }
            foreach (var user in nameAndMins.OrderBy(x => x.Key))
            {
                Console.Write($"{user.Key}: {user.Value} [");
                Console.Write(string.Join(", ", nameAndIPs[user.Key].Distinct().OrderBy(x => x)));
                Console.WriteLine("]");

            }

        }
    }
}
