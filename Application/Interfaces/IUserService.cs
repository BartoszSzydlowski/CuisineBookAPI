using Application.ViewModel.UserVm;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
	public interface IUserService
	{
		Task<IEnumerable<UserDto>> GetAllUsersAsync();

		Task<UserDto> GetUserById(string id);

		Task<UserDto> GetUserByEmailAsync(string email);

		Task<UserDto> GetUserByUsernameAsync(string username);

		Task<UserDto> AddUserAsync(CreateUserDto user);

		Task<UserDto> AddAdminUserAsync(CreateUserDto user);

		Task UpdateUserAsync(UpdateUserDto user);

		Task DeleteUserAsync(UserDto user);

		Task<bool> ValidateCurrentUser(string userId);
	}
}