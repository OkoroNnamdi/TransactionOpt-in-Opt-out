namespace TransactionOptin_OptoutAPI.DTOS
{
    public class CustomerDTO
    {
        public bool OptedIn { get; set; }
        public bool OptedOut { get; set; }
        public decimal MonitoringThreshold { get; set; }
    }
}
