using System;
using System.Collections.Generic;

namespace ERPSystem.Data;

public partial class Salary
{
    public int SalaryId { get; set; }

    public int EmployeeId { get; set; }

    public string? PayPeriod { get; set; }

    public decimal? GrossSalary { get; set; }

    public decimal? NetSalary { get; set; }

    public decimal? TaxAmount { get; set; }

    public DateTime? PaymentDate { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}
