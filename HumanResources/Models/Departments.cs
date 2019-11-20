using System;
using System.Collections.Generic;

namespace HumanResources.Models
{
    public partial class Departments
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int? ManagerId { get; set; }
        public int? LocationId { get; set; }
    }
}
