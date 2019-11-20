using HumanResources.Models;
using HumanResources.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResources.Repository
{
    public interface IJobsRepository
    {

        Task<List<JobsViewModel>> GetJobs();

        Task<JobsViewModel> GetJob(int? jobId);

        Task<int> AddJob(Jobs job);
    }
}
