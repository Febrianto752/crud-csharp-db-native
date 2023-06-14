using ConsoleApp1.database;
using ConsoleApp1.objects;
using System.Data.SqlClient;

namespace ConsoleApp1.models
{
    class HistoryModel
    {
        public static List<History> FindAllHistory()
        {
            SqlConnection connection = DB.Connection();
            List<History> histories = new List<History>();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_tr_histories";

                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var history = new History();
                        history.StartDate = reader.GetDateTime(0);
                        history.EmployeeId = reader.GetInt32(1);
                        history.EndDate = reader.IsDBNull(2) ? null : reader.GetDateTime(2);
                        history.DepartMentId = reader.GetInt32(3);
                        history.JobId = reader.GetString(4);

                        histories.Add(history);
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
            return histories;
        }
    }
}
