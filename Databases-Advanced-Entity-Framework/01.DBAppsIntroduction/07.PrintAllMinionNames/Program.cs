namespace PrintAllMinionNames
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;

    class Program
    {
        public static SqlConnection Connection = new SqlConnection("Data Source=(local);Initial Catalog=MinionsDB;Integrated Security=True");

        static void Main(string[] args)
        {
            List<string> names = new List<string>();

            string selectMinionNamesSQL = @"select Id,Name from Minions";
            SqlCommand selectMinionNames = new SqlCommand(selectMinionNamesSQL, Connection);

            Connection.Open();

            using (SqlDataReader reader = selectMinionNames.ExecuteReader())
            {
                while (reader.Read())
                {
                    names.Add(reader["id"].ToString()+"->"+reader["name"].ToString());
                }
            }
            String[] minionNames = names.ToArray();
            for (int i = 0; i <= minionNames.Length / 2; i++)
            {
                if (i==minionNames.Length/2)
                {
                    Console.WriteLine(minionNames[i]);
                }
                else
                {
                    Console.WriteLine(minionNames[i]);
                    Console.WriteLine(minionNames[minionNames.Length - 1 - i]);
                }
            }
            Connection.Close();

        }

    }
}