using Helpers;
using LibraryDB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

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
