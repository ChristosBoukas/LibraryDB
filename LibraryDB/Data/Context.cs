using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LibraryDB.Models;

namespace LibraryDB.Data
{
    internal class Context: DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<LoanCard> LoanCards { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"
                Server=localhost;
                Database=NewtonLibraryChristos;
                Trusted_Connection=true;
                Trust Server Certificate=yes;
                User Id=NewtonLibraryChristos;
                password=NewtonLibraryChristos");
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Customer>()
        //        .HasOne(c => c.LoanCard)
        //        .WithOne(l => l.Customer)
        //        .HasForeignKey<LoanCard>(l => l.Customerid)
        //        .IsRequired();
        //}


    }
}
