using Domain.Identity;
using Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly Context _context;
		private readonly UserManager<ApplicationUser> _userManager;

		public UserRepository(Context context, UserManager<ApplicationUser> userManager)
		{
			_context = context;
			_userManager = userManager;
		}

		public IQueryable<ApplicationUser> GetAllUsers()
		{
			return _context.Users;
		}

		public async Task<ApplicationUser> GetUserById(string id)
		{
			return await _userManager.FindByIdAsync(id);
		}

		public async Task<ApplicationUser> GetUserByEmailAsync(string email)
		{
			return await _userManager.FindByEmailAsync(email);
		}

		public async Task<ApplicationUser> GetUserByUsernameAsync(string username)
		{
			return await _userManager.FindByNameAsync(username);
		}

		public async Task<ApplicationUser> AddUserAsync(ApplicationUser user, string password)
		{
			var findUser = await _userManager.FindByNameAsync(user.UserName);

			if(findUser != null)
			{
				throw new Exception("User already exists");
			}

			ApplicationUser newUser = new ApplicationUser()
			{
				Email = user.Email,
				SecurityStamp = Guid.NewGuid().ToString(),
				UserName = user.UserName
			};

			var userResult = await _userManager.CreateAsync(newUser, password);

			var roleResult = await _userManager.AddToRoleAsync(newUser, UserRoles.User);

			if(!userResult.Succeeded || !roleResult.Succeeded)
			{
				throw new Exception("Failed to create user");
			}

			return newUser;
		}

		public async Task<ApplicationUser> AddAdminUserAsync(ApplicationUser user, string password)
		{
			var findUser = await _userManager.FindByNameAsync(user.UserName);

			if (findUser != null)
			{
				throw new Exception("User already exists");
			}

			ApplicationUser newUser = new ApplicationUser()
			{
				Email = user.Email,
				SecurityStamp = Guid.NewGuid().ToString(),
				UserName = user.UserName
			};

			var userResult = await _userManager.CreateAsync(newUser, password);

			var roleResult = await _userManager.AddToRoleAsync(newUser, UserRoles.Admin);

			if (!userResult.Succeeded || !roleResult.Succeeded)
			{
				throw new Exception("Failed to create admin user");
			}

			return newUser;
		}

		public async Task UpdateUserAsync(ApplicationUser user)
		{
			_context.Users.Update(user);
			await _context.SaveChangesAsync();
			await Task.CompletedTask;
		}

		public async Task DeleteUserAsync(ApplicationUser user)
		{
			_context.Users.Remove(user);
			await _context.SaveChangesAsync();
			await Task.CompletedTask;
		}
	}
}
