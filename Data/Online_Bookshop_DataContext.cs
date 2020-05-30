using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Online_Bookshop_Final_Project.Models;

namespace Online_Bookshop_Final_Project.Models
{

    //Map the database tables with the Model classes 
    public class Online_Bookshop_DataContext : DbContext
    {
        public Online_Bookshop_DataContext (DbContextOptions<Online_Bookshop_DataContext> options)
            : base(options)
        {
        }

        public DbSet<Online_Bookshop_Final_Project.Models.Book> Book { get; set; }

        public DbSet<Online_Bookshop_Final_Project.Models.BookSalesRecord> BookSalesRecord { get; set; }

        public DbSet<Online_Bookshop_Final_Project.Models.Reader> Reader { get; set; }
    }
}
