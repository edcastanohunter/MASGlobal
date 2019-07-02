using MasGlobal.Core.Entities;
using MasGlobal.Core.Interfaces;
using MasGlobal.Infrastructure.Entities;
using MasGlobal.Infrastructure.Processors;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasGlobal.Infrastructure.Data
{
    public class EmployeeRepository : IApiRepository<Employee>
    {
        private List<Employee> _employees = null;
        public async Task<Employee> GetById(int id)
        {

            if (_employees == null)
            {
                var apiEmployee = await EmployeeProcessor.LoadEmployees();
                _employees = ConvertApiListToDomain(apiEmployee);
            }

            var employee = _employees.Find(emp => emp.Id == id);
            // Employee
            return employee;
        }

        public async Task<List<Employee>> List()
        {
            _employees = new List<Employee>();
            // _employees

            var apiEmployee = await EmployeeProcessor.LoadEmployees();
            _employees = ConvertApiListToDomain(apiEmployee);

            return _employees;
        }

        private List<Employee> ConvertApiListToDomain(List<ApiEmployeeModel> apiEmployees)
        {
            var list = new List<Employee>();
            foreach (var item in apiEmployees)
            {
                // contractTypeName=
                switch (item.ContractTypeName)
                {
                    case "HourlySalaryEmployee":
                        var emp1 = new HourlyEmployee
                        {
                            Id = item.Id,
                            Name = item.Name,
                            RoleId = item.RoleId,
                            RoleDescription = item.RoleDescription,
                            RoleName = item.RoleName,
                            Salary = item.HourlySalary
                        };
                        
                        list.Add(emp1);
                        break;
                    case "MonthlySalaryEmployee":
                        var emp2 = new MontlyEmployee
                        {
                            Id = item.Id,
                            Name = item.Name,
                            RoleId = item.RoleId,
                            RoleDescription = item.RoleDescription,
                            RoleName = item.RoleName,
                            Salary = item.MonthlySalary
                        };
                        list.Add(emp2);
                        break;
                    default:
                        break;
                }
            }
            return list;
        }
    }
}