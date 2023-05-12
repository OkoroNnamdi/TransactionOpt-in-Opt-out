using TransactionOptin_OptoutAPI.DTOS;
using TransactionOptin_OptoutAPI.IRepository;
using TransactionOptin_OptoutAPI.Model;

namespace TransactionOptin_OptoutAPI.Repository
{
    public class TransactionRepository:ITransactionRepository 
    {
        private readonly ApplicationDbContext _context;
        public TransactionRepository(ApplicationDbContext context)
        {

            _context = context;

        }

        public async  Task CompleteTransaction(TransactionDTO transactiondto)
        {
            var newtransaction = new Transactions();
            newtransaction.Amount = transactiondto.Amount;
            newtransaction.IsQueued = false;
            _context.Transactions.Add(newtransaction);
            await _context.SaveChangesAsync();
            
        }

        public async  Task QueuedTransaction(TransactionDTO transactiondto)
        {
            var newtransaction = new Transactions();
            newtransaction.Amount = transactiondto.Amount;
            newtransaction.IsQueued = true;
            _context.Transactions.Add(newtransaction);
            await _context.SaveChangesAsync();
            
        }
    }
}
