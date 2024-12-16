using System;
using System.Collections.Generic;

namespace ERPSystem.Data;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public int? DepartmentId { get; set; }

    public DateTime? HireDate { get; set; }

    public decimal? Salary { get; set; }

    public virtual Department? Department { get; set; }

    public virtual ICollection<Salary> Salaries { get; set; } = new List<Salary>();
}
