using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace Entities.DTOs
{
    public class EmployeeDtoMonthly : IEmployeeDto
    {
        public EmployeeDtoMonthly(EmployeeEntity employee)
        {
            Id = employee.Id;
            Name = employee.Name;
            ContractTypeName = employee.ContractTypeName;
            RoleId = employee.RoleId;
            RoleName = employee.RoleName;
            RoleDescription = employee.RoleDescription;
            RoleDescription = employee.RoleDescription;
            HourlySalary = employee.HourlySalary;
            MonthlySalary = employee.MonthlySalary;
        }

        public override double AnnualSalary
        {
            get { return MonthlySalary * 12; }
        }
    }
}
