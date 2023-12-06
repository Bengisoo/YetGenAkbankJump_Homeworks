using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week11_2.Domain.Identity;

namespace Week11_2.Persistence.Configurations.Indentity
{
	public class UserSettingConfiguration : IEntityTypeConfiguration<UserSetting>
	{
		public void Configure(EntityTypeBuilder<UserSetting> builder)
		{
			
			builder.HasOne<User>(x => x.User)
				.WithOne(u => u.UserSetting)
				.HasForeignKey<UserSetting>(us => us.UserId);


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

			builder.ToTable("UserSettings");
		}
	}
}
