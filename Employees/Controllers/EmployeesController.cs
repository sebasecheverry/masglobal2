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

namespace Employees.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            EmployeeFactory factory = new EmployeeFactory();
            var data = await ApiFactory.Instance.GetEmployees();
            string result = JsonConvert.SerializeObject(data.ToList());
            var employeeList = new List<IEmployeeDto>();
            foreach (EmployeeEntity employee in data)
            {
                employeeList.Add(factory.getEmployee(employee as EmployeeEntity));
            }

            foreach (IEmployeeDto employee in employeeList)
            {
                double test = employee.AnnualSalary;
            }

            result = JsonConvert.SerializeObject(employeeList);

            return new string[] { result };
            //return new string[] { "value1", "value2" };
        }

        // GET api/values/id
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
