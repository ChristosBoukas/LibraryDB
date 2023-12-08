using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LibraryDB.Models
{
    internal class Transaction
    {
        public int id { get; set; }
        public LoanCard LoanCard { get; set; }
        public Book Book { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public Transaction()
        {
            
        }

    }
}
