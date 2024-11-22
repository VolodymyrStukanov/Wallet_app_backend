﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApplication1.DB;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WebApplication1.DB.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("CardBalance")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Limit")
                        .HasColumnType("numeric");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Accounts", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CardBalance = 1234.12m,
                            Limit = 1500m,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("WebApplication1.DB.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<int?>("AuthorizedUserId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsPending")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("AuthorizedUserId");

                    b.ToTable("Transactions", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccountId = 1,
                            Amount = 150.5m,
                            Date = new DateTime(2024, 11, 19, 0, 0, 0, 0, DateTimeKind.Utc),
                            Description = "Description Store",
                            IsPending = true,
                            Name = "Store",
                            Type = 1
                        },
                        new
                        {
                            Id = 2,
                            AccountId = 1,
                            Amount = 530m,
                            Date = new DateTime(2024, 11, 17, 0, 0, 0, 0, DateTimeKind.Utc),
                            Description = "Description Restaurant",
                            IsPending = false,
                            Name = "Restaurant",
                            Type = 1
                        },
                        new
                        {
                            Id = 3,
                            AccountId = 1,
                            Amount = 150m,
                            AuthorizedUserId = 2,
                            Date = new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Utc),
                            Description = "Description ATB",
                            IsPending = true,
                            Name = "ATB",
                            Type = 1
                        },
                        new
                        {
                            Id = 4,
                            AccountId = 1,
                            Amount = 205m,
                            AuthorizedUserId = 2,
                            Date = new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Utc),
                            Description = "Description Silpo",
                            IsPending = false,
                            Name = "Silpo",
                            Type = 1
                        },
                        new
                        {
                            Id = 5,
                            AccountId = 1,
                            Amount = 150m,
                            Date = new DateTime(2024, 11, 14, 0, 0, 0, 0, DateTimeKind.Utc),
                            Description = "Description Valera",
                            IsPending = false,
                            Name = "Valera",
                            Type = 0
                        },
                        new
                        {
                            Id = 6,
                            AccountId = 1,
                            Amount = 100m,
                            Date = new DateTime(2024, 11, 14, 0, 0, 0, 0, DateTimeKind.Utc),
                            Description = "Description Olga",
                            IsPending = false,
                            Name = "Olga",
                            Type = 0
                        },
                        new
                        {
                            Id = 7,
                            AccountId = 1,
                            Amount = 459m,
                            Date = new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Utc),
                            Description = "Description ATB",
                            IsPending = false,
                            Name = "ATB",
                            Type = 1
                        },
                        new
                        {
                            Id = 8,
                            AccountId = 1,
                            Amount = 150m,
                            Date = new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Utc),
                            Description = "Description Avrora",
                            IsPending = false,
                            Name = "Avrora",
                            Type = 1
                        },
                        new
                        {
                            Id = 9,
                            AccountId = 1,
                            Amount = 140m,
                            Date = new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Utc),
                            Description = "Description Dmytro",
                            IsPending = false,
                            Name = "Dmytro",
                            Type = 0
                        },
                        new
                        {
                            Id = 10,
                            AccountId = 1,
                            Amount = 524m,
                            Date = new DateTime(2024, 11, 9, 0, 0, 0, 0, DateTimeKind.Utc),
                            Description = "Description Silpo",
                            IsPending = false,
                            Name = "Silpo",
                            Type = 1
                        },
                        new
                        {
                            Id = 11,
                            AccountId = 1,
                            Amount = 999m,
                            Date = new DateTime(2024, 11, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            Description = "Description IKEA",
                            IsPending = false,
                            Name = "IKEA",
                            Type = 1
                        },
                        new
                        {
                            Id = 12,
                            AccountId = 1,
                            Amount = 200m,
                            Date = new DateTime(2024, 11, 4, 0, 0, 0, 0, DateTimeKind.Utc),
                            Description = "Description Bolt",
                            IsPending = false,
                            Name = "Bolt",
                            Type = 1
                        });
                });

            modelBuilder.Entity("WebApplication1.DB.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Volodymyr",
                            Surname = "Surname"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Vasyl",
                            Surname = "Surname"
                        });
                });

            modelBuilder.Entity("WebApplication1.DB.Models.Account", b =>
                {
                    b.HasOne("WebApplication1.DB.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebApplication1.DB.Models.Transaction", b =>
                {
                    b.HasOne("WebApplication1.DB.Models.Account", null)
                        .WithMany("Transactions")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.DB.Models.User", "AuthorizedUser")
                        .WithMany()
                        .HasForeignKey("AuthorizedUserId");

                    b.Navigation("AuthorizedUser");
                });

            modelBuilder.Entity("WebApplication1.DB.Models.Account", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
