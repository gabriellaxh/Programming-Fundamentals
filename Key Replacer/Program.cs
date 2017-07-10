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

            string textI = Console.ReadLine();
            var regexI = new Regex(@"(?<start>\w+)[<\/\|](\w+)[<\/\|](?<end>\w+)");
            var matchI = regexI.Match(textI);
            var start = matchI.Groups["start"].Value;
            var end = matchI.Groups["end"].Value;
            string textII = Console.ReadLine();
            var regexII = new Regex($@"{start}(?<word>[a-zA-Z]*?){end}");
            var matchesII = regexII.Matches(textII);
            var list = new List<string>();

            foreach (Match match in matchesII)
            {
                list.Add(string.Join("", match.Groups["word"].Value));
            }
            bool @is = list.All(e => e == "");
            if (@is)
            {
                Console.WriteLine("Empty result");
            }
            else
            {
                Console.WriteLine(string.Join("", list));
            }


        }
    }
}
