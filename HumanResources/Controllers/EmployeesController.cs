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
    public class EmployeesController : ControllerBase
    {
        IEmployeesRepository EmployeesRepository;


        public EmployeesController(IEmployeesRepository _EmployeesRepository)
        {
            EmployeesRepository = _EmployeesRepository;
        }


        [HttpGet]
        [Route("GetEmployees")]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var posts = await EmployeesRepository.GetEmployees();
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
        [Route("GetEmployee")]
        public async Task<IActionResult> GetEmployee(int? postId)
        {
            if (postId == null)
            {
                return BadRequest();
            }

            try
            {
                var post = await EmployeesRepository.GetEmployee(postId);

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
        [Route("AddEmployee")]
        public async Task<IActionResult> AddPost([FromBody]Employees model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var postId = await EmployeesRepository.AddEmployee(model);
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