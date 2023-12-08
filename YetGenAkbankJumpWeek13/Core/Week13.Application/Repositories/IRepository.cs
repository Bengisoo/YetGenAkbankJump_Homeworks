using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week13.Domain.Common;

namespace Week13.Application.Repositories
{
    public interface IRepository<T> where T: EntityBase
    {
        DbSet<T> Table {  get; }
    }
}
