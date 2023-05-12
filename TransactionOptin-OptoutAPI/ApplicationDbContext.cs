using Microsoft.EntityFrameworkCore;
using TransactionOptin_OptoutAPI.Model;

namespace TransactionOptin_OptoutAPI
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)

        {

        }
        public DbSet<Customer > Customers { get; set; }
        public DbSet <Transactions > Transactions { get; set; }
    }
}
