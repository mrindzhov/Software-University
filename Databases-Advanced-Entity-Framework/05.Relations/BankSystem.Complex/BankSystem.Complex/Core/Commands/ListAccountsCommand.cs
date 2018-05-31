﻿namespace BankSystem.Core.Commands
{
    using System;
    using System.Text;

    using Data;
    using Data.Models;

    /// <summary>
    /// List all accounts information on currently logged in user.
    /// </summary>
    public class ListAccountsCommand
    {
        public string Execute(string[] input)
        {
            if (input.Length != 0)
            {
                throw new ArgumentException("Input is not valid!");
            }

            if (!AuthenticationManager.IsAuthenticated())
            {
                throw new InvalidOperationException("You should log in first!");
            }

            StringBuilder builder = new StringBuilder();
            using (BankSystemContext context = new BankSystemContext())
            {
                User user = context.Users.Attach(AuthenticationManager.GetCurrentUser());

                builder.AppendLine("Saving Accounts:");
                foreach (SavingAccount userSavingAccount in user.SavingAccounts)
                {
                    builder.AppendLine($"--{userSavingAccount.AccountNumber} {userSavingAccount.Balance}");
                }

                builder.AppendLine("Checking Accounts:");
                foreach (CheckingAccount checkingAccount in user.CheckingAccounts)
                {
                    builder.AppendLine($"--{checkingAccount.AccountNumber} {checkingAccount.Balance}");
                }
            }

            return builder.ToString().Trim();
        }
    }
}
