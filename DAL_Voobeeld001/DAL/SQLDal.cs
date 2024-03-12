using DAL_Voobeeld001.Model;
using System.Data.SqlClient;

namespace DAL_Voobeeld001.DAL
{
    internal class SQLDal
    {
        private readonly string connectionString = "Data Source=.;Initial Catalog=OpleidingsSysteem;Integrated Security=True";

        public SQLDal()
        {            
        }

        public void AddEmployee(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Employee (FirstName, LastName, Department) VALUES (@FirstName, @LastName, @Department)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    command.Parameters.AddWithValue("@LastName", employee.LastName);
                    command.Parameters.AddWithValue("@Department", employee.Department);
                    command.ExecuteNonQuery();

                    // Get employeeId form database!
                    command.CommandText = "SELECT CAST(@@Identity as INT);";
                    int addId = (int)command.ExecuteScalar();
                    employee.EmployeeId = addId;
                }
            }
        }

        public void DeleteEmployee(int employeeId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Employee WHERE EmployeeId = @EmployeeId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeId", employeeId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Employee";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Employee employee = MapEmployee(reader);
                            employees.Add(employee);
                        }
                    }
                }
                
            }
            return employees;
        }

        public Employee GetEmployeeById(int employeeId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Employee WHERE EmployeeId = @EmployeeId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeId", employeeId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapEmployee(reader);
                        }
                    }
                }
            }
            return null;
        }        

        public void UpdateEmployee(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE Employee SET FirstName = @FirstName, LastName = @LastName, Department = @Department WHERE EmployeeId = @EmployeeId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
                    command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    command.Parameters.AddWithValue("@LastName", employee.LastName);
                    command.Parameters.AddWithValue("@Department", employee.Department);

                    command.ExecuteNonQuery();
                }
            }
        }

        private Employee MapEmployee(SqlDataReader reader)
        {
            Employee e = new Employee(
                Convert.ToInt32(reader["EmployeeId"]),
                reader["FirstName"].ToString(),
                reader["LastName"].ToString(),
                reader["Department"].ToString());

            return e;
        }
    }
}

