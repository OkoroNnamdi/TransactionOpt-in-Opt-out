namespace TransactionOptin_OptoutAPI.DTOS
{
    public class TransactionDTO
    {
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
        public bool IsQueued { get; set; }
    }
}
