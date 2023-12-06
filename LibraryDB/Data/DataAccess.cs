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

                context.LoanCards.Add(newLoanCard);
                context.SaveChanges();
            }
        }

        public void SeedBookAndAuthor()
        {
            using (Context context = new Context())
            {
                var rnd = new csSeedGenerator();

                Author newAuthor = new Author();
                newAuthor.FirstName = rnd.FirstName;
                newAuthor.LastName = rnd.LastName;

                Book newBook = new Book();
                newBook.Title = rnd.MusicAlbum;
                newBook.ISBN = GenerateISBN();
                newBook.Year = rnd.Next(1900, 2023);
                newBook.Grade = rnd.FromEnum<enGrade>().ToString();
                newBook.IsAvailable = true;

                newBook.Author.Add(newAuthor);
                newAuthor.Books.Add(newBook);

                context.Books.Add(newBook);

                context.SaveChanges();
            }
        }


        public string GenerateISBN()
        {
            var rnd = new csSeedGenerator();
            return $"{rnd.Next(1000, 9000)}-{rnd.Next(1, 9)}-{rnd.Next(10, 99)}-{rnd.Next(100000, 999999)}-{rnd.Next(1, 9)}";
        }

        public int GeneratePin()
        {
            var rnd = new csSeedGenerator();
            return rnd.Next(1000, 9000);
        }

        public Book? GetFirstOrDefault(Book book, string title, Context context)
        {
            return context.Books.Where(book => book.Title == title).FirstOrDefault();


        }

        //public T GetFirstOrDefault<T>()
        //{

            
        //}



    }
}
