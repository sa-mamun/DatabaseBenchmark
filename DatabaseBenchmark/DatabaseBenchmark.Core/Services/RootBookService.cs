using DatabaseBenchmark.Core.Entity;
using DatabaseBenchmark.Core.Exceptions;
using DatabaseBenchmark.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseBenchmark.Core.Services
{
    public class RootBookService : IRootBookService
    {
        private readonly IRepository<RootBook> _repository;

        public RootBookService(IRepository<RootBook> repository)
        {
            _repository = repository;
        }

        public void AddRootBook(List<RootBook> rootBooks)
        {
            _repository.Insert(rootBooks);
        }

        public RootBook GetBookByKey(string bookKey)
        {
            var result = _repository.GetObject(x => x.BookKey == bookKey);
            if (result == null)
            {
                throw new CustomInvalidException("Invalid Book Key");
            }
            return result;
        }
    }
}
