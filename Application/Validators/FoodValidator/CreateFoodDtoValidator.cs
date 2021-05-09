using Application.ViewModel.FoodVm;
using FluentValidation;

namespace Application.Validators.FoodValidator
{
	public class CreateFoodDtoValidator : AbstractValidator<CreateFoodDto>
	{
		public CreateFoodDtoValidator()
		{
			#region Title

			RuleFor(x => x.Title).NotEmpty().WithMessage("Title can't have an empty title");
			RuleFor(x => x.Title).Length(3, 100).WithMessage("Title must be between 5 and 100 characters long");

			#endregion Title
		}
	}
}