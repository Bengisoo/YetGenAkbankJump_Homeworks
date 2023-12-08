using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week13.Domain.Common;

namespace Week13.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T: EntityBase
    {
        void Add(T entity);
        void Delete (string id);
        void SaveChanges();
    }
}
