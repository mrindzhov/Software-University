using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GringottsDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new GringottsContext();
            StringBuilder content = new StringBuilder();
            #region//First Letter
            //var uniqueFirstLetterGringotts = context.WizzardDeposits
            //.Where(d => d.DepositGroup == "Troll Chest")
            //.Select(d => d.FirstName.Substring(0, 1))
            //.Distinct()
            //.OrderBy(d => d);
            //foreach (var letters in uniqueFirstLetterGringotts)
            //{
            //    content.AppendLine($"{letters}");
            //}
            #endregion

            Console.WriteLine(content);
        }
    }
}
