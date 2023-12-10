﻿// <auto-generated />
using System;
using LibraryDB.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace NewtonLibraryChristos.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.Property<int>("Authorid")
                        .HasColumnType("int");

                    b.Property<int>("Booksid")
                        .HasColumnType("int");

                    b.HasKey("Authorid", "Booksid");

                    b.HasIndex("Booksid");

                    b.ToTable("AuthorBook");
                });

            modelBuilder.Entity("LibraryDB.Models.Author", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("LibraryDB.Models.Book", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Grade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TransactionId")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("TransactionId")
                        .IsUnique()
                        .HasFilter("[TransactionId] IS NOT NULL");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("LibraryDB.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LoanCardId")
                        .HasColumnType("int");

                    b.Property<int?>("TransactionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LoanCardId")
                        .IsUnique();

                    b.HasIndex("TransactionId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("LibraryDB.Models.LoanCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Pin")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("LoanCards");
                });

            modelBuilder.Entity("LibraryDB.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("LoanCardId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LoanDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("LoanCardId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.HasOne("LibraryDB.Models.Author", null)
                        .WithMany()
                        .HasForeignKey("Authorid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryDB.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("Booksid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LibraryDB.Models.Book", b =>
                {
                    b.HasOne("LibraryDB.Models.Transaction", "Transaction")
                        .WithOne("Book")
                        .HasForeignKey("LibraryDB.Models.Book", "TransactionId");

                    b.Navigation("Transaction");
                });

            modelBuilder.Entity("LibraryDB.Models.Customer", b =>
                {
                    b.HasOne("LibraryDB.Models.LoanCard", "LoanCard")
                        .WithOne("Customer")
                        .HasForeignKey("LibraryDB.Models.Customer", "LoanCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryDB.Models.Transaction", "Transaction")
                        .WithMany()
                        .HasForeignKey("TransactionId");

                    b.Navigation("LoanCard");

                    b.Navigation("Transaction");
                });

            modelBuilder.Entity("LibraryDB.Models.Transaction", b =>
                {
                    b.HasOne("LibraryDB.Models.LoanCard", "LoanCard")
                        .WithMany("Transactions")
                        .HasForeignKey("LoanCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LoanCard");
                });

            modelBuilder.Entity("LibraryDB.Models.LoanCard", b =>
                {
                    b.Navigation("Customer")
                        .IsRequired();

                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("LibraryDB.Models.Transaction", b =>
                {
                    b.Navigation("Book")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
