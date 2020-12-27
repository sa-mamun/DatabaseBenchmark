using DatabaseBenchmark.Core.Entity;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseBenchmark.Core.Mappings
{
    public class RootBookMapping : ClassMap<RootBook>
    {
        public RootBookMapping()
        {
            Table("tblRootBook");
            Id(x => x.Id);
            Map(x => x.BookKey);
            Map(x => x.BookValue);
        }
    }
}
