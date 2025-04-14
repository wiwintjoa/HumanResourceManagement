namespace HRMS.Desktop.Models
{
	public class AuditModel : BaseModel
	{
		public string CreatedBy { get; set; } = string.Empty;

		public DateTime CreatedDateTime { get; set; }

		public string LastModifiedBy { get; set; } = string.Empty;

		public DateTime LastModifiedDateTime { get; set; }
	}
}
