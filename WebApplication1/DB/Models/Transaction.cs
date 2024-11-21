﻿namespace WebApplication1.DB.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public TransactionType Type { get; set; }
        public decimal Amount { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime Date { get; set; }
        public bool IsPending { get; set; }
        public int? AuthorizedUserId { get; set; }
        public User? AuthorizedUser { get; set; }
    }

    public enum TransactionType
    {
        Payment = 0,
        Credit = 1
    }
}