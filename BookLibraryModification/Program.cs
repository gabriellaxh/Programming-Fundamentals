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
        class Library
        {
            public string Name { get; set; }
            public List<Book> Books { get; set; }
        }
        public class Book
        {
            public string title { get; set; }
            public string author { get; set; }
            public string publisher { get; set; }
            public DateTime releaseDate { get; set; }
            public string ISBN { get; set; }
            public double Price { get; set; }
        }
        public static List<Book> GetBooks()
        {
            int n = int.Parse(Console.ReadLine());
            List<Book> books = new List<Book>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                DateTime date = DateTime.ParseExact(input[3], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                Book book = new Book()
                {
                    title = input[0],
                    author = input[1],
                    publisher = input[2],
                    releaseDate = date,
                    ISBN = input[4],
                    Price = double.Parse(input[5])
                };
                books.Add(book);
            }
            return books;
        }
        static void Main()
        {
            Library library = new Library { Name = "Heyo", Books = GetBooks() };
            var beforethisdate = Console.ReadLine();
            var spcdate = DateTime.ParseExact(beforethisdate, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            foreach (var books in library.Books.Where(x => x.releaseDate > spcdate).OrderBy(x => x.releaseDate).ThenBy(x => x.title))
            {
                Console.WriteLine($"{books.title} -> {books.releaseDate:dd.MM.yyyy}");
            }

        }
    }
}




