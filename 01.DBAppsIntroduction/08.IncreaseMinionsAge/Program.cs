namespace IncreaseMinionsAge
{
    using System;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;

    class Program
    {
        public static SqlConnection Connection = new SqlConnection("Data Source=(local);Initial Catalog=MinionsDB;Integrated Security=True");

        static void Main(string[] args)
        {
            using (Connection)
            {
                Connection.Open();
                Console.Write("Enter minion Ids: ");
                var readLine = Console.ReadLine();
                if (readLine != null)
                {
                    int[] ids = readLine.Split(' ').Select(int.Parse).ToArray();
                    var updateCommandString = GetBuildCommand(ids);

                    SqlCommand updateCommand = new SqlCommand(updateCommandString.ToString(), Connection);
                    for (int i = 0; i < ids.Length; i++)
                    {
                        updateCommand.Parameters.AddWithValue(@"minionId" + i, ids[i]);
                    }

                    updateCommand.ExecuteNonQuery();
                }

                SqlCommand selectCommand = new SqlCommand("SELECT * FROM Minions", Connection);
                SqlDataReader minionsReader = selectCommand.ExecuteReader();
             //  Console.WriteLine($"{"ID",-9}|{"Name",-9}|{"Age",-9}|{"TownID",-9}");

                while (minionsReader.Read())
                {
                    for (int i = 0; i < minionsReader.FieldCount-1; i++)
                    {
                        Console.Write($"{minionsReader[i]}  ");
                    }
                    Console.WriteLine();
                }
            }
        }

        private static StringBuilder GetBuildCommand(int[] ids)
        {
            StringBuilder commandBuilder = new StringBuilder();
            for (int i = 0; i < ids.Length; i++)
            {
                commandBuilder.AppendLine("UPDATE Minions " +
                                          "SET Age = Age + 1, Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)) " +
                                          "WHERE ID = @minionId" + i);
                commandBuilder.AppendLine();
            }
            return commandBuilder;
        }
    }
}
