﻿namespace HRMS.DataAccess.Dto
{
	public class EmployeeDto : AuditDto
	{
        public string Name { get; set; } = string.Empty;

        public DateTime BirthDate { get; set; }

        public string Phone { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Gender { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;
    }
}
