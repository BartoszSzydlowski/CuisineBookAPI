using Domain.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Repositories
{
	public interface IUserRepository
	{
		IQueryable<ApplicationUser> GetAllUsers();

		Task<ApplicationUser> GetUserById(string id);

		Task<ApplicationUser> GetUserByEmailAsync(string email);

		Task<ApplicationUser> GetUserByUsernameAsync(string username);

		Task<ApplicationUser> AddUserAsync(ApplicationUser user, string password);

		Task<ApplicationUser> AddAdminUserAsync(ApplicationUser user, string password);

		Task UpdateUserAsync(ApplicationUser user);

		Task DeleteUserAsync(ApplicationUser user);
	}
}