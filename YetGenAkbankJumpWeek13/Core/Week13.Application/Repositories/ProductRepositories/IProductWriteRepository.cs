using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week13.Domain.Common;
using Week13.Domain.Entities;

namespace Week13.Application.Repositories.ProductRepositories
{
    public interface IProductWriteRepository: IWriteRepository<Product> 
    {
    }
}
