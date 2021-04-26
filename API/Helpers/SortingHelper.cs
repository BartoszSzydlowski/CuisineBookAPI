using System.Collections.Generic;

namespace API.Helpers
{
	public static class SortingHelper
	{
		public static KeyValuePair<string, string>[] GetSortFields()
		{
			return new[]
			{
				SortFields.Title, SortFields.CreationDate
			};
		}
	}

	public static class SortFields
	{
		public static KeyValuePair<string, string> Title { get; set; } = new KeyValuePair<string, string>("title", "Title");
		public static KeyValuePair<string, string> CreationDate { get; set; } = new KeyValuePair<string, string>("creationdate", "Created");
	}
}