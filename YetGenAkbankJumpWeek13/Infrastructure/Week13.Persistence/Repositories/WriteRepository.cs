using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week13.Application.Repositories;
using Week13.Domain.Common;
using Week13.Persistence.Contexts;

namespace Week13.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : EntityBase
    {
        private readonly Week13DbContext _context;

        public WriteRepository(Week13DbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public void Add(T entity)
        {
            Table.Add(entity);
        }

        public void Delete(string id)
        {
            var entity = Table.FirstOrDefault(x=>x.Id == Guid.Parse(id));
            Table.Remove(entity);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
