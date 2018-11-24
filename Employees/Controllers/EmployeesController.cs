using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employees.Factory;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using BusinessLogic.Factories;
using Models;
using BusinessLogic;
using Entities.DTOs;
using DataAccess.DataAccess;
using Microsoft.AspNetCore.Cors;

namespace Employees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [DisableCors]
    public class EmployeesController : ControllerBase
    {
        EmployeeDataAccess dataAccess = new EmployeeDataAccess();
        JsonSerializerSettings settings = new JsonSerializerSettings();

        // GET api/employees
        [HttpGet]
        [DisableCors]
        public async Task<ActionResult<IEnumerable<IEmployeeDto>>> Get()
        {
            var data = await dataAccess.Get();                                    
            return data;
        }

        // GET api/employees/id
        [HttpGet("{id}")]
        [DisableCors]
        public async Task<ActionResult<IEnumerable<IEmployeeDto>>> Get(int id)
        {
            var data = await dataAccess.Get(id);
            return data;
        }
    }
}
