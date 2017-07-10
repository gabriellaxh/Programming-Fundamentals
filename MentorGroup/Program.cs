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
        class Student
        {
            public string Name { get; set; }
            public List<string> comments { get; set; }
            public List<DateTime> attendance { get; set; }
        }
        static void Main()
        {
            string input = Console.ReadLine();
            var studentsDict = new SortedDictionary<string, Student>();
            while (input != "end of dates")
            {
                string[] info = input.Split(' ');
                string name = info[0];
                var listOfDates = new List<DateTime>();
                if (info.Length > 1)
                {
                    string[] dates = info[1].Split(',');

                    for (int i = 0; i < dates.Length; i++)
                    {
                        DateTime currDate = DateTime.ParseExact(dates[i], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        listOfDates.Add(currDate);
                    }
                }
                var student = new Student();
                student.Name = name;
                if (!studentsDict.ContainsKey(name))
                {
                    studentsDict[name] = new Student()
                    {
                        Name = name,
                        attendance = listOfDates
                    };
                }
                else
                {
                    studentsDict[name].attendance.AddRange(listOfDates);
                }
                input = Console.ReadLine();
            }
            string input1 = Console.ReadLine();
            while (input1 != "end of comments")
            {
                string[] info1 = input1.Split('-');
                string name = info1[0];
                string comment = info1[1];
                var comments = new List<string>();
                comments.Add(comment);
                if (studentsDict.ContainsKey(name))
                {
                    if (studentsDict[name].comments != null)
                    {
                        studentsDict[name].comments.AddRange(comments);
                    }
                    else
                    {
                        studentsDict[name].comments = comments;
                    }
                }

                input1 = Console.ReadLine();
            }
            foreach (var stud in studentsDict)
            {
                Console.WriteLine($"{stud.Key}");
                Console.WriteLine("Comments:");

                if (stud.Value.comments != null)
                {
                    foreach (var com in stud.Value.comments)
                    {
                        Console.WriteLine($"- {com}");
                    }
                }
                Console.WriteLine("Dates attended:");
                foreach (var date in stud.Value.attendance.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {date:dd/MM/yyyy}");
                }
            }

        }
    }
}







