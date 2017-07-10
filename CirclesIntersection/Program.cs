using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Globalization;
using System.IO;

namespace ObjectsAndClasses
{
    class Program
    {
        class Circle
        {
            public Point Center { get; set; }
            public int Radius { get; set; }
        }
        class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
        }

        static void Main()
        {
            var input1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var input2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Point p1 = new Point { X = input1[0], Y = input1[1] };
            Point p2 = new Point { X = input2[0], Y = input2[1] };

            Circle c1 = new Circle
            {
                Center = p1,
                Radius = input1[2]
            };
            Circle c2 = new Circle
            {
                Center = p2,
                Radius = input2[2]
            };
            var distance = calcDistance(c1, c2);
            if (distance <= c1.Radius + c2.Radius)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
        static double calcDistance(Circle c1, Circle c2)
        {
            var x1 = c1.Center.X;
            var x2 = c2.Center.X;
            var y1 = c1.Center.Y;
            var y2 = c2.Center.Y;
            var distance = Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
            return distance;
        }


    }
}





