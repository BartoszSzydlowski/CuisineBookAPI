﻿using Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure
{
	public static class ModelBuilderExtension
	{
		public static void Seed(this ModelBuilder builder)
		{
			var userRoleId = Guid.NewGuid().ToString();
			var adminRoleId = Guid.NewGuid().ToString();

			var defaultUserId = Guid.NewGuid().ToString();
			var defaultAdminId = Guid.NewGuid().ToString();

			var hasher = new PasswordHasher<ApplicationUser>();

			builder.Entity<IdentityRole>().HasData(
				new IdentityRole
				{
					Name = "Admin",
					NormalizedName = "ADMIN",
					Id = adminRoleId
				}
			);

			builder.Entity<IdentityRole>().HasData(
				new IdentityRole
				{
					Name = "User",
					NormalizedName = "USER",
					Id = userRoleId
				}
			);

			builder.Entity<ApplicationUser>().HasData(
				new ApplicationUser
				{
					Email = "testUser@test.com",
					PasswordHash = hasher.HashPassword(null, "test"),
					UserName = "testUser",
					NormalizedEmail = "TESTUSER@TEST.COM",
					NormalizedUserName = "TESTUSER",
					Id = defaultUserId
				}
			);

			builder.Entity<IdentityUserRole<string>>().HasData(
				new IdentityUserRole<string>
				{
					RoleId = userRoleId,
					UserId = defaultUserId
				}
			);

			builder.Entity<ApplicationUser>().HasData(
				new ApplicationUser
				{
					Email = "testAdmin@test.com",
					PasswordHash = hasher.HashPassword(null, "test"),
					UserName = "testAdmin",
					NormalizedEmail = "TESTADMIN@TEST.COM",
					NormalizedUserName = "TESTADMIN",
					Id = defaultAdminId
				}
			);

			builder.Entity<IdentityUserRole<string>>().HasData(
				new IdentityUserRole<string>
				{
					RoleId = adminRoleId,
					UserId = defaultAdminId
				}
			);
		}
	}
}