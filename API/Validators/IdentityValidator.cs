//using API.Models;
//using FluentValidation;

//namespace API.Validators
//{
//	public class IdentityValidator : AbstractValidator<RegisterModel>
//	{
//		[System.Obsolete]
//		public IdentityValidator()
//		{
//			RuleSet("Username", () =>
//			{
//				#region Email

//				RuleFor(x => x.Email).NotEmpty().WithMessage("E-mail field can't be empty");
//				RuleFor(x => x.Email).EmailAddress().WithMessage("Incorrect e-mail format");

//				#endregion

//				#region Password

//				RuleFor(x => x.Password).NotEmpty().WithMessage("Password field can't be empty");
//				RuleFor(x => x.Password).MinimumLength(3).WithMessage("Password must have at least 3 characters");

//				#endregion

//				#region Username

//				RuleFor(x => x.Username).NotEmpty().WithMessage("Username field can't be empty");
//				RuleFor(x => x.Username).MinimumLength(3).WithMessage("Username must have at least 3 characters");

//				#endregion
//			});
//		}
//	}
//}