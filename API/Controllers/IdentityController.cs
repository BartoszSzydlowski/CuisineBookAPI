using API.Models;
using API.Wrappers;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class IdentityController : ControllerBase
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly IConfiguration _configuration;

		public IdentityController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
		{
			_userManager = userManager;
			_roleManager = roleManager;
			_configuration = configuration;
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("[action]")]
		public async Task<IActionResult> Register(RegisterModel registerModel)
		{
			var userExists = await _userManager.FindByNameAsync(registerModel.Email);
			if (userExists != null)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new Response<bool>
				{
					Succeeded = false,
					Message = "User already exists!"
				});
			}

			ApplicationUser newUser = new ApplicationUser()
			{
				Email = registerModel.Email,
				SecurityStamp = Guid.NewGuid().ToString(),
				UserName = registerModel.Email
			};

			var result = await _userManager.CreateAsync(newUser, registerModel.Password);
			if (!result.Succeeded)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new Response<bool>
				{
					Succeeded = false,
					Message = "User creation failed! Please check user details and try again",
					Errors = result.Errors.Select(x => x.Description)
				});
			}

			if (!await _roleManager.RoleExistsAsync(UserRoles.User))
			{
				await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));
			}

			await _userManager.AddToRoleAsync(newUser, UserRoles.User);

			return Ok(new Response<bool> { Succeeded = true, Message = "User created successfully!" });
		}

		[HttpPost]
		[Authorize(Roles = UserRoles.Admin)]
		[Route("[action]")]
		public async Task<IActionResult> RegisterAdmin(RegisterModel registerModel)
		{
			var userExists = await _userManager.FindByNameAsync(registerModel.Email);
			if (userExists != null)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new Response<bool>
				{
					Succeeded = false,
					Message = "User already exists!"
				});
			}

			ApplicationUser newUser = new ApplicationUser()
			{
				Email = registerModel.Email,
				SecurityStamp = Guid.NewGuid().ToString(),
				UserName = registerModel.Email
			};

			var result = await _userManager.CreateAsync(newUser, registerModel.Password);
			if (!result.Succeeded)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new Response<bool>
				{
					Succeeded = false,
					Message = "Admin user creation failed! Please check user details and try again",
					Errors = result.Errors.Select(x => x.Description)
				});
			}

			if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
			{
				await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
			}

			await _userManager.AddToRoleAsync(newUser, UserRoles.Admin);

			return Ok(new Response<bool> { Succeeded = true, Message = "User created successfully!" });
		}

		[HttpPost]
		[AllowAnonymous]
		[Route("[action]")]
		public async Task<IActionResult> Login(LoginModel loginModel)
		{
			var user = await _userManager.FindByNameAsync(loginModel.Email);
			if (user != null && await _userManager.CheckPasswordAsync(user, loginModel.Password))
			{
				var authClaims = new List<Claim>
				{
					new Claim(ClaimTypes.NameIdentifier, user.Id),
					new Claim(ClaimTypes.Name, user.UserName),
					new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				};

				var userRoles = await _userManager.GetRolesAsync(user);
				foreach (var role in userRoles)
				{
					authClaims.Add(new Claim(ClaimTypes.Role, role));
				}

				var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

				var token = new JwtSecurityToken(
					expires: DateTime.Now.AddHours(2),
					claims: authClaims,
					signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
					);

				return Ok(new
				{
					token = new JwtSecurityTokenHandler().WriteToken(token),
					expiration = token.ValidTo
				});
			}

			return Unauthorized(new Response<bool> { Succeeded = false, Message = "Bad credentials. Check email or password" });
			//return Unauthorized();
		}
	}
}