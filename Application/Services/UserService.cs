using Application.Interfaces;
using Application.ViewModel.UserVm;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Identity;
using Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
	public class UserService : IUserService
	{

		private readonly IUserRepository _userRepository;
		private readonly IMapper _mapper;

		public UserService(IUserRepository userRepository, IMapper mapper)
		{
			_userRepository = userRepository;
			_mapper = mapper;
		}

		public async Task<UserDto> AddAdminUserAsync(CreateUserDto dto)
		{
			var user = _mapper.Map<ApplicationUser>(dto);
			var result = await _userRepository.AddAdminUserAsync(user, dto.Password);
			return _mapper.Map<UserDto>(result);
		}

		public async Task<UserDto> AddUserAsync(CreateUserDto dto)
		{
			var user = _mapper.Map<ApplicationUser>(dto);
			var result = await _userRepository.AddUserAsync(user, dto.Password);
			return _mapper.Map<UserDto>(result);
		}

		public async Task DeleteUserAsync(UserDto dto)
		{
			var user = await _userRepository.GetUserById(dto.Id);
			await _userRepository.DeleteUserAsync(user);
		}

		public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
		{
			return await _userRepository.GetAllUsers()
					  .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
					  .ToListAsync();
		}

		public async Task<UserDto> GetUserByEmailAsync(string email)
		{
			var user = await _userRepository.GetUserByEmailAsync(email);
			return _mapper.Map<UserDto>(user);
		}

		public async Task<UserDto> GetUserById(string id)
		{
			var user = await _userRepository.GetUserById(id);
			return _mapper.Map<UserDto>(user);
		}

		public async Task<UserDto> GetUserByUsernameAsync(string username)
		{
			var user = await _userRepository.GetUserByUsernameAsync(username);
			return _mapper.Map<UserDto>(user);
		}

		public async Task UpdateUserAsync(UpdateUserDto dto)
		{
			var existingUser = await _userRepository.GetUserById(dto.Id);
			var user = _mapper.Map(dto, existingUser);
			await _userRepository.UpdateUserAsync(user);
		}

		public async Task<bool> ValidateCurrentUser(string userId)
		{
			var user = await _userRepository.GetUserById(userId);

			if (user == null)
			{
				return false;
			}

			if (user.Id != userId)
			{
				return false;
			}

			return true;
		}
	}
}
