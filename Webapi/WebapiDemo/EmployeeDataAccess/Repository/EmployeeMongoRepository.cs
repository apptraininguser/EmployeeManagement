using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeDataAccess.Repository
{
    public class EmployeeMongoRepository : IEmployeeRepository
    {
        public bool DeleteEmployee(int employeeId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return new List<Employee>()
            {
                new Employee
                {
                    Id =1,
                    Name = "Abin"
                }
            };
        }

        public Employee GetEmployeeById(int employeeId)
        {
            throw new NotImplementedException();
        }

        public bool InsertEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public bool UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
