using API.Wrappers;
using Application.Interfaces;
using Application.ViewModel.UserVm;
using Domain.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUserService _userService;

		public UserController(IUserService userService)
		{
			_userService = userService;
		}

		[SwaggerOperation(Summary = "Gets all users")]
		[HttpGet("[action]")]
		[Authorize(Roles = UserRoles.Admin)]
		public async Task<IActionResult> GetAll()
		{
			var users = await _userService.GetAllUsersAsync();
			return Ok(users);
		}

		[SwaggerOperation(Summary = "Gets user by id")]
		[HttpGet("[action]")]
		[Authorize(Roles = UserRoles.Admin)]
		public async Task<IActionResult> GetById(string id)
		{
			var user = await _userService.GetUserById(id);
			return Ok(user);
		}

		[SwaggerOperation(Summary = "Gets user by email")]
		[HttpGet("[action]")]
		[Authorize(Roles = UserRoles.Admin)]
		public async Task<IActionResult> GetByEmail(string email)
		{
			var user = await _userService.GetUserByEmailAsync(email);
			return Ok(user);
		}

		[SwaggerOperation(Summary = "Gets user by username")]
		[HttpGet("[action]")]
		[Authorize(Roles = UserRoles.Admin)]
		public async Task<IActionResult> GetByUsername(string email)
		{
			var user = await _userService.GetUserByUsernameAsync(email);
			return Ok(user);
		}

		[SwaggerOperation(Summary = "Adds normal user")]
		[HttpPost("[action]")]
		[Authorize(Roles = UserRoles.Admin)]
		public async Task<IActionResult> AddUserAsync(CreateUserDto dto)
		{
			var user = await _userService.AddUserAsync(dto);
			return Ok(user);
		}

		[SwaggerOperation(Summary = "Adds admin user")]
		[HttpPost("[action]")]
		[Authorize(Roles = UserRoles.Admin)]
		public async Task<IActionResult> AddAdminUserAsync(CreateUserDto dto)
		{

			var user = await _userService.AddAdminUserAsync(dto);
			return Ok(user);
		}

		[SwaggerOperation(Summary = "Updates user")]
		[HttpPut]
		[Authorize(Roles = UserRoles.AdminOrUser)]
		public async Task<IActionResult> UpdateUserAsync(UpdateUserDto dto)
		{
			var userOwnsPost = await _userService.ValidateCurrentUser(User.FindFirstValue(ClaimTypes.NameIdentifier));
			var isAdmin = User.IsInRole(UserRoles.Admin);

			if (!isAdmin && !userOwnsPost)
			{
				return BadRequest(new Response(false, "You can only update your account"));
			}

			await _userService.UpdateUserAsync(dto);
			return NoContent();
		}

		[SwaggerOperation(Summary = "Deletes user")]
		[HttpDelete]
		[Authorize(Roles = UserRoles.AdminOrUser)]
		public async Task<IActionResult> DeleteUserAsync(UserDto dto)
		{
			var userOwnsPost = await _userService.ValidateCurrentUser(User.FindFirstValue(ClaimTypes.NameIdentifier));
			var isAdmin = User.IsInRole(UserRoles.Admin);

			if (!isAdmin && !userOwnsPost)
			{
				return BadRequest(new Response(false, "You can only delete your account"));
			}

			await _userService.DeleteUserAsync(dto);
			return NoContent();
		}
	}
}
