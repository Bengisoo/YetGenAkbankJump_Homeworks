using Lecture7.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Lecture7.Domain.Entities
{
	public class User: EntityBase<Guid>
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		//public string Email { get; set; }
		//public string PhoneNumber { get; set; }
		//public Address Address { get; set; }
	}
}
