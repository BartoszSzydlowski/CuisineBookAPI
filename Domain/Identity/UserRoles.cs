//namespace Infrastructure.Identity
namespace Domain.Identity
{
	public static class UserRoles
	{
		public const string Admin = "Admin";
		public const string User = "User";
		public const string AdminOrUser = Admin + ", " + User;
	}
}