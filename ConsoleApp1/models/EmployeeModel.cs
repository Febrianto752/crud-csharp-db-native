using ConsoleApp1.database;
using ConsoleApp1.objects;
using System.Data.SqlClient;

namespace ConsoleApp1.models
{
    class EmployeeModel
    {
        public static List<Employee> FindAllEmployee()
        {
            SqlConnection connection = DB.Connection();
            List<Employee> employees = new List<Employee>();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_employees";

                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var employee = new Employee();
                        employee.Id = reader.GetInt32(0);
                        employee.FirstName = reader.GetString(1);
                        employee.LastName = reader.GetString(2);
                        employee.Email = reader.GetString(3);
                        employee.PhoneNumber = reader.GetString(4);
                        employee.HireDate = reader.GetDateTime(5);
                        employee.Salary = reader.GetInt32(6);
                        employee.comissionPct = reader.GetDecimal(7);
                        employee.IsManager = reader.IsDBNull(8) ? false : true;
                        employee.JobId = reader.GetString(9);
                        employee.DepartmentId = reader.GetInt32(10);

                        employees.Add(employee);
                    }
                }
                else
                {
                    Console.WriteLine("Data not found!");
                }

                reader.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine("something error");
                Console.WriteLine(ex.Message);
            }
            connection.Close();
            return employees;
        }
    }
}
