using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            var removedSum = 0;
            while (nums.Count > 0)
            {
                var index = int.Parse(Console.ReadLine());

                if (index < 0)
                {
                    removedSum += nums[0];
                    var removed = nums[0];
                    nums[0] = nums[nums.Count - 1];
                    for (int i = 0; i < nums.Count; i++)
                    {
                        if (nums[i] <= removed)
                        {
                            nums[i] += removed;
                        }
                        else
                        {
                            nums[i] -= removed;
                        }
                    }
                }
                else if (index >= nums.Count)
                {
                    removedSum += nums[nums.Count - 1];

                    var removed = nums[nums.Count - 1];
                    nums[nums.Count - 1] = nums[0];
                    for (int i = 0; i < nums.Count; i++)
                    {
                        if (nums[i] <= removed)
                        {
                            nums[i] += removed;
                        }
                        else if (nums[i] > removed)
                        {
                            nums[i] -= removed;
                        }
                    }
                }
                else
                {
                    removedSum += nums[index];
                    var removed = nums[index];
                    nums.RemoveAt(index);
                    for (int i = 0; i < nums.Count; i++)
                    {
                        if (nums[i] <= removed)
                        {
                            nums[i] += removed;
                        }
                        else
                        {
                            nums[i] -= removed;
                        }
                    }
                }
            }
            Console.WriteLine($"{removedSum}");
        }
    }
}
