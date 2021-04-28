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
	public class UpdateUserDto : IMap
	{
		public string Id { get; set; }
		public string Email { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<UpdateUserDto, ApplicationUser>().ReverseMap();
		}
	}
}
