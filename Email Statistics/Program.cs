using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Email_Statistics
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var dict = new Dictionary<string, List<string>>();
            var pattern = new Regex(@"\b(?<user>[A-Za-z]{5,})@(?<domain>[a-z]{3,}\.(com|org|bg))\b");
            for (int i = 0; i < n; i++)
            {
                string email = Console.ReadLine();
                var match = pattern.Match(email);
                var user = match.Groups["user"].Value;
                var domain = match.Groups["domain"].Value;
                if (match.Success)
                {
                    if (!dict.ContainsKey(domain))
                    {
                        dict[domain] = new List<string>();
                    }
                    if (!dict[domain].Contains(user))
                    {
                        dict[domain].Add(user);
                    }
                }
            }
            foreach (var domain in dict.OrderByDescending(a => a.Value.Count))
            {
                Console.WriteLine($"{domain.Key}:");
                foreach (var user in domain.Value)
                {
                    Console.WriteLine($"### {user}");
                }
            }
        }
    }
}
