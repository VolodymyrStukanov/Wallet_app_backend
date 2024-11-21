using Microsoft.EntityFrameworkCore;
using WebApplication1.DB;
using WebApplication1.DB.Models;

namespace WebApplication1.Services
{
    public class AccountService : IAccountService
    {
        private readonly AppDbContext _context;
        public AccountService(AppDbContext context)
        {
            _context = context;
        }

        public Account? GetAccountById(int id) => _context.Accounts
            .Include(x => x.User)
            .FirstOrDefault(x => x.Id == id);

        public Account? GetAccountByIdIncludingTransactions(int id) => _context.Accounts
            .Include(x => x.User)
            .Include(x => x.Transactions)
            .FirstOrDefault(x => x.Id == id);
    }
}
