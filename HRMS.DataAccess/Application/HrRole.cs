using System;
using System.Collections.Generic;

namespace HRMS.DataAccess.Application;

public partial class HrRole
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int DepartmentId { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedDateTime { get; set; }

    public string LastModifiedBy { get; set; } = null!;

    public DateTime LastModifiedDateTime { get; set; }

    public virtual HrDepartment Department { get; set; } = null!;

    public virtual ICollection<HrJobHistory> HrJobHistories { get; set; } = new List<HrJobHistory>();
}
