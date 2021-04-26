using Domain.Repositories;
using Infrastructure.Identity;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services)
		{
			services.AddIdentity<ApplicationUser, IdentityRole>()
				   .AddEntityFrameworkStores<Context>()
				   .AddDefaultTokenProviders();

			services.AddScoped<IFoodRepository, FoodRepository>();
			return services;
		}
	}
}