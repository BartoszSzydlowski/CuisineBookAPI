using Application.Interfaces;
using Application.ViewModel.FoodVm;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
	public class FoodService : IFoodService
	{
		public Task<IEnumerable<FoodDto>> GetAllFoodAsync(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<FoodDto>> GetAllFoodAsync(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy, bool isAccepted)
		{
			throw new NotImplementedException();
		}

		public Task<int> GetAllFoodCountAsync(string filterBy)
		{
			throw new NotImplementedException();
		}

		public Task<Food> GetFoodByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<Food> AddNewFoodAsync(CreateFoodDto newFood, string userId)
		{
			throw new NotImplementedException();
		}

		public Task UpdateFoodAsync(UpdateFoodDto updateFood)
		{
			throw new NotImplementedException();
		}

		public Task DeleteFoodAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<bool> UserOwnsFoodAsync(int foodId, string userId)
		{
			throw new NotImplementedException();
		}
	}
}