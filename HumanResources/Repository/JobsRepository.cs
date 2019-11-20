using HumanResources.Models;
using HumanResources.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResources.Repository
{
    public class JobsRepository : IJobsRepository
    {
        HumanResourcesContext db;

        public JobsRepository(HumanResourcesContext _db)
        {
            db = _db;
        }

        public async Task<List<JobsViewModel>> GetJobs()
        {
            if (db != null)
            {
                return await (from p in db.Jobs

                              select new JobsViewModel
                              {
                                 JobId = p.JobId,
                                 JobTitle = p.JobTitle,
                                 MaxSalary = p.MaxSalary,
                                 MinSalary = p.MinSalary
                              }).ToListAsync();
            }

            return null;
        }

        public async Task<JobsViewModel> GetJob(int? jobId)
        {
            if (db != null)
            {
                return await (from p in db.Jobs
                              where p.JobId == jobId
                              select new JobsViewModel
                              {
                                  JobId = p.JobId,
                                  JobTitle = p.JobTitle,
                                  MaxSalary = p.MaxSalary,
                                  MinSalary = p.MinSalary
                              }).FirstOrDefaultAsync();
            }

            return null;
        }

        public async Task<int> AddJob(Jobs job)
        {
            if (db != null)
            {
                await db.Jobs.AddAsync(job);
                await db.SaveChangesAsync();

                return job.JobId;
            }

            return 0;
        }
    }
}
