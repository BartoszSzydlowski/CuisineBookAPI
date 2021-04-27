using Application.Interfaces;
using Application.ViewModel.FoodVm;
using AutoMapper;
using Domain.Models;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
	public class FoodService : IFoodService
	{
		private readonly IFoodRepository _foodRepository;
		private readonly IMapper _mapper;

		public FoodService(IFoodRepository foodRepository, IMapper mapper)
		{
			_foodRepository = foodRepository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<FoodDto>> GetAllFoodAsync(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy)
		{
			var food = await _foodRepository.GetAllAsync(pageNumber, pageSize, sortField, ascending, filterBy);
			return _mapper.Map<IEnumerable<FoodDto>>(food);
		}

		public async Task<IEnumerable<FoodDto>> GetAllFoodWithStatusAsync(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy, bool isAccepted)
		{
			var food = await _foodRepository.GetAllWithStatusAsync(pageNumber, pageSize, sortField, ascending, filterBy, isAccepted);
			return _mapper.Map<IEnumerable<FoodDto>>(food);
		}

		public async Task<int> GetAllFoodCountAsync(string filterBy)
		{
			return await _foodRepository.GetAllCountAsync(filterBy);
		}

		public async Task<FoodDto> GetFoodByIdAsync(int id)
		{
			var food = await _foodRepository.GetByIdAsync(id);
			return _mapper.Map<FoodDto>(food);
		}

		public async Task<FoodDto> AddNewFoodAsync(CreateFoodDto newFood, string userId)
		{
			if (string.IsNullOrEmpty(newFood.Title))
			{
				throw new Exception("Title can't have an empty title");
			}

			var food = _mapper.Map<Food>(newFood);
			food.UserId = userId;
			var result = await _foodRepository.AddAsync(food);
			return _mapper.Map<FoodDto>(result);
		}

		public async Task UpdateFoodAsync(UpdateFoodDto updateFood)
		{
			var existingFood = await _foodRepository.GetByIdAsync(updateFood.Id);
			var food = _mapper.Map(updateFood, existingFood);
			await _foodRepository.UpdateAsync(food);
		}

		public async Task DeleteFoodAsync(int id)
		{
			var food = await _foodRepository.GetByIdAsync(id);
			await _foodRepository.DeleteAsync(food);
		}

		public async Task<bool> UserOwnsFoodAsync(int foodId, string userId)
		{
			var food = await _foodRepository.GetByIdAsync(foodId);

			if (food == null)
			{
				return false;
			}

			if (food.UserId != userId)
			{
				return false;
			}

			return true;
		}
	}
}