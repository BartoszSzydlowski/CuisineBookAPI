using Application.Mapping;
using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel
{
	public class FoodDto : IMap
	{
		public int Id { get; set; }
		public DateTime CreationDate { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<Food, FoodDto>()
				.ForMember(dest => dest.CreationDate,
					opt => opt.MapFrom(src => src.Created))
				.ReverseMap();
		}
	}
}