using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.EncryptColumn;
using EntityFrameworkCore.EncryptColumn.Attribute;

namespace LibraryDB.Models
{
    internal class LoanCard
    {
        public int Id { get; set; }
        [EncryptColumn]
        public string Pin { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
        public Customer Customer { get; set; } // Reference Navigation to Dependent


        public LoanCard()
        {
            
        }

    }
}
