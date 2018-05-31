
namespace AddMinion
{
    using System;
    using System.Data.SqlClient;

    class Program
    {
        public static SqlConnection Connection = new SqlConnection("Data Source=(local);Initial Catalog=MinionsDB;Integrated Security=True");

        static void Main(string[] args)
        {
            Console.Write("Add Minion (name-age-town): ");
            var readLine = Console.ReadLine().Split();
            string[] minionTokens = readLine;
            string minionName = minionTokens[0];
            int minionAge = int.Parse(minionTokens[1]);
            string minionTown = minionTokens[2];
            Console.Write("Enter Villain Name: ");
            string villainName = Console.ReadLine();

            string townSQL = "SELECT Id FROM towns WHERE name = @townName";
            SqlCommand cmd = new SqlCommand(townSQL, Connection);
            cmd.Parameters.AddWithValue("@townName", minionTown);
            Connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.HasRows)
            {
                //add town
                reader.Close();
                string addTownSQL = "INSERT INTO towns (name, country) VALUES (@townName, NULL)";
                SqlCommand addTown = new SqlCommand(addTownSQL, Connection);
                addTown.Parameters.AddWithValue("@townName", minionTown);
                addTown.ExecuteNonQuery();
                Console.WriteLine($"Town {minionTown} was added to the database.");
            }
            reader.Close();

            int townId = (int)cmd.ExecuteScalar();

            string villainSQL = "SELECT * FROM villains WHERE name = @villainName";
            SqlCommand getVillain = new SqlCommand(villainSQL, Connection);
            getVillain.Parameters.AddWithValue("@villainName", villainName);
            reader = getVillain.ExecuteReader();
            if (!reader.HasRows)
            {
                //add villain
                reader.Close();
                string addVillainSQL = "INSERT INTO villains (name, EvilnessFactor) VALUES (@villainName, 'evil')";
                SqlCommand addTown = new SqlCommand(addVillainSQL, Connection);
                addTown.Parameters.AddWithValue("@villainName", villainName);
                addTown.ExecuteNonQuery();
                Console.WriteLine($"Villain {villainName} was added to the database.");
            }
            reader.Close();
            int villainId = (int)getVillain.ExecuteScalar();
            //add minion

            string addMinionSQL = "INSERT INTO minions (Name, Age, TownId) VALUES (@name, @age, @townId)";
            SqlCommand addMinion = new SqlCommand(addMinionSQL, Connection);
            addMinion.Parameters.AddWithValue("@name", minionName);
            addMinion.Parameters.AddWithValue("@age", minionAge);
            addMinion.Parameters.AddWithValue("@townId", townId);
            addMinion.ExecuteNonQuery();
            //Console.WriteLine($"Minion {minionName} was added to the database.");

            //get minionId
            string getMinionIdSQL = "SELECT id FROM minions where name = @minionName";
            SqlCommand getMinionId = new SqlCommand(getMinionIdSQL, Connection);
            getMinionId.Parameters.AddWithValue("@minionName", minionName);
            int minionId = (int)getMinionId.ExecuteScalar();
            //add to table
            string addMinionToVillainSQL = "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@minionId, @villainId)";
            SqlCommand addMinionToVillain = new SqlCommand(addMinionToVillainSQL, Connection);
            addMinionToVillain.Parameters.AddWithValue("@minionId", minionId);
            addMinionToVillain.Parameters.AddWithValue("@villainId", villainId);
            addMinionToVillain.ExecuteNonQuery();
            Console.WriteLine($"Successfuly added {minionName} to be minion of {villainName}");
        }
    }
}