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
namespace DataAccess.DataAccess
{
    public class EmployeeDataAccess
    {
        EmployeeFactory factory = new EmployeeFactory();

        public async Task<ActionResult<IEnumerable<IEmployeeDto>>> Get()
        {
            var data = await ApiFactory.Instance.GetEmployees();            
            var employeeList = new List<IEmployeeDto>();
            foreach (EmployeeEntity employee in data)
            {
                employeeList.Add(factory.getEmployee(employee as EmployeeEntity));
            }

            return employeeList;
                        
        }

        public async Task<ActionResult<IEmployeeDto>> Get(int id)
        {
            EmployeeEntity data = await ApiFactory.Instance.GetEmployee(id);

            if(data != null)
            {
                return factory.getEmployee(data);
            } else
            {
                return null;
            }

        }


    }
}
