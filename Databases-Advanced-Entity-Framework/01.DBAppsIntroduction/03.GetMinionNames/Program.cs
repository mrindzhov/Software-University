namespace GetMinionNames
{
    using System;
    using System.Data;
    using System.Data.SqlClient;

    class Program
    {
        public static SqlConnection Connection = new SqlConnection("Data Source=(local);Initial Catalog=MinionsDB;Integrated Security=True");
        static void Main(string[] args)
        {
            Console.Write("Enter Villain Id: ");
            int villainId = int.Parse(Console.ReadLine());
            string villainNameQuery = "SELECT Name FROM Villains WHERE id = @villainId";
            SqlCommand getVillainName = new SqlCommand(villainNameQuery, Connection);
            getVillainName.Parameters.AddWithValue("@villainId", villainId);
            Connection.Open();
            using (SqlDataReader reader = getVillainName.ExecuteReader(CommandBehavior.SingleResult))
            {
                if (!reader.HasRows)
                {
                    Console.WriteLine("No villain with ID " + villainId + " exists in the database.");
                    return;
                }

                reader.Read();
                string villainName = reader[0].ToString();
                Console.WriteLine();

                Console.WriteLine($"Villain: {villainName}");
                Console.WriteLine();

            }
            Connection.Close();

            string villainMinionsQuery = @"select m.name, age
                FROM Villains v
                JOIN MinionsVillains mv ON v.Id = mv.VillainId
                JOIN Minions m ON m.id = mv.MinionId
            WHERE v.Id = @villainId";
            SqlCommand getVillainMinions = new SqlCommand(villainMinionsQuery, Connection);
            getVillainMinions.Parameters.AddWithValue("@villainId", villainId);
            Connection.Open();
            using (SqlDataReader reader = getVillainMinions.ExecuteReader())
            {
                if (!reader.HasRows)
                {
                    Console.WriteLine("<no minions>");
                    return;
                }
                int counter = 1;
                Console.WriteLine("  |MinionName|Age");
                Console.WriteLine("--+----------+---");

                while (reader.Read())
                {
                    Console.WriteLine($"{counter,-2}|{reader["name"],-10}|{reader["age"],-3}");
                    counter++;
                }
            }
            Connection.Close();

        }
    }
}
