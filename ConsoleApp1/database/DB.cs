using System.Data.SqlClient;

namespace ConsoleApp1.database
{

    class DB
    {

        static string connectionString = "Data Source=FEBRIANTO-PC;Database=db_hr;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

        public static SqlConnection Connection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
