using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace Entities.DTOs
{
    public abstract class IEmployeeDto : EmployeeEntity
    {
        [System.Runtime.Serialization.DataMemberAttribute()]
        public abstract double AnnualSalary { get; }
    }
}
