using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebapiDemo.Repository
{
    public class EmployeeRepository
    {
        private SqlConnection _sqlConnection;

        public EmployeeRepository()
        {
            _sqlConnection = new SqlConnection("data source= (localdb)\\mssqllocaldb; database= Training2022Db;");
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
            catch (Exception ex)
            {
                throw;
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

                var employee = new Employee();

                while (sqlDataReader.Read())
                {
                    employee.Id = (int)sqlDataReader["Id"];
                    employee.Name = (string)sqlDataReader["Name"];
                    employee.Age = (int)sqlDataReader["Age"];
                    employee.Salary = (int)sqlDataReader["Salary"];
                }

                return employee;
            }
            catch (Exception)
            {

                throw;
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
    }
}
