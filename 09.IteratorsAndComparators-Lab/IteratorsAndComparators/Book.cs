using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorsAndComparators
{
    public class Book : IComparable<Book>
    {
        public Book(string title, int year, params string[] authors)
        {
            Title = title;
            Year = year;
            Authors = authors.ToList();
        }

        public string Title { get; set; }

        public int Year { get; set; }

        public List<string> Authors { get; set; }

        public int CompareTo(Book other)
        {
            if(this.Year < other.Year) 
                return -1;
            if(this.Year > other.Year) 
                return 1;
            if(this.Title.CompareTo(other.Title) < 0)
                return -1;
            if(this.Title.CompareTo(other.Title) > 0)
                return 1;
            return 0;
        }

        public override string ToString()
        {
            return $"{Title} - {Year}";
        }
    }
}
