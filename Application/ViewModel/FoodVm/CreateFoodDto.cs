using Application.Mapping;
using AutoMapper;
using Domain.Models;

namespace Application.ViewModel.FoodVm
{
	public class CreateFoodDto : IMap
	{
		public string Title { get; set; }
		public string Ingredients { get; set; }
		public string ImageLink { get; set; }
		public string Difficulty { get; set; }
		public string PreparationTime { get; set; }
		public int CalorificValue { get; set; }
		public string PreparingMethod { get; set; }
		public string Cathegory { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<CreateFoodDto, Food>().ReverseMap();
		}
	}
}