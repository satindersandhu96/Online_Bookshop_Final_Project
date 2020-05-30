using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Online_Bookshop_Final_Project.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace Online_Bookshop_Final_Project.Controllers
{

    //book sales records controller
    public class BookSalesRecordsController : Controller
    {
        private readonly Online_Bookshop_DataContext _context;

        private SignInManager<IdentityUser> SignInManager;
        private UserManager<IdentityUser> UserManager;

        public BookSalesRecordsController(Online_Bookshop_DataContext context,
            SignInManager<IdentityUser> _SignInManager,

            UserManager<IdentityUser> _UserManager
            )
        {
            SignInManager = _SignInManager;
            UserManager = _UserManager;
            _context = context;
        }

        // GET: BookSalesRecords
        //Admin only get all sales records
        [Authorize(Roles = "shop_admin")]
        public async Task<IActionResult> Index()
        {
            var online_Bookshop_DataContext = _context.BookSalesRecord.Include(b => b.Book).Include(b => b.Reader);
            return View(await online_Bookshop_DataContext.ToListAsync());
        }

        // GET: BookSalesRecords/Details/5
        //Admin only get details
        [Authorize(Roles = "shop_admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookSalesRecord = await _context.BookSalesRecord
                .Include(b => b.Book)
                .Include(b => b.Reader)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookSalesRecord == null)
            {
                return NotFound();
            }

            return View(bookSalesRecord);
        }

        // GET: BookSalesRecords/Create
        //Reader only create sales records from wish list
        [Authorize(Roles = "reader")]
        public IActionResult Create()
        {


            if (SignInManager.IsSignedIn(User)) {


                var reader = (from user in _context.Reader
                              where user.Email.Equals(User.Identity.Name) select user).FirstOrDefault();

                List <Book> Books = JsonSerializer.Deserialize<List<Book>>(HttpContext.Session.GetString("list"));

                string OrderId = DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + reader.Id;

                ViewData["OrderId"] = OrderId;
                Books.ForEach(b =>
                {
                    BookSalesRecord record = new BookSalesRecord();

                    record.BookId = b.Id;
                    record.ReaderId = reader.Id;
                    record.OrderId = OrderId;

                    _context.BookSalesRecord.Add(record);
                    _context.SaveChanges();


                });

            }

            return View();
        }

       
       

        // GET: BookSalesRecords/Delete/5
        //Get the record for delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookSalesRecord = await _context.BookSalesRecord
                .Include(b => b.Book)
                .Include(b => b.Reader)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookSalesRecord == null)
            {
                return NotFound();
            }

            return View(bookSalesRecord);
        }

        // POST: BookSalesRecords/Delete/5
        //Deletes the sales record.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookSalesRecord = await _context.BookSalesRecord.FindAsync(id);
            _context.BookSalesRecord.Remove(bookSalesRecord);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
