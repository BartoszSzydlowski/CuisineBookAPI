using API.Attributes;
using API.Filters;
using API.Helpers;
using API.Wrappers;
using Application.Interfaces;
using Application.ViewModel.FoodVm;
using Domain.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FoodController : ControllerBase
	{
		private readonly IFoodService _foodService;

		public FoodController(IFoodService foodService)
		{
			_foodService = foodService;
		}

		[AllowAnonymous]
		[SwaggerOperation(Summary = "Retrieves sort fields")]
		[HttpGet("[action]")]
		public IActionResult GetSortFields()
		{
			return Ok(SortingHelper.GetSortFields().Select(x => x.Key));
		}

		[Authorize(Roles = UserRoles.Admin)]
		[SwaggerOperation(Summary = "Retrieves all food")]
		[HttpGet]
		public async Task<IActionResult> Get([FromQuery] PaginationFilter paginationFilter,
			[FromQuery] SortingFilter sortingFilter,
			[FromQuery] string filterBy = "")
		{
			var validPaginationFilter = new PaginationFilter(paginationFilter.PageNumber, paginationFilter.PageSize);
			var validSortingFilter = new SortingFilter(sortingFilter.SortField, sortingFilter.Ascending);

			var food = await _foodService.GetAllFoodAsync(validPaginationFilter.PageNumber, validPaginationFilter.PageSize,
															validSortingFilter.SortField, validSortingFilter.Ascending,
															filterBy);

			var totalRecords = await _foodService.GetAllFoodCountAsync(filterBy);
			return Ok(PaginationHelper.CreatePagedResponse(food, validPaginationFilter, totalRecords));
		}

		[AllowAnonymous]
		[SwaggerOperation(Summary = "Retrieves all food with accept status")]
		[HttpGet("[action]")]
		public async Task<IActionResult> GetAccepted([FromQuery] PaginationFilter paginationFilter,
		   [FromQuery] SortingFilter sortingFilter,
		   [FromQuery] string filterBy = "",
		   [FromQuery] bool isAccepted = true)
		{
			var validPaginationFilter = new PaginationFilter(paginationFilter.PageNumber, paginationFilter.PageSize);
			var validSortingFilter = new SortingFilter(sortingFilter.SortField, sortingFilter.Ascending);

			var food = await _foodService.GetAllFoodWithStatusAsync(validPaginationFilter.PageNumber, validPaginationFilter.PageSize,
															validSortingFilter.SortField, validSortingFilter.Ascending,
															filterBy, isAccepted);

			var totalRecords = await _foodService.GetAllFoodCountAsync(filterBy);
			return Ok(PaginationHelper.CreatePagedResponse(food, validPaginationFilter, totalRecords));
		}

		[SwaggerOperation(Summary = "Retrieves a specific food by id")]
		[AllowAnonymous]
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			var food = await _foodService.GetFoodByIdAsync(id);
			if (food == null)
			{
				return NotFound();
			}
			return Ok(new Response<FoodDto>(food));
		}

		[SwaggerOperation(Summary = "Search with phrase")]
		[AllowAnonymous]
		[HttpGet("{search}")]
		public async Task<IActionResult> Search([FromQuery] PaginationFilter paginationFilter,
		   [FromQuery] SortingFilter sortingFilter,
		   [FromQuery] string filterBy = "",
		   [FromQuery] bool isAccepted = true,
		   [FromQuery] string searchPhrase = "")
		{
			var validPaginationFilter = new PaginationFilter(paginationFilter.PageNumber, paginationFilter.PageSize);
			var validSortingFilter = new SortingFilter(sortingFilter.SortField, sortingFilter.Ascending);

			var food = await _foodService.SearchAsync(validPaginationFilter.PageNumber, validPaginationFilter.PageSize,
															validSortingFilter.SortField, validSortingFilter.Ascending,
															filterBy, isAccepted, searchPhrase);

			var totalRecords = await _foodService.GetAllFoodCountAsync(filterBy);
			return Ok(PaginationHelper.CreatePagedResponse(food, validPaginationFilter, totalRecords));
		}

		[ValidateFilter]
		[SwaggerOperation(Summary = "Creates new food")]
		[Authorize(Roles = UserRoles.AdminOrUser)]
		[HttpPost]
		public async Task<IActionResult> Create(CreateFoodDto newFood)
		{
			//var validator = new CreateFoodDtoValidator();
			//var validatorResult = validator.Validate(newFood);

			//if (!validatorResult.IsValid)
			//{
			//	return BadRequest(new Response<bool>
			//	{
			//		Succeeded = false,
			//		Message = "Something went wrong",
			//		Errors = validatorResult.Errors.Select(x => x.ErrorMessage)
			//	});
			//}

			var food = await _foodService.AddNewFoodAsync(newFood, User.FindFirstValue(ClaimTypes.NameIdentifier));
			return Created($"api/posts/{food.Id}", new Response<FoodDto>(food));
		}

		[SwaggerOperation(Summary = "Updates existing food")]
		[Authorize(Roles = UserRoles.AdminOrUser)]
		[HttpPut]
		public async Task<IActionResult> Update(UpdateFoodDto updateFood)
		{
			var userOwnsFood = await _foodService.UserOwnsFoodAsync(updateFood.Id, User.FindFirstValue(ClaimTypes.NameIdentifier));
			var isAdmin = User.IsInRole(UserRoles.Admin);

			if (!isAdmin && !userOwnsFood)
			{
				return BadRequest(new Response(false, "You don't own this food"));
			}

			await _foodService.UpdateFoodAsync(updateFood);
			return NoContent();
		}

		[SwaggerOperation(Summary = "Deletes specific food")]
		[Authorize(Roles = UserRoles.AdminOrUser)]
		[HttpDelete("{id}")]
		//s
		public async Task<IActionResult> Delete(int id)
		{
			var userOwnsFood = await _foodService.UserOwnsFoodAsync(id, User.FindFirstValue(ClaimTypes.NameIdentifier));
			var isAdmin = User.IsInRole(UserRoles.Admin);

			if (!isAdmin && !userOwnsFood)
			{
				return BadRequest(new Response(false, "You don't own this food"));
			}

			await _foodService.DeleteFoodAsync(id);
			return NoContent();
		}
	}
}