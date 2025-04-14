namespace HRMS.DataAccess.Dto
{
	public class LocationDto: AuditDto
	{
		public string Name { get; set; } = string.Empty;
		public string City { get; set; } = string.Empty;
		public string Country { get; set; } = string.Empty;

	}
}
