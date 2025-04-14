using System;
using System.Collections.Generic;

namespace HRMS.DataAccess.Application;

public partial class HrJobHistory
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public string Manager { get; set; } = null!;

    public int RoleId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string Status { get; set; } = null!;

    public string? Comments { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedDateTime { get; set; }

    public string LastModifiedBy { get; set; } = null!;

    public DateTime LastModifiedDateTime { get; set; }

    public virtual HrEmployee Employee { get; set; } = null!;

    public virtual HrRole Role { get; set; } = null!;
}
