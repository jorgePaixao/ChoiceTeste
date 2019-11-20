using HumanResources.Models;
using HumanResources.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResources.Repository
{
    public interface IEmployeesRepository
    {
        Task<List<EmployeesViewModel>> GetEmployees();

        Task<EmployeesViewModel> GetEmployee(int? employeesId);

        Task<int> AddEmployee(Employees employees);

       
    }
}
