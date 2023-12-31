﻿using Lecture7.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture7.Persistence.Contexts
{
	public class Week7_DbContext: DbContext
	{
		public DbSet<Car> Cars { get; set; }
		public DbSet<CarPost> CarPosts { get; set; }
		public DbSet<User> Users { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
		}

	}
}
