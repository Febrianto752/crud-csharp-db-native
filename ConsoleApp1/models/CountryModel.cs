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

        public static Country FindCountry(string id)
        {
            SqlConnection connection = DB.Connection();
            connection.Open();
            Country country = new Country();

            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "SELECT c.id, c.name AS country_name, r.name AS country_region FROM tb_m_countries c JOIN tb_m_regions r ON c.region_id = r.id  WHERE c.id = (@country_id)";

                // membuat parameter
                SqlParameter pCountryId = new SqlParameter();
                pCountryId.ParameterName = "@country_id";
                pCountryId.Value = id;
                pCountryId.SqlDbType = SqlDbType.Char;

                // menambahkan parameter ke command
                command.Parameters.Add(pCountryId);

                // Menalankan command
                using SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        country.Id = reader.GetString(0);
                        country.Name = reader.GetString(1);
                        country.RegionName = reader.GetString(2);
                    }
                }

                reader.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine("something error");
                Console.WriteLine(ex.Message);
            }
            connection.Close();
            return country;
        }

        public static int Create(string id, string name, int regionId)
        {
            int result = 0;
            SqlConnection connection = DB.Connection();
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO tb_m_countries (id, name, region_id) VALUES ((@country_id) , (@country_name) , (@region_id))";
                //command.CommandText = $"INSERT INTO tb_m_countries (id, name, region_id) VALUES ('{id}', '{name}', {regionId})";
                command.Transaction = transaction;

                // membuat parameter
                SqlParameter pCountryId = new SqlParameter();
                pCountryId.ParameterName = "@country_id";
                pCountryId.Value = id;
                pCountryId.SqlDbType = SqlDbType.VarChar;

                // menambahkan parameter ke command
                command.Parameters.Add(pCountryId);

                // membuat parameter
                SqlParameter pCountryName = new SqlParameter();
                pCountryName.ParameterName = "@country_name";
                pCountryName.Value = name;
                pCountryName.SqlDbType = SqlDbType.VarChar;

                // menambahkan parameter ke command
                command.Parameters.Add(pCountryName);

                // membuat parameter
                SqlParameter pRegionIdCountry = new SqlParameter();
                pRegionIdCountry.ParameterName = "@region_id";
                pRegionIdCountry.Value = regionId;
                pRegionIdCountry.SqlDbType = SqlDbType.Int;

                // menambahkan parameter ke command
                command.Parameters.Add(pRegionIdCountry);

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
