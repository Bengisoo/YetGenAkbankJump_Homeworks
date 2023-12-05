using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week11_2.Domain.Dtos
{
	public class ProductDto
	{
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
    }
}
