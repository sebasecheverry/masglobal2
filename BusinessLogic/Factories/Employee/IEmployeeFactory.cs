using Entities.DTOs;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Factories
{
    public abstract class IEmployeeFactory
    {
        public abstract IEmployeeDto getEmployee(EmployeeEntity employee);
    }
}
