using Application.Mapping;
using AutoMapper;
using Domain.Identity;

namespace Application.ViewModel.UserVm
{
	public class UserDto : IMap
	{
		public string Id { get; set; }
		public string Username { get; set; }
		public string Email { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<ApplicationUser, UserDto>()
				.ReverseMap();
		}
	}
}