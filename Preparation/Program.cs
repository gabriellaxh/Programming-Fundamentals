using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Preparation
{
    class Program
    {
        class Broadcasts
        {
            public string Name { get; set; }
            public string Nums { get; set; }
        }
        class Messages
        {
            public string Name { get; set; }
            public string Nums { get; set; }
        }

        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var broadcasts = new List<Broadcasts>();
            var messages = new List<Messages>();
            while (input != "Hornet is Green")
            {
                var broadcastpattern = new Regex(@"^(\D+) \<\-\> ([a-zA-Z0-9]+)$");
                var broadcastMatches = broadcastpattern.Matches(input);
                foreach (Match match in broadcastMatches)
                {
                    var info = Regex.Split(input, @"\s<->\s").ToList();
                    var nums = info[1].Trim().ToCharArray();
                    var name = info[0].Trim();
                    var list = new List<char>();
                    for (int i = 0; i < nums.Length; i++)
                    {
                        if (char.IsLetter(nums[i]))
                        {
                            if (char.IsUpper(nums[i]))
                            {
                                nums[i] = char.ToLower(nums[i]);
                            }
                            else
                            {
                                nums[i] = char.ToUpper(nums[i]);
                            }
                        }
                        list.Add(nums[i]);
                    }
                    string numsSting = string.Join("", list);

                    var broadcast = new Broadcasts()
                    {
                        Name = name,
                        Nums = numsSting
                    };
                    broadcasts.Add(broadcast);

                }
                var messagepattern = new Regex(@"^(\d+) \<\-\> ([a-zA-Z0-9]+)$");
                var messageMatches = messagepattern.Matches(input);
                foreach (Match match in messageMatches)
                {
                    var info = Regex.Split(input, @"\s<->\s").ToList();
                    var nums = info[0].Trim().ToCharArray();
                    var listnums = new List<char>();
                    for (int i = nums.Length - 1; i >= 0; i--)
                    {
                        listnums.Add(nums[i]);
                    }
                    string numss = string.Join("", listnums);
                    var name = info[1].Trim();
                    var message = new Messages()
                    {
                        Name = name,
                        Nums = numss
                    };
                    messages.Add(message);
                }

                input = Console.ReadLine();
            }
            Console.WriteLine("Broadcasts:");
            if (broadcasts.Count > 0)
            {
                foreach (var broadcast in broadcasts)
                {
                    Console.WriteLine($"{broadcast.Nums} -> {broadcast.Name}");
                }
            }
            else
            {
                Console.WriteLine("None");
            }
            Console.WriteLine("Messages:");
            if (messages.Count > 0)
            {
                foreach (var message in messages)
                {
                    Console.WriteLine($"{message.Nums} -> {message.Name}");
                }
            }
            else
            {
                Console.WriteLine("None");
            }
        }
    }
}



