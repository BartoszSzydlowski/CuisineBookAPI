using Application.Mapping;
using AutoMapper;
using Domain.Models;
using System;

namespace Application.ViewModel.FoodVm
{
	public class FoodDto : IMap
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Ingredients { get; set; }
		public string ImageLink { get; set; }
		public string Difficulty { get; set; }
		public string PreparationTime { get; set; }
		public int CalorificValue { get; set; }
		public string PreparingMethod { get; set; }
		public string Cathegory { get; set; }
		public bool IsAccepted { get; set; }
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