
using WebApplication1.DB.Models;

namespace WebApplication1.Services
{
    public interface ITransactionService
    {
        public IQueryable<Transaction> GetTransactionsByAccountId(int userId, int? count = null);
    }
}
