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
		public string Name { get; set; }
		public string Ingredients { get; set; }
		public string ImageLink { get; set; }
		public DateTime CreationDate { get; set; }
		public string Created { get; set; }
		public DateTime ModificationDate { get; set; }
		public string ModifiedBy { get; set; }
		public bool IsAccepted { get; set; }
		public string Difficulty { get; set; }
		public string PreparationTime { get; set; }
		public string CalorificValue { get; set; }
		public string PreparingMethod { get; set; }
		public string Cathegory { get; set; }
	}
}
