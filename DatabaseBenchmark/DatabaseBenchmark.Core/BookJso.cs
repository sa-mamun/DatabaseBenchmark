using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatabaseBenchmark.Core
{
    public class BookJso
    {
        public string Key { get; set; }
        public List<Book> Books { get; set; }
    }
}