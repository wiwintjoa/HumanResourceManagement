namespace HRMS.DataAccess.Dto
{
	public class RoleDto : AuditDto
	{
		public string Title { get; set; } = string.Empty;

		public string Description { get; set; } = string.Empty;

		public int DepartmentId { get; set; }
	}
}
