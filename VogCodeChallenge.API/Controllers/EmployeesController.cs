using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VogCodeChallenge.Core.Interfaces;
using VogCodeChallenge.Core.Models;

namespace VogCodeChallenge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeManager _employeeManager;

        public EmployeesController(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }

        // GET api/employees
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> Get()
        {
            try
            {
                var employees = _employeeManager.ListAll();
                if (employees == null || !employees.Any())
                {
                    return NotFound("No record found");
                }
                return Ok(employees);
            }
            catch (Exception exception)
            {
                return NotFound(exception.Message);
            }
        }

        // GET api/employees/department/{departmentId}
        [HttpGet("department/{departmentId}")]
        public ActionResult<IEnumerable<Employee>> Get(int departmentId)
        {
            try
            {
                var employees = _employeeManager.GetAll().Where(p => p.Department.ID == departmentId);
                if (employees == null || !employees.Any())
                {
                    return NotFound($"Cannot find records for specified department {departmentId}");
                }
                return Ok(employees);
            }
            catch (Exception exception)
            {
                return NotFound(exception.Message);
            }
        }
    }
}
