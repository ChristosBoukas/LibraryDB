using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LibraryDB.Models
{
    internal class Book
    {
        public int id { get; set; }
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


        public Book()
        {
            
        }

    }


    public enum enGrade { Ungraded, Awful, Bad, Decent, Good, Amazing }

}
