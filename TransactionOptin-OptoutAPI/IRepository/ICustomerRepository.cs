using TransactionOptin_OptoutAPI.DTOS;
using TransactionOptin_OptoutAPI.Model;

namespace TransactionOptin_OptoutAPI.IRepository
{
    public interface ICustomerRepository
    {// Defines the Interfaces contracts
        Customer GetCustomerByID(int Id);
        Task<Customer> AddCustomer(CustomerDTO custmerdto);
    }
}
