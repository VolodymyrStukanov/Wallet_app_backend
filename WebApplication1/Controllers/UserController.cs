using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using WebApplication1.DB.Models;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : APIController
    {
        private readonly ITransactionService _transactionService;
        private readonly IPointService _pointService;
        private readonly IAccountService _accountService;

        private readonly ILogger _logger;

        private readonly IMemoryCache _cache;        
        private readonly MemoryCacheEntryOptions _cacheOption;

        public UsersController(ITransactionService transactionService, 
            IPointService pointService,
            IAccountService accountService,
            ILogger<UsersController> logger,
            IMemoryCache cache)
        {
            _transactionService = transactionService;
            _pointService = pointService;
            _accountService = accountService;
            _cache = cache;
            _logger = logger;
            _cacheOption = new MemoryCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromMinutes(5)
            };
        }

        [HttpGet("{id}")]
        public ActionResult<UserDetailsModel> GetAccountDetails(int id)
        {
            try
            {
                var cacheKey = $"AccountDetails_{id}";
                if (_cache.TryGetValue<UserDetailsModel>(cacheKey, out UserDetailsModel? cachedData))
                {
                    return BuildSuccessResult(cachedData, "Account is found", 200);
                }

                var account = _accountService.GetAccountById(id);
                //var account = _accountService.GetAccountByIdIncludingTransactions(id);    //takes a lot of resourses if the account has a lot of transactions
                var transactions = _transactionService.GetTransactionsByAccountId(id, 10).ToList();


                if (account == null)
                    return BuildErrorResult("Account not found.", 400);

                var currentDate = DateTime.UtcNow;
                var dailyPoints = _pointService.GetDailyPoints(currentDate);

                var response = new UserDetailsModel()
                {
                    Balance = account.CardBalance,
                    Available = account.Limit - account.CardBalance,
                    NoPaymentDue = $"You’ve paid your {currentDate.ToString("MMMM")} balance.",
                    DailyPoints = FormatPoints(dailyPoints),
                    Transactions = transactions.Select(t =>
                    {
                        return new TransactionModel()
                        {
                            Id = t.Id,
                            Type = t.Type,
                            Amount = t.Type == TransactionType.Payment ? $"+{t.Amount}" : $"{t.Amount}",
                            Name = t.Name,
                            Description = t.Description,
                            Date = FormatDate(t.Date),
                            AuthorizedUser = t.AuthorizedUser?.Name,
                        };
                    })
                };

                _cache.Set<UserDetailsModel>(cacheKey, response, _cacheOption);
                return BuildSuccessResult(response, "Account is found", 200);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured while receivng the account details with id {id}. \n Error message: {ex.Message}");
                return BuildErrorResult(ex.Message, 400);
            }
        }

        private string FormatPoints(long points)
        {
            if(points <= 1000) 
                return points.ToString();
            return points % 1000 >= 500 ? $"{(points / 1000) + 1}K" : $"{points / 1000}K";
        }

        private string FormatDate(DateTime date)
        {
            return date.Date.CompareTo(DateTime.UtcNow.Date.AddDays(-7)) <= 0
                ? date.ToString("MM/dd/yy")
                : date.ToString("dddd");
        }
    }
}
