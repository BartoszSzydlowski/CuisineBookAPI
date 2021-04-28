using Application.Mapping;
using AutoMapper;
using Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.UserVm
{
	public class CreateUserDto : IMap
	{
		public string Username { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<CreateUserDto, ApplicationUser>().ReverseMap();
		}
	}
}
