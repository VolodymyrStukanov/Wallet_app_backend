using WebApplication1.DB.Models;

namespace WebApplication1.Services
{
    public interface IAccountService
    {
        public Account? GetAccountById(int id);
        public Account? GetAccountByIdIncludingTransactions(int id);
    }
}
