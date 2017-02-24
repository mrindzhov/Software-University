namespace IncreaseAgeStoredProcedure
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
            Console.Write("Increase age of minion with ID: ");
            int minionId = int.Parse(Console.ReadLine());
            //Uncomment to create procedure
            //string createProcSQL = @"CREATE PROC [dbo].[usp_GetOlder]
            //                        @Id int
            //                        AS
            //                        UPDATE Minions
            //                        SET Age=Age+1
            //                        WHERE Id=@Id
            //                        SELECT * FROM Minions WHERE Id=@Id";
            //SqlCommand createProc = new SqlCommand(createProcSQL, Connection);
            string increaseAgeByIdSQL = @"Exec [dbo].[usp_GetOlder] @Id";
            SqlCommand increaseAgeById = new SqlCommand(increaseAgeByIdSQL, Connection);
            increaseAgeById.Parameters.AddWithValue("@Id", minionId);
            Connection.Open();
            // createProc.ExecuteNonQuery();
            using (SqlDataReader reader = increaseAgeById.ExecuteReader())
            {

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        for (int i = 1; i < reader.FieldCount - 1; i++)
                        {
                            Console.Write($"{reader[i]} ");
                        }
                    }

                }
                else
                {
                    Console.WriteLine("No minion with current ID found.");
                }
            }
            Connection.Close();

        }

    }
}
