using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        public Library(params Book[] books)
        {
            Books = books.ToList();
        }
        public List<Book> Books { get; set; }

        public IEnumerator<Book> GetEnumerator()
        {
            Books.Sort(new BookComparator());
            foreach(var book in Books)
            {
                yield return book;
            }
            //return new LibraryIterator(Books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        class LibraryIterator : IEnumerator<Book>
        {
            private int index;
            private List<Book> books;

            public LibraryIterator(List<Book> books)
            {
                this.books = books;
                index = -1;
            }

            public Book Current => books[index];

            object IEnumerator.Current => Current;

            public void Dispose()
            {

            }

            public bool MoveNext()
            {
                index++;
                if(index == books.Count)
                {
                    return false;
                }
                return true;
            }

            public void Reset()
            {
                index = -1;
            }
        }
    }
}
