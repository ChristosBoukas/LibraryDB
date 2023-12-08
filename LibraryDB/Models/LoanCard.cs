﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryDB.Models
{
    internal class LoanCard
    {
        
        public int Id { get; set; }
        public int Pin { get; set; }
        public Customer Customer { get; set; } // Reference Navigation to Dependent


        public LoanCard()
        {
            
        }

    }
}
