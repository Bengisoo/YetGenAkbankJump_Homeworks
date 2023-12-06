using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Week11_2.Domain.Entities;
using Week11_2.Domain.Identity;

namespace Week11_2.Persistence.Contexts
{
	public class ApplicationDbContext: DbContext
	{
		public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products { get; set; }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
		{

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			modelBuilder.Ignore<User>();
			modelBuilder.Ignore<Role>();
			modelBuilder.Ignore<UserSetting>();
			base.OnModelCreating(modelBuilder);
		}
	}
}
