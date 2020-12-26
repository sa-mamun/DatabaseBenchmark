using DatabaseBenchmark.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatabaseBenchmark.Web.Models
{
    public class BookHelper
    {
        public string Key { get; set; }
        public List<Book> Books { get; set; }
    }
}