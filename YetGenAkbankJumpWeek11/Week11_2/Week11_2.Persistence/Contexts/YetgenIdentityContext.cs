using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Week11_2.Domain.Entities;
using Week11_2.Domain.Identity;

namespace Week11_2.Persistence.Contexts
{
    public class YetgenIdentityContext: IdentityDbContext<User,Role,Guid>
	{
        public YetgenIdentityContext(DbContextOptions<YetgenIdentityContext> dbContextOptions) : base(dbContextOptions)
		{//    YetgenIdentityContext

		}
		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

			builder.Ignore<Product>();
			builder.Ignore<Category>();
			builder.Ignore<ProductCategory>();
			base.OnModelCreating(builder);
		}

	}
}
