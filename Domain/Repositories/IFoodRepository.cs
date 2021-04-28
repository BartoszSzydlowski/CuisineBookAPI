using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Repositories
{
	public interface IFoodRepository
	{
		Task<IEnumerable<Food>> GetAllAsync(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy);

		Task<IEnumerable<Food>> GetAllWithStatusAsync(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy, bool isAccepted);


		Task<Food> GetByIdAsync(int id);
		Task<IEnumerable<Food>> SearchAsync(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy, bool isAccepted, string searchPhrase);
		Task<int> GetAllCountAsync(string filterBy);

		Task<Food> AddAsync(Food food);

		Task UpdateAsync(Food food);

		Task DeleteAsync(Food food);
	}
}