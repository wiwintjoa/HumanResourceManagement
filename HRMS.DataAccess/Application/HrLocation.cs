using System;
using System.Collections.Generic;

namespace HRMS.DataAccess.Application;

public partial class HrLocation
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedDateTime { get; set; }

    public string LastModifiedBy { get; set; } = null!;

    public DateTime LastModifiedDateTime { get; set; }

    public virtual ICollection<HrDepartment> HrDepartments { get; set; } = new List<HrDepartment>();
}
