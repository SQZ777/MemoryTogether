using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MemoryTogether.Context;
using MemoryTogether.Model;

namespace MemoryTogether.Controllers
{
    public class AccountingBooksController : Controller
    {
        private readonly MemoryTogetherContext _context;

        public AccountingBooksController(MemoryTogetherContext context)
        {
            _context = context;
        }

        // GET: AccountingBooks
        public async Task<IActionResult> Index()
        {
            return View(await _context.AccountingBooks.ToListAsync());
        }

        // GET: AccountingBooks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountingBook = await _context.AccountingBooks
                .SingleOrDefaultAsync(m => m.Id == id);
            if (accountingBook == null)
            {
                return NotFound();
            }

            return View(accountingBook);
        }

        // GET: AccountingBooks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AccountingBooks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,Stuff,Description")] AccountingBook accountingBook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accountingBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(accountingBook);
        }

        // GET: AccountingBooks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountingBook = await _context.AccountingBooks.SingleOrDefaultAsync(m => m.Id == id);
            if (accountingBook == null)
            {
                return NotFound();
            }
            return View(accountingBook);
        }

        // POST: AccountingBooks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,Stuff,Description")] AccountingBook accountingBook)
        {
            if (id != accountingBook.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accountingBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountingBookExists(accountingBook.Id))
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
            return View(accountingBook);
        }

        // GET: AccountingBooks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accountingBook = await _context.AccountingBooks
                .SingleOrDefaultAsync(m => m.Id == id);
            if (accountingBook == null)
            {
                return NotFound();
            }

            return View(accountingBook);
        }

        // POST: AccountingBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accountingBook = await _context.AccountingBooks.SingleOrDefaultAsync(m => m.Id == id);
            _context.AccountingBooks.Remove(accountingBook);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountingBookExists(int id)
        {
            return _context.AccountingBooks.Any(e => e.Id == id);
        }
    }
}
