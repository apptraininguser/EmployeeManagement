using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebapiDemo.Repository;

namespace WebapiDemo.Controllers
{
    [Route("api")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        //GetAllEmployee()
        //api/employees
        [HttpGet]
        [Route("employees")]
        public IActionResult GetAll()
        {
            try
            {
                var employeeRepository = new EmployeeRepository();
                var employees = employeeRepository.GetAllEmployee();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //https://localhost:44333/api/employees/2
        [HttpGet]
        [Route("employees/{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            try
            {
                var employeeRepository = new EmployeeRepository();

                var employee = employeeRepository.GetEmployeeById(id);

                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        //https://localhost:44333/api/employees
        [HttpPost]
        [Route("employees")]
        public IActionResult PostEmployee([FromBody] Employee employee)
        {
            try
            {
                var employeeRepository = new EmployeeRepository();

                var result = employeeRepository.InsertEmployee(employee);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
