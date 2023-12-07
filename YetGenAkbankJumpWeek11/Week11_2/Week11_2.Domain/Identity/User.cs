using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week11_2.Domain.Entities;
using Week11_2.Domain.Enums;

namespace Week11_2.Domain.Identity
{
	public class User : IdentityUser<Guid>, IEntityBase<Guid>, ICreatedByEntity, IModifiedByEntity
	{
        public string FirstName { get; set; }
        public string  SurName { get; set; }
        public DateTimeOffset? BirthDate { get; set; }
        public Gender Gender { get; set; }
		public UserSetting UserSetting { get; set; }

		

        public string CreatedByUserId { get; set; }
		public DateTimeOffset CreatedOn { get ; set; }
		public string? ModifiedByUserId { get; set; }
		public DateTimeOffset? LastModifiedOn { get; set; }
	}
}
