namespace WebApplication1.Models
{
    public class UserDetailsModel
    {
        public decimal Balance { get; set; }
        public decimal Available { get; set; }
        public required string NoPaymentDue { get; set; }
        public required string DailyPoints { get; set; }
        public required IEnumerable<TransactionModel> Transactions { get; set; }

    }
}
