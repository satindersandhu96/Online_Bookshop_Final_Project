using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Bookshop_Final_Project.Models
{
    //Book details including book image
    public class Book
    {

        //Book id
        public int Id { get; set; }

        //Book name
        public string BookTitle { get; set; }

        //Price of book
        public decimal Price { get; set; }

        //Uploaded image data
        [NotMapped]
        public IFormFile BookImage {get; set;}

        //Location of the stored image
        public string ImageUrl { get; set; }



    }
}
