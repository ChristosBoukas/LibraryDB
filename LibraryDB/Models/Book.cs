﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryDB.Models
{
    internal class Book
    {
        [Key]
        public int Id { get; set; }
        public ICollection<Author> Author { get; set; } = new List<Author>();
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int Year { get; set; }

        protected string _grade;
        public string Grade
        {
            get { return _grade; }

            set
            {
                if (Enum.TryParse<enGrade>(value, out _))
                {
                    _grade = value;
                }
            }
        }
        public bool IsAvailable { get; set; }

        [ForeignKey("Transaction")]
        public int? TransactionId { get; set; } // Foreign Key
        public Transaction? Transaction { get; set; } // Reference Navigation Property

        public Book()
        {
            
        }

    }


    public enum enGrade { Ungraded, Awful, Bad, Decent, Good, Amazing }

}
