namespace HRMS.Desktop.Models
{
	public class RoleModel : AuditModel
	{
		public string Title { get; set; } = string.Empty;

		public string Description { get; set; } = string.Empty;

		public int DepartmentId { get; set; }

		public DepartmentModel Department { get; set; }
	}
}
