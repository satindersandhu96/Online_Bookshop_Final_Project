using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Online_Bookshop_Final_Project.Models;

namespace Online_Bookshop_Final_Project.Controllers
{

    //books controller 
    
    public class BooksController : Controller
    {
        private readonly Online_Bookshop_DataContext _context;

        public BooksController(Online_Bookshop_DataContext context)
        {
            _context = context;
        }

        // GET: Books
        //Gets all books by readers and admin
        [Authorize(Roles = "reader,shop_admin")]
        public async Task<IActionResult> Index()
        {
            return View(await (from books in _context.Book select books).ToListAsync());
        }

       
       

        // GET: Books/Create
        //Gets a book create form admin only
        [Authorize(Roles = "shop_admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        
            //Creates a book
        [Authorize(Roles = "shop_admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BookTitle,Price,ImageUrl,BookImage")] Book book)
        {
            if (ModelState.IsValid)
            {
                SaveBookPicture(book);
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Edit/5
        //Gets a book for update .
        [Authorize(Roles = "shop_admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Updates a book
        [Authorize(Roles = "shop_admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BookTitle,Price,ImageUrl,BookImage")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    SaveBookPicture(book);
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Delete/5
        //Gets a book for delete
        [Authorize(Roles = "shop_admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        //Deletes a book 
        [Authorize(Roles = "shop_admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Book.FindAsync(id);
            _context.Book.Remove(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //Existance check using a lamda query.
        private bool BookExists(int id)
        {
            return _context.Book.Any(e => e.Id == id);
        }



        public IActionResult AddBookToWishList(int id)
        {

            var Book = (from book in _context.Book
                        where book.Id == id
                        select book).FirstOrDefault();


            if (HttpContext.Session.GetString("list") != null)
            {

                List<Book> Books = JsonSerializer.Deserialize<List<Book>>(HttpContext.Session.GetString("list"));


                Books.Add(Book);
                HttpContext.Session.SetString("list", JsonSerializer.Serialize(Books));

            }
            else
            {

                List<Book> Books = new List<Book>();
                Books.Add(Book);

                HttpContext.Session.SetString("list", JsonSerializer.Serialize(Books));
            }


            return RedirectToAction(nameof(Index));
        }

            public IActionResult WishList()
            {

            List<Book> Books = new List<Book>();

            if (HttpContext.Session.GetString("list") != null)
            {

                 Books = JsonSerializer.Deserialize<List<Book>>(HttpContext.Session.GetString("list"));

                            

            }

            return View(Books);


        }






        public IActionResult Remove(int id)
        {

            List<Book> Books = new List<Book>();

            if (HttpContext.Session.GetString("list") != null)
            {

                Books = JsonSerializer.Deserialize<List<Book>>(HttpContext.Session.GetString("list"));

                Books.Remove(Books.Find(p => p.Id == id));

                HttpContext.Session.SetString("list", JsonSerializer.Serialize(Books));

            }

            return RedirectToAction(nameof(WishList));


        }



        private void SaveBookPicture(Book Book)
        {

            if (Book.BookImage != null)
            {
                Book.ImageUrl = Book.BookImage.FileName;

                var filePath = "./wwwroot/books/" + Book.BookImage.FileName;


                if (Book.BookImage.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        Book.BookImage.CopyTo(stream);
                    }
                }
            }


        }

    }
}
