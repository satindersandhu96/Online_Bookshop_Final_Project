using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Bookshop_Final_Project.Models
{
    //Sales record data.
    public class BookSalesRecord
    {
        //Book sales id
        public int Id { get; set; }

        //Book id reference key
        public int BookId { get; set; }
        
        //Reder reference key
        public int ReaderId { get; set; }

        //order id
        public string OrderId { get; set; }
        //Book link
        public Book Book { get; set; }

        //Reader link

        public Reader Reader { get; set; }



    }
}
