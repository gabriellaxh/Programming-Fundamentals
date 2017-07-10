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
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string input = Console.ReadLine();

            while (input != "end")
            {
                var whatToDo = input.Split(' ').ToList();
                var command = whatToDo[0];

                switch (command)
                {
                    case "reverse":
                        var listI = new List<string>();
                        int reverseStart = int.Parse(whatToDo[2]);
                        int reverseCount = int.Parse(whatToDo[4]);

                        if (reverseStart >= nums.Count || reverseStart < 0 || reverseCount < 0 || reverseCount >= nums.Count || reverseStart >= reverseCount)
                        {
                            Console.WriteLine("Invalid input parameters.");
                            input = Console.ReadLine();
                            continue;
                        }
                        else
                        {
                            nums.Reverse(reverseStart, reverseCount);
                        }
                        break;

                    case "sort":
                        var listII = new List<string>();
                        int sortStart = int.Parse(whatToDo[2]);
                        int sortCount = int.Parse(whatToDo[4]);
                        if (sortStart >= nums.Count || sortStart < 0 || sortCount < 0 || sortCount >= nums.Count || sortStart >= sortCount)
                        {
                            Console.WriteLine("Invalid input parameters.");
                            input = Console.ReadLine();
                            continue;
                        }
                        else
                        {
                            nums.Sort(sortStart, sortCount, null);
                        }
                        break;

                    case "rollLeft":
                        var countt = long.Parse(whatToDo[1]);
                        var rollLeft = countt % nums.Count;
                        for (long i = 0; i < rollLeft; i++)
                        {
                            var first = nums[0];
                            nums.RemoveAt(0);
                            nums.Insert(nums.Count, first);
                        }
                        break;

                    case "rollRight":
                        var counttt = long.Parse(whatToDo[1]);

                        var rollRight = counttt % nums.Count;
                        for (long i = 0; i < rollRight; i++)
                        {
                            var last = nums[nums.Count - 1];
                            nums.RemoveAt(nums.Count - 1);
                            nums.Insert(0, last);

                        }
                        break;
                }
                input = Console.ReadLine();

            }
            Console.WriteLine($"[{string.Join(", ", nums)}]");

        }
    }
}



