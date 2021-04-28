using Domain.Models;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
	public class FoodRepository : IFoodRepository
	{
		private readonly Context _context;

		public FoodRepository(Context context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Food>> GetAllAsync(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy)
		{
			return await _context.Food
				   //.Where(m => m.Title.ToLower().Contains(filterBy.ToLower()) || m.Content.ToLower().Contains(filterBy.ToLower()))
				   .Where(m => m.Title.ToLower().Contains(filterBy.ToLower()))
				   .OrderByPropertyName(sortField, ascending)
				   .Skip((pageNumber - 1) * pageSize)
				   .Take(pageSize)
				   .ToListAsync();
		}

		public async Task<IEnumerable<Food>> GetAllWithStatusAsync(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy, bool isAccepted)
		{
			return await _context.Food
				   .Where(m => m.Title.ToLower().Contains(filterBy.ToLower()) && m.IsAccepted == isAccepted)
				   .OrderByPropertyName(sortField, ascending)
				   .Skip((pageNumber - 1) * pageSize)
				   .Take(pageSize)
				   .ToListAsync();
		}

		public async Task<IEnumerable<Food>> SearchAsync(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy, bool isAccepted, string searchPhrase)
		{
			IQueryable<Food> items = _context.Food
				   .Where(m => m.Title.ToLower().Contains(filterBy.ToLower()) && m.IsAccepted == isAccepted)
				   .OrderByPropertyName(sortField, ascending)
				   .Skip((pageNumber - 1) * pageSize)
				   .Take(pageSize);

			if(!string.IsNullOrEmpty(searchPhrase) || !string.IsNullOrWhiteSpace(searchPhrase))
			{
				items = items.Where(e => e.Title.Contains(searchPhrase));
			}

			return await items.ToListAsync();
		}

		public async Task<int> GetAllCountAsync(string filterBy)
		{
			return await _context.Food
				.Where(m => m.Title.ToLower().Contains(filterBy.ToLower()))
				.CountAsync();
		}

		public async Task<Food> GetByIdAsync(int id)
		{
			return await _context.Food.SingleOrDefaultAsync(x => x.Id == id);
		}

		public async Task<Food> AddAsync(Food food)
		{
			food.IsAccepted = false;
			var createdFood = await _context.Food.AddAsync(food);
			await _context.SaveChangesAsync();
			return createdFood.Entity;
		}

		public async Task UpdateAsync(Food food)
		{
			_context.Food.Update(food);
			await _context.SaveChangesAsync();
			await Task.CompletedTask;
		}

		public async Task DeleteAsync(Food food)
		{
			_context.Food.Remove(food);
			await _context.SaveChangesAsync();
			await Task.CompletedTask;
		}
	}
}