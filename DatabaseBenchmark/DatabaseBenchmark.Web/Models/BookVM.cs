using DatabaseBenchmark.Core.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatabaseBenchmark.Web.Models
{
    public class BookVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public List<BookHelper> GenerateKeyValueBooks { get; set; }
        public List<RootBookHelper> RootBookHelpers { get; set; }

        public List<RootBookHelper> ListOfBookObject(int total)
        {
            var randomBookGenerator = new RandomBookGenerator();
            RootBookHelpers = new List<RootBookHelper>();

            for (int i=0; i<total; i++)
            {
                string key = Guid.NewGuid().ToString();
                var bookList = randomBookGenerator.GenerateBooks();
                GenerateKeyValueBooks = GenerateKeyValue(bookList, key);
                string json = ConvertObjToJson(GenerateKeyValueBooks);

                var rootBookHelper = new RootBookHelper
                {
                    Key = key,
                    Value = json
                };

                RootBookHelpers.Add(rootBookHelper);
            }
 
            return RootBookHelpers;
        }

        public List<BookHelper> GenerateKeyValue(List<Book> books, string key)
        {
            GenerateKeyValueBooks = new List<BookHelper>();

            var bookHelper = new BookHelper
            {
                Key = key,
                Books = books
            };

            GenerateKeyValueBooks.Add(bookHelper);

            return GenerateKeyValueBooks;
        }

        public string ConvertObjToJson(List<BookHelper> bookHelperLists)
        {
            string json = JsonConvert.SerializeObject(bookHelperLists);
            return json;
        }
    }
}