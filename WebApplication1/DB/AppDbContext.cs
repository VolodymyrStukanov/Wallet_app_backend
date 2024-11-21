using Microsoft.EntityFrameworkCore;
using WebApplication1.DB.Models;

namespace WebApplication1.DB
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Account>().HasKey(u => u.Id);

            builder.Entity<Account>()
                .HasMany(u => u.Transactions)
                .WithOne()
                .HasForeignKey(t => t.AccountId);

            builder.Entity<User>().HasKey(u => u.Id);

            builder.Entity<Transaction>().HasKey(t => t.Id);

            builder.Entity<Transaction>()
                .HasOne(t => t.AuthorizedUser)
                .WithMany()
                .HasForeignKey(t => t.AuthorizedUserId);

            TestSeed(builder);
        }

        private void TestSeed(ModelBuilder builder)
        {
            builder.Entity<Account>()
                .HasData(new Account()
                {
                    Id = 1,
                    UserId = 1,
                    CardBalance = 1234.12M,
                });

            builder.Entity<User>()
                .HasData(new List<User> {
                new User()
                {
                    Id = 1,
                    Name = "Volodymyr",
                    Surname = "Surname",
                },
                new User()
                {
                    Id = 2,
                    Name = "Vasyl",
                    Surname = "Surname",
                },
                });

            builder.Entity<Transaction>()
                .HasData(new List<Transaction> {
                new Transaction()
                {
                    Id = 1,
                    AccountId = 1,
                    Type = TransactionType.Credit,
                    Amount = 150.5M,
                    Name = "Store",
                    Description = "Description Store",
                    Date = new DateTime(2024,11,19, 0,0,0, DateTimeKind.Utc),
                    IsPending = true,
                    AuthorizedUser = null,
                },
                new Transaction()
                {
                    Id = 2,
                    AccountId = 1,
                    Type = TransactionType.Credit,
                    Amount = 530M,
                    Name = "Restaurant",
                    Description = "Description Restaurant",
                    Date = new DateTime(2024,11,17, 0,0,0, DateTimeKind.Utc),
                    IsPending = false,
                    AuthorizedUser = null,
                },
                new Transaction()
                {
                    Id = 3,
                    AccountId = 1,
                    Type = TransactionType.Credit,
                    Amount = 150M,
                    Name = "ATB",
                    Description = "Description ATB",
                    Date = new DateTime(2024,11,20, 0,0,0, DateTimeKind.Utc),
                    IsPending = true,
                    AuthorizedUserId = 2,
                },
                new Transaction()
                {
                    Id = 4,
                    AccountId = 1,
                    Type = TransactionType.Credit,
                    Amount = 205,
                    Name = "Silpo",
                    Description = "Description Silpo",
                    Date = new DateTime(2024,11,15, 0,0,0, DateTimeKind.Utc),
                    IsPending = false,
                    AuthorizedUserId = 2,
                },
                new Transaction()
                {
                    Id = 5,
                    AccountId = 1,
                    Type = TransactionType.Payment,
                    Amount = 150M,
                    Name = "Valera",
                    Description = "Description Valera",
                    Date = new DateTime(2024,11,14, 0,0,0, DateTimeKind.Utc),
                    IsPending = false,
                },
                new Transaction()
                {
                    Id = 6,
                    AccountId = 1,
                    Type = TransactionType.Payment,
                    Amount = 100M,
                    Name = "Olga",
                    Description = "Description Olga",
                    Date = new DateTime(2024,11,14, 0,0,0, DateTimeKind.Utc),
                    IsPending = false,
                },
                new Transaction()
                {
                    Id = 7,
                    AccountId = 1,
                    Type = TransactionType.Credit,
                    Amount = 459,
                    Name = "ATB",
                    Description = "Description ATB",
                    Date = new DateTime(2024,11,10, 0,0,0, DateTimeKind.Utc),
                    IsPending = false,
                },
                new Transaction()
                {
                    Id = 8,
                    AccountId = 1,
                    Type = TransactionType.Credit,
                    Amount = 150M,
                    Name = "Avrora",
                    Description = "Description Avrora",
                    Date = new DateTime(2024,11,10, 0,0,0, DateTimeKind.Utc),
                    IsPending = false,
                },
                new Transaction()
                {
                    Id = 9,
                    AccountId = 1,
                    Type = TransactionType.Payment,
                    Amount = 140,
                    Name = "Dmytro",
                    Description = "Description Dmytro",
                    Date = new DateTime(2024,11,10, 0,0,0, DateTimeKind.Utc),
                    IsPending = false,
                },
                new Transaction()
                {
                    Id = 10,
                    AccountId = 1,
                    Type = TransactionType.Credit,
                    Amount = 524,
                    Name = "Silpo",
                    Description = "Description Silpo",
                    Date = new DateTime(2024,11,9, 0,0,0, DateTimeKind.Utc),
                    IsPending = false,
                },
                new Transaction()
                {
                    Id = 11,
                    AccountId = 1,
                    Type = TransactionType.Credit,
                    Amount = 999M,
                    Name = "IKEA",
                    Description = "Description IKEA",
                    Date = new DateTime(2024,11,5, 0,0,0, DateTimeKind.Utc),
                    IsPending = false,
                },
                new Transaction()
                {
                    Id = 12,
                    AccountId = 1,
                    Type = TransactionType.Credit,
                    Amount = 200M,
                    Name = "Bolt",
                    Description = "Description Bolt",
                    Date = new DateTime(2024,11,4, 0,0,0, DateTimeKind.Utc),
                    IsPending = false,
                },
                });
        }

    }
}
