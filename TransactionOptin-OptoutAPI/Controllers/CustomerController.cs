using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransactionOptin_OptoutAPI.DTOS;
using TransactionOptin_OptoutAPI.IRepository;

namespace TransactionOptin_OptoutAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        [HttpPost("AddCustomer")]
        public async Task<IActionResult> AddCustomer(CustomerDTO customer)
        {
            var result = await _customerRepository.AddCustomer(customer);
            return Ok(result);
        }
    }
}
