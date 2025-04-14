namespace HRMS.DataAccess.Dto
{
	public class AuditDto : BaseDto
	{
        public string CreatedBy { get; set; } = string.Empty;

        public DateTime CreatedDateTime { get; set; }

        public string LastModifiedBy { get; set; } = string.Empty;

        public DateTime LastModifiedDateTime { get; set; }
    }
}
