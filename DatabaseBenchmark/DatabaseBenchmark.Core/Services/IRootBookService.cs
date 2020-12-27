using DatabaseBenchmark.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseBenchmark.Core.Services
{
    public interface IRootBookService
    {
        void AddRootBook(List<RootBook> rootBooks);
        RootBook GetBookByKey(string key);
    }
}
