using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week13.Application.Repositories.CustomerRepositories;
using Week13.Domain.Entities;
using Week13.Persistence.Contexts;

namespace Week13.Persistence.Repositories.CustomerRepositories
{
    public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository
    {
        public CustomerReadRepository(Week13DbContext context) : base(context)
        {
        }
    }
}
