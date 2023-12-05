using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LibraryDB.Models
{
    internal class LoanCard
    {
        public int LoanCard_id { get; set; }
        public Customer Customer { get; set; }
        public int Pin { get; set; }

    }
}
