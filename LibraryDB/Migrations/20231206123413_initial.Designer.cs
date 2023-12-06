﻿// <auto-generated />
using LibraryDB.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace NewtonLibraryChristos.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20231206123413_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LibraryDB.Models.Customer", b =>
                {
                    b.Property<int>("Customer_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Customer_id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LoanCardid")
                        .HasColumnType("int");

                    b.HasKey("Customer_id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("LibraryDB.Models.LoanCard", b =>
                {
                    b.Property<int>("LoanCard_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LoanCard_id"));

                    b.Property<int>("Customerid")
                        .HasColumnType("int");

                    b.Property<int>("Pin")
                        .HasColumnType("int");

                    b.HasKey("LoanCard_id");

                    b.HasIndex("Customerid")
                        .IsUnique();

                    b.ToTable("LoanCards");
                });

            modelBuilder.Entity("LibraryDB.Models.LoanCard", b =>
                {
                    b.HasOne("LibraryDB.Models.Customer", "Customer")
                        .WithOne("LoanCard")
                        .HasForeignKey("LibraryDB.Models.LoanCard", "Customerid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("LibraryDB.Models.Customer", b =>
                {
                    b.Navigation("LoanCard")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
