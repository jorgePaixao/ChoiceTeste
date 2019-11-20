using System;
using System.Collections.Generic;

namespace HumanResources.Models
{
    public partial class Employees
    {
        public int EmployeeId { get; set; }
        public int? ManagerId { get; set; }
        public int? DepartmentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? HireDdate { get; set; }
        public string JobId { get; set; }
        public decimal? Salary { get; set; }
        public int? ComissionPct { get; set; }
    }
}
