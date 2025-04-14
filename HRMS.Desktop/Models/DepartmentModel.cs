namespace HRMS.Desktop.Models
{
	public class DepartmentModel :AuditModel
	{
		public string Name { get; set; } = string.Empty;

		public string Description { get; set; } = string.Empty;

		public int LocationId { get; set; }

		public LocationModel Location { get; set; } = null!;
	}
}
