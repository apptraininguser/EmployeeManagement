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
            _sqlConnection = new SqlConnection("data source= (localdb)\\mssqllocaldb; database= Training2022Dbfgg;");
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
    }
}
