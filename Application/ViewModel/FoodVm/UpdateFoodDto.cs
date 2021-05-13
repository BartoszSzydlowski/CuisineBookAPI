using Application.Mapping;
using AutoMapper;
using Domain.Models;

namespace Application.ViewModel.FoodVm
{
	public class UpdateFoodDto : IMap
	{
		public int Id { get; set; }
		public string Ingredients { get; set; }
		public string ImageLink { get; set; }
		public string Difficulty { get; set; }
		public string PreparationTime { get; set; }
		public int CalorificValue { get; set; }
		public string PreparingMethod { get; set; }
		public string Cathegory { get; set; }
		public bool IsAccepted { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<UpdateFoodDto, Food>().ReverseMap();
		}
	}
}