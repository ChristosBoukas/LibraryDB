using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LibraryDB.Models;
using EntityFrameworkCore.EncryptColumn.Util;
using EntityFrameworkCore.EncryptColumn.Extension;
using EntityFrameworkCore.EncryptColumn.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace LibraryDB.Data
{
    internal class Context: DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<LoanCard> LoanCards { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Models.Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //Local opt builder
            //optionsBuilder.UseSqlServer(@"
            //    Server=localhost;
            //    Database=NewtonLibraryChristos;
            //    Trusted_Connection=true;
            //    Trust Server Certificate=yes;
            //    User Id=NewtonLibrary;
            //    password=NewtonLibrary"
            //);


            optionsBuilder.UseSqlServer("Server = tcp:newton-dab-christos.database.windows.net, 1433; Initial Catalog = NewtonLibraryChristos; Persist Security Info = False; User ID = NewtonLibraryChristos; Password =LibraryNewtonChristos123!!!; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");
        }



        private readonly IEncryptionProvider _provider;
        public Context()
        {
            this._provider = new GenerateEncryptionProvider("fth84hdbj6536example_encrypt_key");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseEncryption(this._provider);
        }




    }
}
