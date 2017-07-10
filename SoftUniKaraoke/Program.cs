using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preparation
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var songs = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var dict = new Dictionary<string, List<string>>();
            string input = Console.ReadLine();
            while (input != "dawn")
            {
                var info = input.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToList();
                string name = info[0];
                string song = info[1];
                string award = info[2];

                if (!dict.ContainsKey(name) && names.Contains(name) && songs.Contains(song))
                {
                    dict[name] = new List<string>();
                }
                if (dict.ContainsKey(name))
                {
                    if (!dict[name].Contains(award) && names.Contains(name) && songs.Contains(song))
                    {
                        dict[name].Add(award);
                    }
                }
                input = Console.ReadLine();
            }
            if (dict.Values.Count != 0)
            {
                foreach (var participant in dict.OrderByDescending(a => a.Value.Count).ThenBy(n => n.Key))
                {
                    Console.WriteLine($"{participant.Key}: {participant.Value.Count} awards");
                    foreach (var award in participant.Value.OrderBy(a => a))
                    {
                        Console.WriteLine($"--{award}");
                    }
                }
            }
            else
            {
                Console.WriteLine("No awards");
            }

        }
    }
}
