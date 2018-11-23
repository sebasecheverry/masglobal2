using Entities.DTOs;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Factories
{
    public class EmployeeFactory : IEmployeeFactory
    {
        public override IEmployeeDto getEmployee(EmployeeEntity employee)
        {
            switch (employee.ContractTypeName)
            {
                case "HourlySalaryEmployee":
                    return new EmployeeDtoHourly(employee);
                    break;
                case "MonthlySalaryEmployee":
                    return new EmployeeDtoMonthly(employee);
                    break;
                default:
                    return new EmployeeDtoHourly(employee);
                    break;
            }            
        }
    }
}
