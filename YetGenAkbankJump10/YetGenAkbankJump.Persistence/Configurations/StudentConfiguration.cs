using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YetGenAkbankJump.Domain.Entities;

namespace YetGenAkbankJump.Persistence.Configurations
{
	public class StudentConfiguration : IEntityTypeConfiguration<Student>
	{
		public void Configure(EntityTypeBuilder<Student> builder)
		{
			//id
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).ValueGeneratedOnAdd();

			//firstname
			builder.Property(x => x.FirstName).IsRequired();
			builder.Property(x => x.FirstName).HasMaxLength(60);

			//lastname
			builder.Property(x => x.LastName).IsRequired();
			builder.Property(x => x.LastName).HasMaxLength(60);

			//country
			builder.Property(x => x.Country).IsRequired();
			builder.Property(x => x.Country).HasMaxLength(150);

			//city
			builder.Property(x => x.City).IsRequired();
			builder.Property(x => x.City).HasMaxLength(150);

			//compaGenAkbankJump.WebApiny
			builder.Property(x => x.Company).IsRequired();
			builder.Property(x => x.Company).HasMaxLength(250);

			//age
			builder.Property(x=>x.Age).IsRequired();
			builder.Property(x => x.Age).HasColumnType("smallint");

			//registrationFee
			builder.Property(x=>x.RegistrationFee).IsRequired(false);
			//builder.Property(x=>x.RegistrationFee).HasColumnType("decimal(19,2)");
			

			//gender
			builder.Property(x=>x.Gender).IsRequired();
			builder.Property(x => x.Gender).HasConversion<int>();

			//isgraduated
			builder.Property(x=>x.IsGraduated).IsRequired();
			builder.Property(x => x.IsGraduated).HasDefaultValueSql("false");


			// Common Fields

			// CreatedByUserId
			builder.Property(x => x.CreatedByUserId).IsRequired();
			builder.Property(x => x.CreatedByUserId).HasMaxLength(75);

			// CreatedOn
			builder.Property(x => x.CreatedOn).IsRequired();

			// ModifiedByUserId
			builder.Property(x => x.ModifiedByUserId).IsRequired(false);
			builder.Property(x => x.ModifiedByUserId).HasMaxLength(75);

			// LastModifiedOn
			builder.Property(x => x.LastModifiedOn).IsRequired(false);

			// DeletedByUserId
			builder.Property(x => x.DeletedByUserId).IsRequired(false);
			builder.Property(x => x.DeletedByUserId).HasMaxLength(75);

			// DeletedOn
			builder.Property(x => x.DeletedOn).IsRequired(false);

			// IsDeleted
			builder.Property(x => x.IsDeleted).IsRequired();


			builder.ToTable("Students");
		}
	}
}
