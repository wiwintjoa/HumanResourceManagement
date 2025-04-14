namespace HRMS.DataAccess.RepositoryContract
{
	public class PagedSearchParameter
	{
		#region Properties

		public int PageIndex { get; set; }

		public int PageSize { get; set; }

		public string OrderByFieldName { get; set; } = string.Empty;

		public string SortOrder { get; set; } = string.Empty;

		public string Keyword { get; set; } = string.Empty;

		public string Filters { get; set; } = string.Empty;

		#endregion
	}
}
