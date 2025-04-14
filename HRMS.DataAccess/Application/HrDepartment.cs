using System;
using System.Collections.Generic;

namespace HRMS.DataAccess.Application;

public partial class HrDepartment
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int LocationId { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedDateTime { get; set; }

    public string LastModifiedBy { get; set; } = null!;

    public DateTime LastModifiedDateTime { get; set; }

    public virtual ICollection<HrRole> HrRoles { get; set; } = new List<HrRole>();

    public virtual HrLocation Location { get; set; } = null!;
}
