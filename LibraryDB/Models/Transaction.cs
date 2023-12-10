using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryDB.Models
{
    internal class Transaction
    {
        [Key]
        public int Id { get; set; }
        public LoanCard LoanCard { get; set; } // Reference Navigation to Dependent
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        [ForeignKey("Book")]
        public int BookId { get; set; } // Foreign Key
        public Book Book { get; set; } // Reference Navigation to Dependent

        public Transaction()
        {
            
        }

    }
}
