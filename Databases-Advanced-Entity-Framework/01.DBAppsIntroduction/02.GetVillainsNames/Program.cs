using System.Data.SqlClient;


namespace GetVillainsNames
{
    class Program
    {
        public static SqlConnection Connection = new SqlConnection("Data Source=(local);Initial Catalog=MinionsDB;Integrated Security=True");

        static void Main(string[] args)
        {
            SqlCommand cmd = new SqlCommand(@"SELECT v.Name, COUNT(MinionId) AS c
                    FROM Villains v
                    JOIN MinionsVillains mv ON v.Id = mv.VillainId
                    GROUP BY v.Name
                    HAVING COUNT(MinionId) > 3
                    ORDER BY c DESC",Connection);

            Connection.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                System.Console.WriteLine("Name      |Minions Count");
                System.Console.WriteLine("----------+-------------");
                while (reader.Read())
                {
                    System.Console.WriteLine($"{reader[0],-10}|{reader[1],-10}");
                }
            }
        }
    }
}
