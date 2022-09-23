using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeDataAccess.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployee();
        Employee GetEmployeeById(int employeeId);
        bool InsertEmployee(Employee employee);
        bool UpdateEmployee(Employee employee);
        bool DeleteEmployee(int employeeId);
    }
}
