﻿// <auto-generated />
using System;
using AccountProjectCore.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AccountProjectCore.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190509192612_Remove_Int_CcyCode")]
    partial class Remove_Int_CcyCode
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AccountProjectCore.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountNumber");

                    b.Property<decimal>("Balance");

                    b.Property<DateTime>("ClosingDatetime");

                    b.Property<int>("CurrencyId");

                    b.Property<decimal>("InterestRate");

                    b.Property<DateTime>("OpeningDatetime");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("AccountProjectCore.Models.AccountHolder", b =>
                {
                    b.Property<int>("AccountId");

                    b.Property<int>("HolderId");

                    b.HasKey("AccountId", "HolderId");

                    b.HasIndex("HolderId");

                    b.ToTable("AccountHolders");
                });

            modelBuilder.Entity("AccountProjectCore.Models.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("AccountProjectCore.Models.Holder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adreess");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Passport");

                    b.Property<string>("TelephoneNumber");

                    b.Property<string>("VatNumber");

                    b.HasKey("Id");

                    b.ToTable("Holders");
                });

            modelBuilder.Entity("AccountProjectCore.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount");

                    b.Property<int>("ForAccountId");

                    b.Property<int>("InTransactionTypeId");

                    b.Property<int?>("InTransctionTypeId");

                    b.Property<DateTime>("TransactionDatetime");

                    b.HasKey("Id");

                    b.HasIndex("ForAccountId");

                    b.HasIndex("InTransctionTypeId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("AccountProjectCore.Models.TransactionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ChargeType");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("TransactionTypes");
                });

            modelBuilder.Entity("AccountProjectCore.Models.Account", b =>
                {
                    b.HasOne("AccountProjectCore.Models.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AccountProjectCore.Models.AccountHolder", b =>
                {
                    b.HasOne("AccountProjectCore.Models.Account", "Account")
                        .WithMany("AccountAccountHolders")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AccountProjectCore.Models.Holder", "Holder")
                        .WithMany("AccountHolders")
                        .HasForeignKey("HolderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AccountProjectCore.Models.Transaction", b =>
                {
                    b.HasOne("AccountProjectCore.Models.Account", "ForAccount")
                        .WithMany("Transactions")
                        .HasForeignKey("ForAccountId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AccountProjectCore.Models.TransactionType", "InTransctionType")
                        .WithMany()
                        .HasForeignKey("InTransctionTypeId");
                });
#pragma warning restore 612, 618
        }
    }
}
