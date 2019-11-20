using HumanResources.Models;
using HumanResources.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResources.Repository
{
    public class EmployeesRepository : IEmployeesRepository
    {
        HumanResourcesContext db;

        public EmployeesRepository(HumanResourcesContext _db)
        {
            db = _db;
        }

        public async Task<List<EmployeesViewModel>> GetEmployees()
        {
            if (db != null)
            {
                return await (from p in db.Employees

                              select new EmployeesViewModel
                              {
                                  EmployeeId = p.EmployeeId,
                                  Email = p.Email,
                                  FirstName = p.FirstName,
                                  LastName = p.LastName,
                                  DepartmentId = p.DepartmentId,
                                  ComissionPct = p.ComissionPct,
                                  HireDdate = p.HireDdate,
                                  JobId = p.JobId,
                                  ManagerId = p.ManagerId,
                                  PhoneNumber = p.PhoneNumber,
                                  Salary = p.Salary
                              }).ToListAsync();
            }

            return null;
        }

        public async Task<EmployeesViewModel> GetEmployee(int? employeeID)
        {
            if (db != null)
            {
                return await (from p in db.Employees
                              where p.EmployeeId == employeeID
                              select new EmployeesViewModel
                              {
                                  EmployeeId = p.EmployeeId,
                                  Email = p.Email,
                                  FirstName = p.FirstName,
                                  LastName = p.LastName,
                                  DepartmentId = p.DepartmentId,
                                  ComissionPct = p.ComissionPct,
                                  HireDdate = p.HireDdate,
                                  JobId = p.JobId,
                                  ManagerId = p.ManagerId,
                                  PhoneNumber = p.PhoneNumber,
                                  Salary = p.Salary
                              }).FirstOrDefaultAsync();
            }

            return null;
        }

        public async Task<int> AddEmployee(Employees Employee)
        {
            if (db != null)
            {
                await db.Employees.AddAsync(Employee);
                await db.SaveChangesAsync();

                return Employee.EmployeeId;
            }

            return 0;
        }

      
    }
}
