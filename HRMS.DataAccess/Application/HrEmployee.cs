using System;
using System.Collections.Generic;

namespace HRMS.DataAccess.Application;

public partial class HrEmployee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string CreatedBy { get; set; } = null!;

    public DateTime CreatedDateTime { get; set; }

    public string LastModifiedBy { get; set; } = null!;

    public DateTime LastModifiedDateTime { get; set; }

    public virtual ICollection<HrJobHistory> HrJobHistories { get; set; } = new List<HrJobHistory>();
}
