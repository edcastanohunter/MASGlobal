using MasGlobal.Core.Entities;
using MasGlobal.Core.Interfaces;
using MasGlobal.Web.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasGlobal.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private IApiRepository<Employee> _repository;

        public EmployeeController(IApiRepository<Employee> repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<EmployeeDTO> employeesDTO = new List<EmployeeDTO>();
            return View(employeesDTO);
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployee(string buscar)
        {
            int id = 0;
            IEnumerable<Employee> employees;
            List<EmployeeDTO> employeesDTO = new List<EmployeeDTO>();
            Int32.TryParse(buscar, out id);
            if (id == 0)
            {
                employees = await _repository.List();
            }
            else
            {
                var t = await _repository.GetById(id);
                if(t != null)
                {
                    employees = new List<Employee> { t };
                }
                else
                {
                    employees = await _repository.List();
                }
                
            }

            foreach (var item in employees)
            {
                var emp = new EmployeeDTO();
                emp.FromEmployee(item);
                employeesDTO.Add(emp);
            }
            return View("Index", employeesDTO);
        }
    }
}
