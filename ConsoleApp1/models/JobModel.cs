using ConsoleApp1.database;
using ConsoleApp1.objects;
using System.Data.SqlClient;

namespace ConsoleApp1.models
{
    class JobModel
    {
        public static List<Job> FindAllJob()
        {
            SqlConnection connection = DB.Connection();
            List<Job> jobs = new List<Job>();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_jobs";

                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var job = new Job();
                        job.Id = reader.GetString(0);
                        job.Title = reader.GetString(1);
                        job.MinSalary = reader.GetInt32(2);
                        job.MaxSalary = reader.GetInt32(3);

                        jobs.Add(job);
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
            return jobs;
        }
    }
}
