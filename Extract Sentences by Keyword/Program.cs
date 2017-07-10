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
            string sep = Console.ReadLine().ToLower();
            var text = Console.ReadLine().Split(new char[] { '!', '?', '.' }, StringSplitOptions.RemoveEmptyEntries);
            var pattern = $@"\b({sep}+)\b";

            for (int i = 0; i < text.Length; i++)
            {
                var match = Regex.Match(text[i], pattern);

                if (match.Success == true)
                {
                    Console.WriteLine(text[i].TrimStart());
                }

            }


        }

    }
}
