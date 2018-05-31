﻿namespace BankSystem.Data.Models
{
    using System.Collections.Generic;

    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public virtual ICollection<SavingAccount> SavingAccounts { get; set; }

        public virtual ICollection<CheckingAccount> CheckingAccounts { get; set; }
    }
}