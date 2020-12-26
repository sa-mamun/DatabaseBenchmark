using DatabaseBenchmark.Core;
using DatabaseBenchmark.Core.Entity;
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
        public List<RootBookJso> RootBookJsos { get; set; }

        public List<RootBookJso> ListOfBookObject(int total)
        {
            var randomBookGenerator = new RandomBookGenerator();
            RootBookJsos = new List<RootBookJso>();

            for (int i=0; i<total; i++)
            {
                string key = Guid.NewGuid().ToString();
                var bookList = randomBookGenerator.GenerateBooks();
                var json = GenerateKeyValue(bookList, key);

                var rootBookJso = new RootBookJso
                {
                    Key = key,
                    Value = json
                };

                RootBookJsos.Add(rootBookJso);
            }
 
            return RootBookJsos;
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