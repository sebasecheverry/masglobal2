using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace Entities.DTOs
{
    public abstract class IEmployeeDto : EmployeeEntity
    {                   
        public abstract double AnnualSalary { get; }
    }
}
