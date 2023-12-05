using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LibraryDB.Models;

namespace LibraryDB.Data
{
    internal class Context: DbContext
    {
        DbSet<Customer> Customers { get; set; }




    }
}
