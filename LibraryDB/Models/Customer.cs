using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LibraryDB.Models
{
    internal class Customer
    {

        public int Customer_id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public LoanCard LoanCard { get; set; }



    }
}
