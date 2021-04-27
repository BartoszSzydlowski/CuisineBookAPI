using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
	public static class ModelBuilderExtension
	{
		public static void Seed(this ModelBuilder builder)
		{
			var userRoleId = Guid.NewGuid().ToString();
			var adminRoleId = Guid.NewGuid().ToString();
			var defaultUserId = Guid.NewGuid().ToString();

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
					Email = "test@test.com",
					PasswordHash = hasher.HashPassword(null, "test"),
					UserName = "test@test.com",
					NormalizedEmail = "TEST@TEST.COM",
					NormalizedUserName = "TEST@TEST.COM",
					Id = defaultUserId
				}
			);


			builder.Entity<IdentityUserRole<string>>().HasData(
				new IdentityUserRole<string>
				{
					RoleId = adminRoleId,
					UserId = defaultUserId
				}
			);
		}
	}
}