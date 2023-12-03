using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week11_1.Domain.Entities;

namespace Week11_1.Persistence.Contexts
{
	public class Week11_1DbContext: DbContext
	{
		public DbSet<Book> Books { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseInMemoryDatabase("FluentApi_ZBD");
		}
	}
}
