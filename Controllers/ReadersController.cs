using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Online_Bookshop_Final_Project.Models;

namespace Online_Bookshop_Final_Project.Controllers
{
    //Readers controller admin only access
    [Authorize(Roles = "shop_admin")]
    public class ReadersController : Controller
    {
        private readonly Online_Bookshop_DataContext _context;

        public ReadersController(Online_Bookshop_DataContext context)
        {
            _context = context;
        }

        // GET: Readers
        //Get all readers

        public async Task<IActionResult> Index()
        {
            return View(await (from reader in _context.Reader select reader).ToListAsync());
        }

        // GET: Readers/Details/5
        //Gets the details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reader = await _context.Reader
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reader == null)
            {
                return NotFound();
            }

            return View(reader);
        }

       

        // GET: Readers/Edit/5
        //Get reader for update
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reader = await _context.Reader.FindAsync(id);
            if (reader == null)
            {
                return NotFound();
            }
            return View(reader);
        }

        // POST: Readers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Updates a reader
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email")] Reader reader)
        {
            if (id != reader.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reader);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReaderExists(reader.Id))
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
            return View(reader);
        }

        // GET: Readers/Delete/5
        //Gets reader for delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reader = await _context.Reader
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reader == null)
            {
                return NotFound();
            }

            return View(reader);
        }

        // POST: Readers/Delete/5
        //Delete reader.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reader = await _context.Reader.FindAsync(id);
            _context.Reader.Remove(reader);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //Check reader existance using lamda 
        private bool ReaderExists(int id)
        {
            return _context.Reader.Any(e => e.Id == id);
        }
    }
}
