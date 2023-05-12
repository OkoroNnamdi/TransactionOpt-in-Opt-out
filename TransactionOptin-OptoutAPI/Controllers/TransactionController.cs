using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;
using TransactionOptin_OptoutAPI.DTOS;
using TransactionOptin_OptoutAPI.IRepository;
using TransactionOptin_OptoutAPI.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TransactionOptin_OptoutAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly ICustomerRepository _customerRepository;
        public TransactionController(ICustomerRepository customerRepository,ITransactionRepository  transactionRepository)
        {//Inject the dependencies
            _customerRepository = customerRepository;
            _transactionRepository = transactionRepository;
        }
        [HttpPost ]
        public async Task<IActionResult > InitiateTransaction(TransactionDTO transactionDTO)
        {
            // Get the customer Id
            var customer = _customerRepository.GetCustomerByID(transactionDTO.CustomerId );
            //check whether the customer ids Optin or not
            if(customer.OptedOut ==true||transactionDTO.Amount <= customer.MonitoringThreshold)
            {
                // Transaction can be completed immediately
                await _transactionRepository.CompleteTransaction(transactionDTO);
                return Ok("Transaction completed.");
            }
            else if(customer.OptedIn ==true  && transactionDTO.Amount > customer.MonitoringThreshold) 
            {
                // Transaction needs to be queued
                await _transactionRepository.QueuedTransaction(transactionDTO);
                return Ok("Transaction queued for monitoring.");
            }
            else
            {
                return BadRequest("Invalid transaction");
            }
        }
    }
}
