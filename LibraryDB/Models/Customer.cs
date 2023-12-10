using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryDB.Models
{
    internal class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public int LoanCardId { get; set; } // Foreign Key
        public LoanCard LoanCard { get; set; } // Reference Navigation Property, key used to set "current transaction", used for returning the book.

        public Customer()
        {
            
        }


    }
}
