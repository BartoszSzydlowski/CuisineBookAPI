using Application.Services;
using Domain.Models;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure
{
	public class Context : IdentityDbContext<ApplicationUser>
	{
		private readonly UserResolverService _userResolverService;

		public Context(DbContextOptions<Context> options, UserResolverService userResolverService) : base(options)
		{
			_userResolverService = userResolverService;
		}

		public DbSet<Food> Food { get; set; }

		public async Task<int> SaveChangesAsync()
		{
			var entries = ChangeTracker
				.Entries()
				.Where(e => e.Entity is AuditableEntity
					&& (e.State == EntityState.Added || e.State == EntityState.Modified));

			foreach (var entry in entries)
			{
				((AuditableEntity)entry.Entity).LastModified = DateTime.UtcNow;
				//((AuditableEntity)entry.Entity).LastModifiedBy = _userResolverService.GetUser();

				if (entry.State == EntityState.Added)
				{
					((AuditableEntity)entry.Entity).Created = DateTime.UtcNow;
					//((AuditableEntity)entry.Entity).CreatedBy = _userResolverService.GetUser();
				}
			}

			return await base.SaveChangesAsync();
		}
	}
}