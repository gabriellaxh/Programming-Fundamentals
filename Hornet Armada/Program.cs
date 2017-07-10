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
            var n = int.Parse(Console.ReadLine());
            var activityAndLegion = new Dictionary<string, int>();
            var legionSoldier = new Dictionary<string, Dictionary<string, long>>();
            for (int i = 0; i < n; i++)
            {
                var info = Console.ReadLine().Split(new string[] { "=", "->", ":" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                int lastActivity = int.Parse(info[0]);
                string legionName = info[1].Trim();
                string soldierType = info[2].Trim();
                int soldierCount = int.Parse(info[3]);

                if (!activityAndLegion.ContainsKey(legionName))
                {
                    activityAndLegion[legionName] = lastActivity;
                }
                else
                {
                    if (lastActivity > activityAndLegion[legionName])
                    {
                        activityAndLegion[legionName] = lastActivity;
                    }
                }
                if (!legionSoldier.ContainsKey(legionName))
                {
                    legionSoldier[legionName] = new Dictionary<string, long>();
                    legionSoldier[legionName].Add(soldierType, soldierCount);
                }
                else
                {
                    if (legionSoldier[legionName].ContainsKey(soldierType))
                    {
                        legionSoldier[legionName][soldierType] += soldierCount;
                    }
                    else
                    {
                        legionSoldier[legionName].Add(soldierType, soldierCount);
                    }
                }
            }
            string end = Console.ReadLine();
            if (end.Contains('\\'))
            {
                var info = end.Split('\\').ToList();
                int boundary = int.Parse(info[0]);
                string type = info[1];
                foreach (var legion in legionSoldier.Where(x => x.Value.ContainsKey(type)).OrderByDescending(x => x.Value[type]))
                {
                    if (activityAndLegion[legion.Key] < boundary)
                    {
                        Console.WriteLine($"{legion.Key} -> {legionSoldier[legion.Key][type]}");
                    }
                }
            }
            else
            {
                foreach (var legion in activityAndLegion.OrderByDescending(x => x.Value))
                {
                    if (legionSoldier[legion.Key].ContainsKey(end))
                    {
                        Console.WriteLine($"{legion.Value} : {legion.Key}");
                    }
                }
            }
        }
    }
}



