using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDataAccess.Repository
{
    public class EmployeeRepositoryV2 : IEmployeeRepository
    {
        private SqlConnection _sqlConnection;

        public EmployeeRepositoryV2(string connectionString)
        {
            _sqlConnection = new SqlConnection(connectionString);
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            try
            {
                _sqlConnection.Open();

                var sqlCommand = new SqlCommand(cmdText: "select * from Employee",
                    _sqlConnection);

                var sqlDataReader = sqlCommand.ExecuteReader();

                var listOfEmployee = new List<Employee>();

                while (sqlDataReader.Read())
                {
                    listOfEmployee.Add(new Employee()
                    {
                        Id = (int)sqlDataReader["Id"],
                        Name = (string)sqlDataReader["Name"],
                        Age = (int)sqlDataReader["Age"],
                        Salary = (int)sqlDataReader["Salary"]
                    });
                }
                return listOfEmployee;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }

        public Employee GetEmployeeById(int employeeId)
        {
            try
            {
                _sqlConnection.Open();

                var sqlCommand = new SqlCommand(cmdText: "select * from Employee where Id = @id", _sqlConnection);
                sqlCommand.Parameters.AddWithValue("id", employeeId);

                var sqlDataReader = sqlCommand.ExecuteReader();

                Employee employee = null;

                while (sqlDataReader.Read())
                {
                    employee = new Employee();

                    employee.Id = (int)sqlDataReader["Id"];
                    employee.Name = (string)sqlDataReader["Name"];
                    employee.Age = (int)sqlDataReader["Age"];
                    employee.Salary = (int)sqlDataReader["Salary"];
                }

                return employee;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }

        public bool InsertEmployee(Employee employee)
        {
            try
            {
                _sqlConnection.Open();

                var sqlCommand = new SqlCommand(cmdText: "INSERT INTO Employee(Name, Age, Salary, CreationDate) VALUES (@name, @age, @salary, @creationDate)", _sqlConnection);

                sqlCommand.Parameters.AddWithValue("name", employee.Name);
                sqlCommand.Parameters.AddWithValue("age", employee.Age);
                sqlCommand.Parameters.AddWithValue("salary", employee.Salary);
                sqlCommand.Parameters.AddWithValue("creationDate", DateTime.Now);

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }

        public bool UpdateEmployee(Employee employee)
        {
            try
            {
                _sqlConnection.Open();

                var sqlCommand = new SqlCommand(cmdText: "Update Employee set Name = @name, Age = @age, Salary = @salary, ModificationDate = @modification where Id = @id", _sqlConnection);

                sqlCommand.Parameters.AddWithValue("id", employee.Id);
                sqlCommand.Parameters.AddWithValue("name", employee.Name);
                sqlCommand.Parameters.AddWithValue("age", employee.Age);
                sqlCommand.Parameters.AddWithValue("salary", employee.Salary);
                sqlCommand.Parameters.AddWithValue("modification", DateTime.Now);

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }

        public bool DeleteEmployee(int employeeId)
        {
            try
            {
                _sqlConnection.Open();

                var sqlCommand = new SqlCommand(cmdText: "delete from Employee where Id = @id", _sqlConnection);
                sqlCommand.Parameters.AddWithValue("id", employeeId);

                sqlCommand.ExecuteNonQuery();
                return true;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }
    }
}
