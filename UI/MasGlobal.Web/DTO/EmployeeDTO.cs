using MasGlobal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasGlobal.Web.DTO
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContractType { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public decimal Salary { get; set; }
        public decimal AnnualSalary { get; set; }

        public void FromEmployee(Employee emp)
        {
            Id = emp.Id;
            Name = emp.Name;
            ContractType = emp.ContractType.ToString();
            RoleId = emp.RoleId;
            RoleName = emp.RoleName;
            RoleDescription = emp.RoleDescription;
            Salary = emp.Salary;
            AnnualSalary = emp.CalculatedAnnualSalary();
        }
    }
}
