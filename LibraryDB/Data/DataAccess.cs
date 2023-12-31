﻿using Helpers;
using LibraryDB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace LibraryDB.Data
{
    internal class DataAccess
    {
        #region Seeding and Create Methods
        public void CreateBook()
        {
            using (Context context = new Context())
            {
                Book newBook = new Book();
                Console.WriteLine("Input Book Title:");
                string inputString = Console.ReadLine();
                newBook.Title = inputString;
                Console.WriteLine("Input ISBN:");
                inputString = Console.ReadLine();
                newBook.ISBN = inputString;
                Console.WriteLine("Input year of publication:");
                inputString = Console.ReadLine();
                if (int.TryParse(inputString, out int outResult))
                {
                    newBook.Year = outResult;
                }
                Console.WriteLine("Input Book grade (1-5):");
                inputString = Console.ReadLine();
                switch (inputString)
                {
                    case "1":
                        newBook.Grade = enGrade.Awful.ToString(); 
                        break;
                    case "2":
                        newBook.Grade = enGrade.Bad.ToString();
                        break;
                    case "3":
                        newBook.Grade = enGrade.Decent.ToString();
                        break;
                    case "4":
                        newBook.Grade = enGrade.Good.ToString();
                        break;
                    case "5":
                        newBook.Grade = enGrade.Amazing.ToString();
                        break;
                    default:
                        newBook.Grade = enGrade.Ungraded.ToString();
                        break;
                }
                Console.WriteLine("Is book available y/n:");
                inputString = Console.ReadLine().ToLower();
                switch (inputString)
                {
                    case "y":
                        newBook.IsAvailable = true;
                        break;
                    case "n":
                        newBook.IsAvailable = false;
                        break;
                    default:
                        newBook.IsAvailable = false;
                        break;

                }

                context.Books.Add(newBook);
                context.SaveChanges();

            }
        }

        public void CreateAuthor()
        {
            using (Context context = new Context())
            {
                Author newAuthor = new Author();
                Console.WriteLine("Input Author First Name:");
                string inputString = Console.ReadLine();
                newAuthor.FirstName = inputString;
                Console.WriteLine("Input Author Last Name:");
                inputString = Console.ReadLine();
                newAuthor.LastName = inputString;

                context.Authors.Add(newAuthor);
                context.SaveChanges();
            }
        }

        public void CreateCustomerAndLoanCard()
        {
            using (Context context = new Context())
            {
                //Create Loan Card
                LoanCard newLoanCard = new LoanCard();
                Console.WriteLine("Input Loan Card Pin:");
                string inputString = Console.ReadLine();
                if (int.TryParse(inputString, out int outResult))
                {
                    newLoanCard.Pin = outResult.ToString();
                }

                //Create Customer
                Customer newCustomer = new Customer();
                Console.WriteLine("Input Customer First Name:");
                inputString = Console.ReadLine();
                newCustomer.FirstName = inputString;
                Console.WriteLine("Input Customer Last Name:");
                inputString = Console.ReadLine();
                newCustomer.LastName = inputString;

                newLoanCard.Customer = newCustomer;

                context.LoanCards.Add(newLoanCard);
                context.SaveChanges();

            }
        }

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
                newCustomer.LoanCard = newLoanCard;
                newLoanCard.Customer = newCustomer;

               context.Customers.Add(newCustomer);
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

        #endregion

        #region Book Loan Methods

        public void LoanBook(int loanCardID, int bookID)
        {
            using (Context context = new Context())
            {
                Models.Transaction newTransaction = new Models.Transaction();
                Book book = GetBookByID(bookID, context);
                LoanCard loanCard = GetLoanCardByID(loanCardID, context);

                newTransaction.LoanCard = loanCard;
                newTransaction.Book = book;
                newTransaction.LoanDate = DateTime.Now;

                book.Transaction = newTransaction;
                book.IsAvailable = false;

                context.Transactions.Add(newTransaction);
                context.SaveChanges();
            }
        }

        public void ReturnBook(int bookID)
        {
            using (Context context = new Context())
            {
                Book book = GetBookByID(bookID, context);
                //Models.Transaction transaction = book.Transaction;
                
                book.Transaction.ReturnDate = DateTime.Now;
                book.Transaction.Book.IsAvailable = true;
                book.Transaction = null;


                context.SaveChanges();
            }
        }

        public List<Models.Transaction> ShowLoanHistoryByLoanCardId(int loanCardID)
        {
            using (Context context = new Context())
            {
                LoanCard loanCard = GetLoanCardByID(loanCardID, context);

                List<Models.Transaction> transactions = context.Transactions
                    .Include(transaction => transaction.Book) // Include related Book
                    .Where(transaction => transaction.LoanCard.Id == loanCardID)
                    .ToList();

                foreach (Models.Transaction transaction in transactions)
                {
                    Console.WriteLine($"{transaction.Book.Title}");
                }

                return transactions;
            }
        }

        #endregion

        #region Remove Methods

        public void RemoveBookByTitle(string title)
        {
            using (Context context = new Context())
            {
                Book bookToRemove = GetFirstOrDefaultBookByTitle(title, context);
                context.Books.Remove(bookToRemove);
                context.SaveChanges() ;
            }
        }

        public void RemoveBookByID(int bookID)
        {
            using (Context context = new Context())
            {
                Book bookToRemove = GetBookByID(bookID,context);
                context.Books.Remove(bookToRemove);
                context.SaveChanges();
            }
        }

        public void RemoveAuthorByID(int authorID)
        {
            using (Context context = new Context())
            {
                Author authorToRemove = context.Authors.Where(author => author.id == authorID).SingleOrDefault();
                context.Authors.Remove(authorToRemove);
                context.SaveChanges();
            }
        }

        public void RemoveLoancardAndCustomerByID(int loanCardID)
        {
            using (Context context = new Context())
            {
                LoanCard loanCardToRemove = context.LoanCards
                    .Include(lc => lc.Customer)
                    .Where(loanCard => loanCard.Id == loanCardID)
                    .SingleOrDefault();

                Customer customerToRemove = loanCardToRemove.Customer;

                context.Customers.Remove(customerToRemove);
                context.LoanCards.Remove(loanCardToRemove);
                
                context.SaveChanges();
            }
        }


        #endregion

        #region Generate Methods
        public string GenerateISBN()
        {
            var rnd = new csSeedGenerator();
            return $"{rnd.Next(1000, 9000)}-{rnd.Next(1, 9)}-{rnd.Next(10, 99)}-{rnd.Next(100000, 999999)}-{rnd.Next(1, 9)}";
        }

        public string GeneratePin()
        {
            var rnd = new csSeedGenerator();
            return rnd.Next(1000, 9000).ToString();
        }


        #endregion

        #region Utilities

        public Book? GetFirstOrDefaultBookByTitle(string title, Context context)
        {
            return context.Books.Where(book => book.Title == title).FirstOrDefault();
        }

        public Book? GetBookByID(int bookID, Context context)
        {
            return context.Books
                .Include(book => book.Transaction)
                .Where(book => book.Id == bookID).SingleOrDefault();
        }

        public LoanCard? GetLoanCardByID(int loanCardID, Context context)
        {
            return context.LoanCards
                .Include(loanCard => loanCard.Transactions)
                 .ThenInclude(transaction => transaction.Book)
                .Where(loanCard => loanCard.Id == loanCardID)
                .SingleOrDefault();
        }

        public Models.Transaction? GetTransactionByID(int transactionID, Context context)
        {
            return context.Transactions.Where(transaction => transaction.Id == transactionID).SingleOrDefault();
        }

        #endregion
    }
}
