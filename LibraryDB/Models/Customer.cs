﻿using System;
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
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public int LoanCardid { get; set; } // Foreign Key
        public LoanCard LoanCard { get; set; } // Reference Navigation Property


        public Customer()
        {
            
        }


    }
}
