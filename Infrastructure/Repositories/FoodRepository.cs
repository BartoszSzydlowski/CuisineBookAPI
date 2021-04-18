using Domain.Models;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
	class FoodRepository : IFoodRepository
	{
		public Task<IEnumerable<Food>> GetAllAsync(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Food>> GetAllAsync(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy, bool isAccepted)
		{
			throw new NotImplementedException();
		}
		public Task<int> GetAllCountAsync(string filterBy)
		{
			throw new NotImplementedException();
		}
		public Task<Food> GetByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<Food> AddAsync(Food food)
		{
			throw new NotImplementedException();
		}

		public Task UpdateAsync(Food food)
		{
			throw new NotImplementedException();
		}
		public Task DeleteAsync(Food food)
		{
			throw new NotImplementedException();
		}
	}
}
