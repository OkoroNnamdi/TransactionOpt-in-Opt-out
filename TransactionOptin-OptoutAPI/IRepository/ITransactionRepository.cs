using System.Transactions;
using TransactionOptin_OptoutAPI.DTOS;
using TransactionOptin_OptoutAPI.Model;


namespace TransactionOptin_OptoutAPI.IRepository
{
    public interface ITransactionRepository
    {
        Task CompleteTransaction(TransactionDTO transactiondto);
        Task QueuedTransaction(TransactionDTO transactiondto);
    }
}
