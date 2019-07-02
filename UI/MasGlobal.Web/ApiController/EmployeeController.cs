using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasGlobal.Core.Entities;
using MasGlobal.Core.Interfaces;
using MasGlobal.Web.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MasGlobal.Web.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IApiRepository<Employee> _repository;

        public EmployeeController(IApiRepository<Employee> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Devuelve el empleado por su Id.
        /// </summary>
        /// <param name="id">El id del empleado</param>
        /// <returns>Employee JSON</returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<string>> GetByID(int id)
        {
            var result = "Employee not found";
            var employee = await _repository.GetById(id);
            if (employee != null)
            {
                var emp = new EmployeeDTO();
                emp.FromEmployee(employee);

                result = JsonConvert.SerializeObject(emp);
            }
            return result;
        }


        /// <summary>
        /// Devuelve todos loe empleados existentes
        /// </summary>
        /// 
        /// <returns>Employee List JSON</returns>
        [HttpGet]
        [Route("All")]
        public async Task<ActionResult<string>> GetEmployees(int id)
        {
            var result = "Employee not found";
            var employee = await _repository.GetById(id);
            if (employee != null)
            {
                var emp = new EmployeeDTO();
                emp.FromEmployee(employee);

                result = JsonConvert.SerializeObject(emp);
            }
            return result;
        }

    }
}
