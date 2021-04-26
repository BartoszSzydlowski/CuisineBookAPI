using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
	public class Food : AuditableEntity
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Title { get; set; }

		[Required]
		public string Ingredients { get; set; }

		public string ImageLink { get; set; }

		[Required]
		public bool IsAccepted { get; set; }

		[Required]
		public string Difficulty { get; set; }

		[Required]
		public string PreparationTime { get; set; }

		[Required]
		public int CalorificValue { get; set; }

		[Required]
		public string PreparingMethod { get; set; }

		[Required]
		public string Cathegory { get; set; }

		[Required]
		[MaxLength(450)]
		public string UserId { get; set; }
	}
}