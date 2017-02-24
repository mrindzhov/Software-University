
namespace ChangeTownNamesCasing
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    class Program
    {
        public static SqlConnection Connection = new SqlConnection("Data Source=(local);Initial Catalog=MinionsDB;Integrated Security=True");

        static void Main(string[] args)
        {
            Console.Write("Enter country to update its towns: ");

            string countryName = Console.ReadLine();
            string updateTownsSQL = @"UPDATE towns
                                set Name = UPPER(Name)
                                where Country = @countryName";
            SqlCommand updateTowns = new SqlCommand(updateTownsSQL, Connection);
            updateTowns.Parameters.AddWithValue("@countryName", countryName);
            Connection.Open();
            int updatedTowns = updateTowns.ExecuteNonQuery();
            if (updatedTowns != 0)
            {
                if (updatedTowns != 1)
                {
                    Console.WriteLine($"{updatedTowns} town name was affected.");
                }
                else
                {
                    Console.WriteLine($"{updatedTowns} town names were affected.");
                }
            }
            else
            {
                Console.WriteLine("No town names were affected.");
                return;
            }
            string selectTownsSQL = @"select Name from Towns where Country=@countryName";
            SqlCommand selectTowns = new SqlCommand(selectTownsSQL, Connection);
            selectTowns.Parameters.AddWithValue("@countryName", countryName);
            using (SqlDataReader reader = selectTowns.ExecuteReader())
            {
                List<string> towns = new List<string>();
                while (reader.Read())
                {
                    towns.Add((string)reader["name"]);
                }
                Console.WriteLine("[{0}]", string.Join(", ", towns));
            }
            Connection.Close();

        }
    }
}