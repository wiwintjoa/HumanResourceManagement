namespace HRMS.DataAccess.Dto
{
	public class DepartmentDto : AuditDto
	{
		public string Name { get; set; } = string.Empty;

		public string Description { get; set; } = string.Empty;

		public int LocationId { get; set; }
	}
}
