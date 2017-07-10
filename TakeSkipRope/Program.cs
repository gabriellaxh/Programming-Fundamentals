using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeSkipRope
{
    class Program
    {
        static void Main(string[] args)
        {
            var message = Console.ReadLine().ToList();

            var digits = message.Where(x => char.IsDigit(x)).Select(x => int.Parse(x.ToString())).ToList();
            var letters = message.Where(x => !char.IsDigit(x)).ToList();

            var takeList = digits.Where((digit, i) => i % 2 == 0).ToList();
            var skipList = digits.Where((digit, i) => i % 2 == 1).ToList();

            var finaltxt = string.Empty;
            var totalskip = 0;

            for (int j = 0; j < takeList.Count; j++)
            {
                var skip = skipList[j];
                var take = takeList[j];
                finaltxt += new string(letters.Skip(totalskip).Take(take).ToArray());
                totalskip += skip + take;
            }

            Console.WriteLine(finaltxt);

        }
    }
}
