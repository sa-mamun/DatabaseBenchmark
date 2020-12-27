using DatabaseBenchmark.Core;
using DatabaseBenchmark.Core.Entity;
using DatabaseBenchmark.Core.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatabaseBenchmark.Web.Models
{
    public class BookModel
    {
        public List<BookJso> GenerateKeyValueBooks { get; set; }
        public List<RootBook> RootBooks { get; set; }

        private readonly IRootBookService _rootBookService = new RootBookService();

        public (string startTime, string endTime, List<RootBook> rootBooks) ListOfBookObject(int total)
        {
            var randomBookGenerator = new RandomBookGenerator();
            RootBooks = new List<RootBook>();

            for (int i=0; i<total; i++)
            {
                string key = Guid.NewGuid().ToString();
                var bookList = randomBookGenerator.GenerateBooks();
                var json = GenerateKeyValue(bookList, key);

                var rootBook = new RootBook
                {
                    BookKey = key,
                    BookValue = json
                };

                RootBooks.Add(rootBook);
            }

            string startTime = DateTime.Now.ToString("h:mm:ss tt");

            _rootBookService.AddRootBook(RootBooks);

            string endTime = DateTime.Now.ToString("h:mm:ss tt");

            return (startTime, endTime, RootBooks);
        }


        public string GenerateKeyValue(List<Book> books, string key)
        {
            GenerateKeyValueBooks = new List<BookJso>();

            var bookJso = new BookJso
            {
                Key = key,
                Books = books
            };
            string json = ConvertObjToJson(bookJso);

            return json;
        }

        public string ConvertObjToJson(BookJso bookHelperLists)
        {
            string json = JsonConvert.SerializeObject(bookHelperLists);
            return json;
        }
    }
}