using Domain.Identity;
using Domain.Repositories;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services)
		{
			services.AddIdentity<ApplicationUser, IdentityRole>(options =>
			{
				options.Password.RequiredLength = 3;
				options.Password.RequireLowercase = false;
				options.Password.RequireUppercase = false;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireDigit = false;
			})
				   .AddEntityFrameworkStores<Context>()
				   .AddDefaultTokenProviders();

			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IFoodRepository, FoodRepository>();
			return services;
		}
	}
}