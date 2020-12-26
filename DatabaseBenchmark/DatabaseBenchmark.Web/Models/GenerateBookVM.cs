using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DatabaseBenchmark.Web.Models
{
    public class GenerateBookVM
    {
        [DisplayName("Enter Total Books:")]
        [Range(1, int.MaxValue, ErrorMessage = "Enter Positive Value")]
        public int TotalNoOfBooks { get; set; }
        
        public int Id { get; set; }
        public Guid Key { get; set; }
        public string Value { get; set; }
    }
}