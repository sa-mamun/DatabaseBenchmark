using DatabaseBenchmark.Web.Entity;
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
        public List<GenerateBookVM> GenerateBookVMs { get; set; }

        public List<GenerateBookVM> ListOfBookObject(int total)
        {
            var randomBookGenerator = new RandomBookGenerator();
            GenerateBookVMs = new List<GenerateBookVM>();

            for (int i=0; i<total; i++)
            {
                var bookList = randomBookGenerator.GenerateBooks();
                string json = ConvertObjToJson(bookList);
                GenerateBookVMs = GenerateKeyValue(json);
            }
 
            return GenerateBookVMs;
        }

        public List<GenerateBookVM> GenerateKeyValue(string json)
        {
            var generateBookVM = new GenerateBookVM
            {
                Key = Guid.NewGuid(),
                Value = json
            };

            GenerateBookVMs.Add(generateBookVM);

            return GenerateBookVMs;
        }

        public string ConvertObjToJson(List<Book> bookLists)
        {
            string json = JsonConvert.SerializeObject(bookLists);
            return json;
        }
    }
}