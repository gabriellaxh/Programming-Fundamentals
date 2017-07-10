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
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            for (int i = 0; i < input.Length; i++)
            {
                var didiPattern = new Regex(@"[^a-zA-Z|-]+");
                var matchDidi = didiPattern.Match(input);
                var didi = matchDidi.Index;
                if (matchDidi.Success)
                {
                    Console.WriteLine(matchDidi.Value);
                    input = input.Remove(didi, matchDidi.Length);
                    input = input.Remove(0, didi);
                }

                else { return; }

                var bojoPattern = new Regex(@"[a-zA-Z]+[-][a-zA-Z]+");
                var matchBojo = bojoPattern.Match(input);
                var bojo = matchBojo.Index;
                if (matchBojo.Success)
                {
                    Console.WriteLine(matchBojo.Value);
                    input = input.Remove(bojo, matchBojo.Length);
                    input = input.Remove(0, bojo);
                }

                else { return; }

            }
        }
    }
}
