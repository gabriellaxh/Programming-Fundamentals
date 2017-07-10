using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace ObjectsAndClasses
{
    class Program
    {

        static void Main()
        {
            string start = Console.ReadLine();
            string end = Console.ReadLine();
            DateTime startDate = DateTime.ParseExact(start, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(end, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            DateTime[] holidays = new DateTime[11];

            holidays[0] = new DateTime(4, 01, 01);
            holidays[1] = new DateTime(4, 03, 03);
            holidays[2] = new DateTime(4, 05, 01);
            holidays[3] = new DateTime(4, 05, 06);
            holidays[4] = new DateTime(4, 05, 24);
            holidays[5] = new DateTime(4, 09, 06);
            holidays[6] = new DateTime(4, 09, 22);
            holidays[7] = new DateTime(4, 11, 01);
            holidays[8] = new DateTime(4, 12, 24);
            holidays[9] = new DateTime(4, 12, 25);
            holidays[10] = new DateTime(4, 12, 26);

            int workingDays = 0;
            for (DateTime i = startDate; i <= endDate; i = i.AddDays(1))
            {
                DayOfWeek day = i.DayOfWeek;
                DateTime curDay = new DateTime(4, i.Month, i.Day);

                if (day != DayOfWeek.Saturday && day != DayOfWeek.Sunday && !holidays.Contains(curDay))
                {
                    workingDays++;
                }
            }
            Console.WriteLine(workingDays);



        }
    }
}



