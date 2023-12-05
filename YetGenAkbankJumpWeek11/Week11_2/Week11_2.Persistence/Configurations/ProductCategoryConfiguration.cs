using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week11_2.Domain.Entities;

namespace Week11_2.Persistence.Configurations
{
	public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
	{
		public void Configure(EntityTypeBuilder<ProductCategory> builder)
		{
			//Primary key
			builder.HasKey(x => new {x.ProductId, x.CategoryId });

			builder.HasOne<Product>(x => x.Product)
				.WithMany(x => x.ProductCategories)
				.HasForeignKey(x => x.ProductId);

			builder.HasOne<Category>(x=>x.Category)
				.WithMany(x=>x.ProductCategories)
				.HasForeignKey(x=>x.CategoryId);


			builder.Property(x=>x.CreatedByUserId).IsRequired();
			builder.Property(x => x.CreatedByUserId).HasMaxLength(75);

			builder.Property(x=>x.CreatedOn).IsRequired();

			builder.ToTable("ProductCategories");


		}
	}
}
