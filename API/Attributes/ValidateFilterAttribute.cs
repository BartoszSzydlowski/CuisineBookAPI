using API.Wrappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Linq;

namespace API.Attributes
{
	public class ValidateFilterAttribute : ResultFilterAttribute
	{
		public override void OnResultExecuting(ResultExecutingContext context)
		{
			base.OnResultExecuting(context);

			if (!context.ModelState.IsValid)
			{
				List<string> errors = new List<string>();
				var entries = context.ModelState.Values.ToList();
				foreach(var entry in entries)
				{
					errors.AddRange(entry.Errors.Select(x => x.ErrorMessage));
				}

				context.Result = new BadRequestObjectResult(new Response<bool>
				{
					Succeeded = false,
					Message = "Something went wrong.",
					Errors = errors
				});
			}
		}
	}
}