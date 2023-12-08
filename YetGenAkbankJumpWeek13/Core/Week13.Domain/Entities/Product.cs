using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week13.Domain.Common;

namespace Week13.Domain.Entities
{
    public class Product: EntityBase
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
