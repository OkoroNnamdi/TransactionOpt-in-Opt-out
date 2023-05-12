using Microsoft.EntityFrameworkCore;
using TransactionOptin_OptoutAPI.DTOS;
using TransactionOptin_OptoutAPI.IRepository;
using TransactionOptin_OptoutAPI.Model;

namespace TransactionOptin_OptoutAPI.Repository
{
    public class CustomerRepository:ICustomerRepository
    {
        private readonly ApplicationDbContext _context;
        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async  Task<Customer> AddCustomer(CustomerDTO custmerdto)
        {
            var customer = new Customer();
            customer.OptedOut=custmerdto.OptedOut ;
            customer.OptedIn = custmerdto.OptedIn ;
            customer.MonitoringThreshold = custmerdto.MonitoringThreshold;
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return customer;
         
        }

        public Customer GetCustomerByID(int customerId)
        {
            return _context.Customers.FirstOrDefault(x => x.Id == customerId);
        }
    }
}
