namespace HRMS.Desktop.Models
{
	public class LocationModel : AuditModel
	{
		public string Name { get; set; } = string.Empty;
		public string City { get; set; } = string.Empty;
		public string Country { get; set; } = string.Empty;
	}
}
