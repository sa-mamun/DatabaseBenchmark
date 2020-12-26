using DatabaseBenchmark.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatabaseBenchmark.Core
{
    public class RandomBookGenerator
    {
        public List<Book> Books { get; set; }
        public List<Book> GenerateBooks()
        {
            Books = new List<Book>();
            for(int i=1; i<= 100; i++)
            {
                var book = new Book
                {
                    Id = i,
                    Name = "Book" + i,
                    Author = "Author" + i
                };
                Books.Add(book);
            }

            return Books;
        }
    }
}