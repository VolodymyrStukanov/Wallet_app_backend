namespace WebApplication1.DB.Models
{
    public class Account
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public decimal CardBalance { get; set; }
        public decimal Limit { get; set; } = 1500;
        public List<Transaction>? Transactions { get; set; }
    }
}
