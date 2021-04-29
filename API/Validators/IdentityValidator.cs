using API.Models;
using FluentValidation;

namespace API.Validators
{
	public class IdentityValidator : AbstractValidator<RegisterModel>
	{
		public IdentityValidator()
		{
			#region Email

			RuleFor(x => x.Email).NotEmpty().WithMessage("E-mail field can't be empty");
			RuleFor(x => x.Email).EmailAddress().WithMessage("Incorrect e-mail format");

			#endregion Email

			#region Password

			RuleFor(x => x.Password)
				.NotEmpty().WithMessage("Password field can't be empty")
				.Must(x => x.Length > 2).WithMessage("Password must have at least 3 characters");

			#endregion Password

			#region Username

			RuleFor(x => x.Username)
				.NotEmpty().WithMessage("Password field can't be empty");

			#endregion Username
		}
	}
}