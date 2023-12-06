using Helpers;
using LibraryDB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDB.Data
{
    internal class DataAccess
    {

        //Seed data

        //Create Author
        //Create Book
        //Create Customer/Loancard

        //Borrow a book
        //Return a book

        //Remove Data

        //Create book with an author--



        public void SeedCustomerAndLoanCard()
        {
            using (Context context = new Context())
            {
                var rnd = new csSeedGenerator();

                Customer newCustomer = new Customer();
                newCustomer.FirstName = rnd.FirstName;
                newCustomer.LastName = rnd.LastName;

                LoanCard newLoanCard = new LoanCard();
                newLoanCard.Pin = GeneratePin();
                newLoanCard.Customer = newCustomer;

                //context.LoanCards.Add(newLoanCard);
                context.SaveChanges();

            }
        }




        public int GeneratePin()
        {
            var rnd = new csSeedGenerator();
            return rnd.Next(1000, 9000);
        }
    }
}
