namespace TransactionOptin_OptoutAPI.Model
{
    public class Transactions
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
        public bool IsQueued { get; set; } = false;
    }
}
