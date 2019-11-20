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
    public class DepartmentsController : ControllerBase
    {
        IDepartmentsRepository departmentsRepository;


        public DepartmentsController(IDepartmentsRepository _departmentsRepository)
        {
            departmentsRepository = _departmentsRepository;
        }
      

        [HttpGet]
        [Route("GetDepartments")]
        public async Task<IActionResult> GetDepartments()
        {
            try
            {
                var posts = await departmentsRepository.GetDepartments();
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
        [Route("GetDepartment")]
        public async Task<IActionResult> GetDepartment(int? postId)
        {
            if (postId == null)
            {
                return BadRequest();
            }

            try
            {
                var post = await departmentsRepository.GetDepartment(postId);

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
        [Route("AddDepartment")]
        public async Task<IActionResult> AddPost([FromBody]Departments model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var postId = await departmentsRepository.AddDepartment(model);
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