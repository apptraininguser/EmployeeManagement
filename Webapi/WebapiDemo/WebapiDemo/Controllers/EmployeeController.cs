using EmployeeDataAccess.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

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
                ValidateEmployee(id);

                var employeeRepository = new EmployeeRepository();

                var employee = employeeRepository.GetEmployeeById(id);

                ValidateEmployee(employee);

                return Ok(employee);
            }
            catch (ArgumentNullException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
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

        //https://localhost:44333/api/employees
        [HttpPut]
        [Route("employees")]
        public IActionResult UpdateEmployee([FromBody] Employee employee)
        {
            try
            {
                var employeeRepository = new EmployeeRepository();
                var result = employeeRepository.UpdateEmployee(employee);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("employees/{id}")]
        public IActionResult DeleteEmployee([FromRoute] int id)
        {
            try
            {
                ValidateEmployee(id);

                var employeeRepository = new EmployeeRepository();

                var employee = employeeRepository.GetEmployeeById(id);

                ValidateEmployee(employee);

                var result = employeeRepository.DeleteEmployee(id);
                return Ok(result);
            }
            catch (ArgumentNullException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        private void ValidateEmployee(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("Invalid employee id");
            }
        }

        private void ValidateEmployee(Employee employee)
        {
            if(employee == null)
            {
                throw new ArgumentNullException("employee is not found");
            }
        }
    }
}
