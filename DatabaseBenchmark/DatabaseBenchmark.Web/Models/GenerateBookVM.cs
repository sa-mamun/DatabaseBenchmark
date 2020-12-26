using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DatabaseBenchmark.Web.Models
{
    public class GenerateBookVM
    {
        [DisplayName("Enter Total Books:")]
        public int TotalNoOfBooks { get; set; }
        public Guid Key { get; set; }
        public string Value { get; set; }
    }
}