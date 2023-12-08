using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week13.Application.Repositories.ProductRepositories;
using Week13.Domain.Entities;
using Week13.Persistence.Contexts;

namespace Week13.Persistence.Repositories.ProductRepositories
{
    public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
    {
        public ProductWriteRepository(Week13DbContext context) : base(context)
        {
        }
    }
}
