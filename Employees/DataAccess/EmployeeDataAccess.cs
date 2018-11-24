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
            var employees = await ApiFactory.Instance.GetEmployees();            
            var employeeList = new List<IEmployeeDto>();
            foreach (EmployeeEntity employee in employees)
            {
                employeeList.Add(factory.getEmployee(employee as EmployeeEntity));
            }

            return employeeList;
                        
        }

        public async Task<ActionResult<IEnumerable<IEmployeeDto>>> Get(int id)
        {
            var employees = await ApiFactory.Instance.GetEmployees();
            var item = employees.FirstOrDefault(employee => employee.Id == id);
            var employeeList = new List<IEmployeeDto>();
            if (item != null)
            {
                employeeList.Add(factory.getEmployee(item as EmployeeEntity));
                return employeeList;
            } else
            {
                return null;
            }

        }


    }
}
