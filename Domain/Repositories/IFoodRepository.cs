using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
	public interface IFoodRepository
	{
		Task<IEnumerable<Food>> GetAllAsync(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy);
		Task<IEnumerable<Food>> GetAllAsync(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy, bool isAccepted);
		Task<int> GetAllCountAsync(string filterBy);
		Task<Food> GetByIdAsync(int id);
		Task<Food> AddAsync(Food food);
		Task UpdateAsync(Food food);
		Task DeleteAsync(Food food);
	}
}
