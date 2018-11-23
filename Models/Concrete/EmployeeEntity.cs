using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Models
{
    [DataContract]
    public class EmployeeEntity
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "contractTypeName")]
        public string ContractTypeName { get; set; }

        [DataMember(Name = "roleId")]
        public int RoleId { get; set; }

        [DataMember(Name = "roleName")]
        public string RoleName { get; set; }

        [DataMember(Name = "roleDescription")]
        public string RoleDescription { get; set; }

        [DataMember(Name = "hourlySalary")]
        public double HourlySalary { get; set; }

        [DataMember(Name = "monthlySalary")]
        public double MonthlySalary { get; set; }

    }
}
