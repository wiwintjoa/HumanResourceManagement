namespace HRMS.DataAccess.Dto
{
	public class JobHistoryDto : AuditDto
	{
		public int EmployeeId { get; set; }

        public string Manager { get; set; } = string.Empty;

        public int RoleId { get; set; }

		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }

		public string Status { get; set; } = string.Empty;

		public string Comments { get; set; } = string.Empty;
	}
}
