using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class AddedAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    CardBalance = table.Column<decimal>(type: "numeric", nullable: false),
                    Limit = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccountId = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsPending = table.Column<bool>(type: "boolean", nullable: false),
                    AuthorizedUserId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Users_AuthorizedUserId",
                        column: x => x.AuthorizedUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "Surname" },
                values: new object[,]
                {
                    { 1, "Volodymyr", "Surname" },
                    { 2, "Vasyl", "Surname" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "CardBalance", "Limit", "UserId" },
                values: new object[] { 1, 1234.12m, 1500m, 1 });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "AccountId", "Amount", "AuthorizedUserId", "Date", "Description", "IsPending", "Name", "Type" },
                values: new object[,]
                {
                    { 1, 1, 150.5m, null, new DateTime(2024, 11, 19, 0, 0, 0, 0, DateTimeKind.Utc), "Description Store", true, "Store", 1 },
                    { 2, 1, 530m, null, new DateTime(2024, 11, 17, 0, 0, 0, 0, DateTimeKind.Utc), "Description Restaurant", false, "Restaurant", 1 },
                    { 3, 1, 150m, 2, new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Utc), "Description ATB", true, "ATB", 1 },
                    { 4, 1, 205m, 2, new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Description Silpo", false, "Silpo", 1 },
                    { 5, 1, 150m, null, new DateTime(2024, 11, 14, 0, 0, 0, 0, DateTimeKind.Utc), "Description Valera", false, "Valera", 0 },
                    { 6, 1, 100m, null, new DateTime(2024, 11, 14, 0, 0, 0, 0, DateTimeKind.Utc), "Description Olga", false, "Olga", 0 },
                    { 7, 1, 459m, null, new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Description ATB", false, "ATB", 1 },
                    { 8, 1, 150m, null, new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Description Avrora", false, "Avrora", 1 },
                    { 9, 1, 140m, null, new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Description Dmytro", false, "Dmytro", 0 },
                    { 10, 1, 524m, null, new DateTime(2024, 11, 9, 0, 0, 0, 0, DateTimeKind.Utc), "Description Silpo", false, "Silpo", 1 },
                    { 11, 1, 999m, null, new DateTime(2024, 11, 5, 0, 0, 0, 0, DateTimeKind.Utc), "Description IKEA", false, "IKEA", 1 },
                    { 12, 1, 200m, null, new DateTime(2024, 11, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Description Bolt", false, "Bolt", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_UserId",
                table: "Accounts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AccountId",
                table: "Transactions",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AuthorizedUserId",
                table: "Transactions",
                column: "AuthorizedUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
