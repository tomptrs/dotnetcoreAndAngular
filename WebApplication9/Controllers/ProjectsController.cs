using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Queries;
using Data.Model;
using Business.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Business.Queries.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        IProjectQuery query;
        // IProjectQuery query;
        public ProjectsController(IProjectQuery _query)
        {
            query = _query;
        }
        /* [HttpGet]
         public IQueryable<Project> Get()
         {
             var result = query.Get();
             return Ok(result);
         }*/

        [HttpGet, Authorize(Roles = "Admin")]
        public IActionResult Get()
        {
            var projects = query.Get();
            return Ok(projects);
        }

    }
}