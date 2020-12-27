using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatabaseBenchmark.Core.Entity
{
    public class RootBook
    {
        public virtual int Id { get; set; }
        public virtual string BookKey { get; set; }
        public virtual string BookValue { get; set; }
    }
}