namespace TransactionOptin_OptoutAPI.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public bool OptedIn { get; set; }=false;
        public bool OptedOut { get; set; } = false;
        public decimal MonitoringThreshold { get; set; }
    }
}
