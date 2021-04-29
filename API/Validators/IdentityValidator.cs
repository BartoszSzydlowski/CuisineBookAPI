using API.Models;
using FluentValidation;

namespace API.Validators
{
	public class IdentityValidator : AbstractValidator<RegisterModel>
	{
		public IdentityValidator()
		{
			#region Email

			RuleFor(x => x.Email).NotNull().NotEmpty().WithMessage("E-mail field can't be empty")
				.EmailAddress().WithMessage("Incorrect e-mail format");

			#endregion

			#region Password

			RuleFor(x => x.Password).NotNull().NotEmpty().WithMessage("Password field can't be empty")
				.MinimumLength(3).WithMessage("Password must have at least 3 characters");

			#endregion

			#region Username

			RuleFor(x => x.Username).NotNull().NotEmpty().WithMessage("Username field can't be empty")
				.MinimumLength(3).WithMessage("Username must have at least 3 characters");

			#endregion
		}
	}
}