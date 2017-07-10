using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exam
{
    class Program
    {
        class Pokemon
        {
            public string Name { get; set; }
            public List<KeyValuePair<string, int>> EvolutionTypeAndIndex { get; set; }
        }
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var list = new List<Pokemon>();
            while (input != "wubbalubbadubdub")
            {
                var info = input.Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                if (info.Count == 1)
                {
                    var onlyName = info[0];
                    foreach (var item in list.Where(x => x.Name == onlyName))
                    {
                        Console.WriteLine($"# {item.Name}");
                        foreach (var evolution in item.EvolutionTypeAndIndex)
                        {
                            Console.WriteLine($"{evolution.Key} <-> {evolution.Value}");
                        }
                        break;
                    }
                    input = Console.ReadLine();
                    continue;
                }
                string name = info[0].Trim();
                string type = info[1].Trim();
                int index = int.Parse(info[2].Trim());
                var nameAndtypePattern = new Regex(@"[^\s->]");
                var matchName = nameAndtypePattern.Match(name);
                var matchType = nameAndtypePattern.Match(type);
                if (matchName.Success && matchType.Success)
                {
                    if (!list.Any(x => x.Name == name))
                    {
                        var newPokemon = new Pokemon()
                        {
                            Name = name,
                            EvolutionTypeAndIndex = new List<KeyValuePair<string, int>>()
                            {
                                new KeyValuePair<string, int>(type, index)
                            }

                        };
                        list.Add(newPokemon);
                    }
                    else
                    {
                        var indexOf = list.FindIndex(x => x.Name == name);
                        list[indexOf].EvolutionTypeAndIndex.Add(new KeyValuePair<string, int>(type, index));
                    }
                }
                else
                {
                    continue;
                }
                input = Console.ReadLine();
            }
            foreach (var item in list)
            {
                Console.WriteLine($"# {item.Name}");
                foreach (var evolution in item.EvolutionTypeAndIndex.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"{evolution.Key} <-> {evolution.Value}");
                }
            }
        }
    }
}
