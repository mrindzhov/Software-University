namespace Models
{
    public class BankAccount
    {
        public int Id { get; set; }

        public string AccountNumber { get; set; }

        public decimal Balance { get; set; }

        public virtual Customer Customer { get; set; }

    }
}
