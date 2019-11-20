using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HumanResources.Models;
using HumanResources.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace HumanResources.Repository
{
    public class DepartmentsRepository : IDepartmentsRepository
    {
        HumanResourcesContext db;

        public DepartmentsRepository(HumanResourcesContext _db)
        {
            db = _db;
        }     

        public async Task<List<DepartmentsViewModel>> GetDepartments()
        {
            if (db != null)
            {
                return await (from p in db.Departments
                                                            
                              select new DepartmentsViewModel
                              {
                                  DepartmentId = p.DepartmentId,                                   
                                  DepartmentName = p.DepartmentName                                  
                              }).ToListAsync();
            }

            return null;
        }

        public async Task<DepartmentsViewModel> GetDepartment(int? detDepartmentID)
        {
            if (db != null)
            {
                return await (from p in db.Departments                           
                              where p.DepartmentId == detDepartmentID
                              select new DepartmentsViewModel
                              {
                                  DepartmentId = p.DepartmentId,
                                  DepartmentName = p.DepartmentName
                              }).FirstOrDefaultAsync();
            }

            return null;
        }

        public async Task<int> AddDepartment(Departments department)
        {
            if (db != null)
            {
                await db.Departments.AddAsync(department);
                await db.SaveChangesAsync();

                return department.DepartmentId;
            }

            return 0;
        }
       
    }
}
