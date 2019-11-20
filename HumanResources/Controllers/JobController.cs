using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HumanResources.Models;
using HumanResources.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HumanResources.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        IJobsRepository JobsRepository;


        public JobController(IJobsRepository _JobsRepository)
        {
            JobsRepository = _JobsRepository;
        }


        [HttpGet]
        [Route("GetJobs")]
        public async Task<IActionResult> GetJobs()
        {
            try
            {
                var posts = await JobsRepository.GetJobs();
                if (posts == null)
                {
                    return NotFound();
                }

                return Ok(posts);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetJob")]
        public async Task<IActionResult> GetJob(int? postId)
        {
            if (postId == null)
            {
                return BadRequest();
            }

            try
            {
                var post = await JobsRepository.GetJob(postId);

                if (post == null)
                {
                    return NotFound();
                }

                return Ok(post);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("AddJob")]
        public async Task<IActionResult> AddPost([FromBody]Jobs model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var postId = await JobsRepository.AddJob(model);
                    if (postId > 0)
                    {
                        return Ok(postId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }

            return BadRequest();
        }
    }
}