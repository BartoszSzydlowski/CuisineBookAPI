using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
	public class Food
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public string Ingredients { get; set; }

		public string ImageLink { get; set; }

		[Required]
		public DateTime CreationDate { get; set; }

		[Required]
		public string Created { get; set; }

		[Required]
		public DateTime ModificationDate { get; set; }

		[Required]
		public string ModifiedBy { get; set; }

		[Required]
		public bool IsAccepted { get; set; }

		[Required]
		public string Difficulty { get; set; }

		[Required]
		public string PreparationTime { get; set; }

		[Required]
		public string CalorificValue { get; set; }

		[Required]
		public string PreparingMethod { get; set; }

		[Required]
		public string Cathegory { get; set; }
	}
}
