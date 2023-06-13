using ConsoleApp1.database;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp1.models
{
    class CountryModel
    {
        public static List<Country> FindAllCountry()
        {
            SqlConnection connection = DB.Connection();
            List<Country> countries = new List<Country>();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT c.id, c.name AS country_name, r.name AS country_region FROM tb_m_countries c JOIN tb_m_regions r ON c.region_id = r.id";

                connection.Open();

                using SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var country = new Country();
                        country.Id = reader.GetString(0);
                        country.Name = reader.GetString(1);
                        country.RegionName = reader.GetString(2);

                        countries.Add(country);
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
            return countries;
        }

        public static Region FindOneRegion(int id)
        {
            SqlConnection connection = DB.Connection();
            connection.Open();
            Region region = new Region();

            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tb_m_regions WHERE id = (@region_id)";

                // membuat parameter
                SqlParameter pRegionId = new SqlParameter();
                pRegionId.ParameterName = "@region_id";
                pRegionId.Value = id;
                pRegionId.SqlDbType = SqlDbType.Int;

                // menambahkan parameter ke command
                command.Parameters.Add(pRegionId);

                // Menalankan command
                using SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        region.Id = reader.GetInt32(0);
                        region.Name = reader.GetString(1);
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
            return region;
        }

        public static int Create(string name)
        {
            int result = 0;
            SqlConnection connection = DB.Connection();
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO tb_m_regions VALUES ((@region_name))";
                command.Transaction = transaction;

                // membuat parameter
                SqlParameter pRegionName = new SqlParameter();
                pRegionName.ParameterName = "@region_name";
                pRegionName.Value = name;
                pRegionName.SqlDbType = SqlDbType.VarChar;

                // menambahkan parameter ke command
                command.Parameters.Add(pRegionName);

                // Menalankan command
                result = command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                try
                {
                    transaction.Rollback();
                    return 0;
                }
                catch (Exception rollback)
                {
                    Console.WriteLine(rollback.Message);
                    return 0;
                }
            }

            connection.Close();
            return result;
        }

        public static int Update(int id, string name)
        {
            int result = 0;
            SqlConnection connection = DB.Connection();
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Update tb_m_regions set name=(@region_name) WHERE id=(@region_id)";
                command.Transaction = transaction;

                // membuat parameter
                SqlParameter pRegionName = new SqlParameter();
                pRegionName.ParameterName = "@region_name";
                pRegionName.Value = name;
                pRegionName.SqlDbType = SqlDbType.VarChar;

                // menambahkan parameter ke command
                command.Parameters.Add(pRegionName);

                // membuat parameter
                SqlParameter pRegionId = new SqlParameter();
                pRegionId.ParameterName = "@region_id";
                pRegionId.Value = id;
                pRegionId.SqlDbType = SqlDbType.Int;

                // menambahkan parameter ke command
                command.Parameters.Add(pRegionId);

                // Menalankan command
                result = command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                try
                {
                    transaction.Rollback();
                    return 0;
                }
                catch (Exception rollback)
                {
                    Console.WriteLine(rollback.Message);
                    return 0;
                }
            }

            connection.Close();
            return result;
        }

        public static int Delete(int id)
        {
            int result = 0;
            SqlConnection connection = DB.Connection();
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Delete FROM tb_m_regions WHERE id=(@region_id)";
                command.Transaction = transaction;

                // membuat parameter
                SqlParameter pRegionName = new SqlParameter();
                pRegionName.ParameterName = "@region_id";
                pRegionName.Value = id;
                pRegionName.SqlDbType = SqlDbType.Int;

                // menambahkan parameter ke command
                command.Parameters.Add(pRegionName);

                // Menalankan command
                result = command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                try
                {
                    transaction.Rollback();
                    return 0;
                }
                catch (Exception rollback)
                {
                    Console.WriteLine(rollback.Message);
                    return 0;
                }
            }

            connection.Close();
            return result;
        }
    }
}
