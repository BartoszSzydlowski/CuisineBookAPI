﻿using API.Filters;
using API.Helpers;
using API.Wrappers;
using Application.Interfaces;
using Application.ViewModel.FoodVm;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Controllers
{
	[AllowAnonymous]
	[Route("api/[controller]")]
	[ApiController]
	public class FoodController : ControllerBase
	{
		private readonly IFoodService _foodService;

		public FoodController(IFoodService foodService)
		{
			_foodService = foodService;
		}

		[SwaggerOperation(Summary = "Retrieves sort fields")]
		[HttpGet("[action]")]
		public IActionResult GetSortFields()
		{
			return Ok(SortingHelper.GetSortFields().Select(x => x.Key));
		}

		[SwaggerOperation(Summary = "Retrieves all food")]
		[HttpGet]
		public async Task<IActionResult> Get([FromQuery] PaginationFilter paginationFilter,
			[FromQuery] SortingFilter sortingFilter,
			[FromQuery] string filterBy = "")
		{
			var validPaginationFilter = new PaginationFilter(paginationFilter.PageNumber, paginationFilter.PageSize);
			var validSortingFilter = new SortingFilter(sortingFilter.SortField, sortingFilter.Ascending);

			var posts = await _foodService.GetAllFoodAsync(validPaginationFilter.PageNumber, validPaginationFilter.PageSize,
															validSortingFilter.SortField, validSortingFilter.Ascending,
															filterBy);

			var totalRecords = await _foodService.GetAllFoodCountAsync(filterBy);
			return Ok(PaginationHelper.CreatePagedResponse(posts, validPaginationFilter, totalRecords));
		}

		[SwaggerOperation(Summary = "Retrieves all food with accept status")]
		[HttpGet("ShowWithStatus")]
		public async Task<IActionResult> GetAccepted([FromQuery] PaginationFilter paginationFilter,
		   [FromQuery] SortingFilter sortingFilter,
		   [FromQuery] string filterBy = "",
		   [FromQuery] bool isAccepted = true)
		{
			var validPaginationFilter = new PaginationFilter(paginationFilter.PageNumber, paginationFilter.PageSize);
			var validSortingFilter = new SortingFilter(sortingFilter.SortField, sortingFilter.Ascending);

			var posts = await _foodService.GetAllFoodWithStatusAsync(validPaginationFilter.PageNumber, validPaginationFilter.PageSize,
															validSortingFilter.SortField, validSortingFilter.Ascending,
															filterBy, isAccepted);

			var totalRecords = await _foodService.GetAllFoodCountAsync(filterBy);
			return Ok(PaginationHelper.CreatePagedResponse(posts, validPaginationFilter, totalRecords));
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

		[SwaggerOperation(Summary = "Creates new food")]
		[HttpPost]
		public async Task<IActionResult> Create(CreateFoodDto newPost)
		{
			var food = await _foodService.AddNewFoodAsync(newPost, User.FindFirstValue(ClaimTypes.NameIdentifier));
			return Created($"api/posts/{food.Id}", new Response<FoodDto>(food));
		}

		[SwaggerOperation(Summary = "Updates existing food")]
		[HttpPut]
		public async Task<IActionResult> Update(UpdateFoodDto updatePost)
		{
			//var userOwnsPost = await _foodService.UserOwnsFoodAsync(updatePost.Id, User.FindFirstValue(ClaimTypes.NameIdentifier));
			//var isAdmin = User.IsInRole(UserRoles.Admin);

			//if (!isAdmin && !userOwnsPost)
			//{
			//	return BadRequest(new Response(false, "You don't own this post"));
			//}

			await _foodService.UpdateFoodAsync(updatePost);
			return NoContent();
		}

		[SwaggerOperation(Summary = "Deletes specific food")]
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			//var userOwnsPost = await _foodService.UserOwnsFoodAsync(id, User.FindFirstValue(ClaimTypes.NameIdentifier));
			//var isAdmin = User.IsInRole(UserRoles.Admin);

			//if (!isAdmin && !userOwnsPost)
			//{
			//	return BadRequest(new Response(false, "You don't own this post"));
			//}

			await _foodService.DeleteFoodAsync(id);
			return NoContent();
		}
	}
}