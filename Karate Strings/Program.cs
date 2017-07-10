using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_KarateStrings
{
    class KarateStrings
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var punchStrength = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '>')
                {
                    punchStrength += int.Parse(input[i + 1].ToString());

                    if (input[i + 1] != '>' && punchStrength > 0)
                    {
                        input = input.Remove(i + 1, 1);
                        punchStrength--;
                    }

                }

                else
                {
                    if (punchStrength > 0)
                    {
                        input = input.Remove(i, 1);
                        punchStrength--;
                        i--;
                    }
                }
            }
            Console.WriteLine(input);
        }
    }
}
