using System;
using System.Collections.Generic;

namespace HumanResources.Models
{
    public partial class Jobs
    {
        public int JobId { get; set; }
        public string JobTitle { get; set; }
        public decimal? MinSalary { get; set; }
        public decimal? MaxSalary { get; set; }
    }
}
