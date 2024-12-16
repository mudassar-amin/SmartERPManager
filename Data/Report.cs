using System;
using System.Collections.Generic;

namespace ERPSystem.Data;

public partial class Report
{
    public int ReportId { get; set; }

    public string ReportName { get; set; } = null!;

    public int GeneratedBy { get; set; }

    public DateTime? GeneratedDate { get; set; }

    public virtual User GeneratedByNavigation { get; set; } = null!;
}
