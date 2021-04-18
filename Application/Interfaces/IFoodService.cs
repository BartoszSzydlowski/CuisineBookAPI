using Application.ViewModel;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
	public interface IFoodService
	{
		Task<IEnumerable<FoodDto>> GetAllFoodAsync(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy);
		Task<IEnumerable<FoodDto>> GetAllFoodAsync(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy, bool isAccepted);
		Task<int> GetAllFoodCountAsync(string filterBy);
		Task<Food> GetFoodByIdAsync(int id);
		Task<Food> AddNewFoodAsync(CreateFoodDto newFood, string userId);
		Task UpdateFoodAsync(UpdateFoodDto updateFood);
		Task DeleteFoodAsync(int id);
		Task<bool> UserOwnsFoodAsync(int foodId, string userId);
	}
}