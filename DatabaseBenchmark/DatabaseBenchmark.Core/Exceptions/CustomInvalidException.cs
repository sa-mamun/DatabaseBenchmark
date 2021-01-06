using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseBenchmark.Core.Exceptions
{
    public class CustomInvalidException : Exception
    {
        public string ExceptionMessage { get; set; }
        public CustomInvalidException(String message)
            : base(message)
        {
            ExceptionMessage = message;
        }
    }
}
