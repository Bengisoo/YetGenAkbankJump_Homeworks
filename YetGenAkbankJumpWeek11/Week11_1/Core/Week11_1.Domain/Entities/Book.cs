using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week11_1.Domain.Common;

namespace Week11_1.Domain.Entities
{
	public class Book : EntityBase<Guid>
	{
		public string Title { get; set; }
		public string Author { get; set; }
		public int PublicationYear { get; set; }
		public decimal PurchasePrice { get; set; }
	}
}
