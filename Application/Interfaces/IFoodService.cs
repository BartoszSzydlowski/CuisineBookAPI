﻿using Application.ViewModel.FoodVm;
using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
	public interface IFoodService
	{
		Task<IEnumerable<FoodDto>> GetAllFoodAsync(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy);

		Task<IEnumerable<FoodDto>> GetAllFoodWithStatusAsync(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy, bool isAccepted);

		Task<int> GetAllFoodCountAsync(string filterBy);

		Task<FoodDto> GetFoodByIdAsync(int id);

		Task<FoodDto> AddNewFoodAsync(CreateFoodDto newFood, string userId);

		Task UpdateFoodAsync(UpdateFoodDto updateFood);

		Task DeleteFoodAsync(int id);

		Task<bool> UserOwnsFoodAsync(int foodId, string userId);
	}
}