using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Globalization;

namespace ObjectsAndClasses
{
    class Program
    {
        class Student
        {
            public string Name { get; set; }
            public List<double> Grades { get; set; }
            public double AverageGrades => Grades.Average();
        }
        static void Main()
        {
            var students = new List<Student>();
            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                var info = Console.ReadLine().Split();
                var name = info[0];
                var grades = info.Skip(1).Select(double.Parse).ToList();


                var student = new Student
                {
                    Name = name,
                    Grades = grades
                };
                students.Add(student);
            }
            students = students
                .Where(x => x.AverageGrades >= 5.00)
                .OrderBy(x => x.Name)
                .ThenByDescending(x => x.AverageGrades)
                .ToList();
            foreach (var student in students)
            {
                Console.WriteLine($"{student.Name} -> {student.AverageGrades:f2}");
            }


        }
    }
}



