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

namespace Employees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        EmployeeDataAccess dataAccess = new EmployeeDataAccess();
        JsonSerializerSettings settings = new JsonSerializerSettings();

        // GET api/employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            var data = await dataAccess.Get();            
            settings.CheckAdditionalContent = true;
            var hola = JsonConvert.SerializeObject(data.Value, Formatting.Indented);
            
            return new string[] { hola };
        }

        // GET api/employees/id
        [HttpGet("{id}")]
        public async Task<ActionResult<string>> Get(int id)
        {
            var data = await dataAccess.Get(id);

            return "value";
        }
    }
}
