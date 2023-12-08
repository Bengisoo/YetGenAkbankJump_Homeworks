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
    public class ReadRepository<T> : IReadRepository<T> where T : EntityBase
    {
        private readonly Week13DbContext _context;

        public ReadRepository(Week13DbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public List<T> GetAll()
        {
            return Table.ToList();
        }

        public T GetById(string id)
        {
            return Table.FirstOrDefault(x => x.Id == Guid.Parse(id));
        }
    }
}
