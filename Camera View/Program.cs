using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegEx
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int toSkip = nums[0] + 2;
            //+2,защото започва да брои от "|<"
            int toTake = nums[1];
            string text = Console.ReadLine();

            var matched = new List<string>();
            var regex = new Regex(@"\|<\w+");
            MatchCollection matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                matched.Add(string.Join("", match.Value.Skip(toSkip).Take(toTake).ToArray()));
            }
            Console.WriteLine(string.Join(", ", matched));

        }
    }
}
