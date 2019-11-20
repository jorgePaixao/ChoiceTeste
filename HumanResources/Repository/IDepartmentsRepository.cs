using HumanResources.Models;
using HumanResources.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResources.Repository
{
    public interface IDepartmentsRepository
    {        

        Task<List<DepartmentsViewModel>> GetDepartments();

        Task<DepartmentsViewModel> GetDepartment(int? departmentId);

        Task<int> AddDepartment(Departments department);

     
    }
}
