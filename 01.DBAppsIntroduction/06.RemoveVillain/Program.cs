namespace RemoveVillain
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    class Program
    {
        public static SqlConnection Connection = new SqlConnection("Data Source=(local);Initial Catalog=MinionsDB;Integrated Security=True");

        static void Main(string[] args)
        {
            Console.Write("Enter villain ID to remove: ");
            int villainId = int.Parse(Console.ReadLine());
            using (Connection)
            {
                Connection.Open();
                SqlTransaction delete = Connection.BeginTransaction();
                SqlCommand villains = new SqlCommand("SELECT Id, Name FROM villains WHERE Id = @villainId", Connection);
                villains.Parameters.AddWithValue("@villainId", villainId);

                SqlCommand deleteVillain = new SqlCommand("DELETE FROM Villains WHERE Id = @villainId", Connection);
                deleteVillain.Parameters.AddWithValue("@villainId", villainId);

                SqlCommand releaseMinions = new SqlCommand("DELETE FROM MinionsVillains WHERE VillainId = @villainId", Connection);
                releaseMinions.Parameters.AddWithValue("@villainId", villainId);

                villains.Transaction = delete;
                SqlDataReader reader = villains.ExecuteReader();
                try
                {
                    reader.Read();
                    var villainName = (string)reader["Name"];
                    reader.Close();

                    releaseMinions.Transaction = delete;
                    var releasedMinions = releaseMinions.ExecuteNonQuery();

                    deleteVillain.Transaction = delete;
                    deleteVillain.ExecuteNonQuery();

                    delete.Commit();
                    Console.WriteLine("{0} was deleted", villainName);
                    Console.WriteLine("{0} were released", releasedMinions);
                }
                catch (InvalidOperationException e)
                {
                    reader.Close();
                    delete.Rollback();
                    Console.WriteLine("No such villain was found");
                }
            }
        }
    }
}
