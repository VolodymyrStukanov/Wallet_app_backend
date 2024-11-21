using Microsoft.EntityFrameworkCore;
using WebApplication1.DB;
using WebApplication1.DB.Models;

namespace WebApplication1.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly AppDbContext _context;

        public TransactionService(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Transaction> GetTransactionsByAccountId(int accountId, int? count = null)
        {
            if(count != null)
            {
                return _context.Transactions
                    .Include(t => t.AuthorizedUser)
                    .Where(t => t.AccountId == accountId)
                    .OrderByDescending(t => t.Date)
                    .Take((int)count);
            }
            else
            {
                return _context.Transactions
                    .Include(t => t.AuthorizedUser)
                    .Where(t => t.AccountId == accountId)
                    .OrderByDescending(t => t.Date);
            }
        }
    }
}
