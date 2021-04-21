using Application.Services;
using Domain.Models;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

		public DbSet<Food> Food { get;set; }
	}
}
