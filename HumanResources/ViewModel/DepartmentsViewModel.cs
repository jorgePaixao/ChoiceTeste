using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResources.ViewModel
{
    public class DepartmentsViewModel
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int? ManagerId { get; set; }
        public int? LocationId { get; set; }
    }
}
