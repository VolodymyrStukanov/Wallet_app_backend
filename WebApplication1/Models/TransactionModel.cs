using WebApplication1.DB.Models;

namespace WebApplication1.Models
{
    public class TransactionModel
    {
        public int Id { get; set; }
        public TransactionType Type { get; set; }
        public required string Amount { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Date { get; set; }
        public string? AuthorizedUser { get; set; }
    }
}
