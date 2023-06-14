using ConsoleApp1.database;
using ConsoleApp1.objects;
using System.Data.SqlClient;

namespace ConsoleApp1.models
{
    class DepartmentModel
    {
        public static List<Department> FindAllDepartment()
        {
            SqlConnection connection = DB.Connection();
            List<Department> departments = new List<Department>();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT d.id, d.name AS department_name, e.first_name + ' ' + e.last_name AS manager_name, l.street_address FROM tb_m_departments d JOIN tb_m_employees e ON d.manager_id = e.id JOIN tb_m_locations l ON d.location_id = l.id ";
                //command.CommandText = "SELECT * FROM tb_m_departments";

                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var department = new Department();
                        department.Id = reader.GetInt32(0);
                        department.Name = reader.IsDBNull(1) ? null : reader.GetString(1);
                        department.ManagerName = reader.IsDBNull(1) ? null : reader.GetString(2);
                        department.StreetAddress = reader.IsDBNull(1) ? null : reader.GetString(3);

                        //department.Id = reader.GetInt32(0);
                        //department.Name = reader.IsDBNull(1) ? null : reader.GetString(1);
                        //department.LocationId = reader.IsDBNull(1) ? null : reader.GetInt32(2);
                        //department.ManagerId = reader.IsDBNull(1) ? null : reader.GetInt32(3);

                        departments.Add(department);
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
            return departments;
        }
    }
}
