using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MemoryTogether.Context;
using MemoryTogether.Model;

namespace MemoryTogether.Controller
{
    [Produces("application/json")]
    [Route("api/AccountingBooks")]
    public class AccountingBooksController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly MemoryTogetherContext _context;

        public AccountingBooksController(MemoryTogetherContext context)
        {
            _context = context;
        }

        // GET: api/AccountingBooks
        [HttpGet]
        public IEnumerable<AccountingBook> GetAccountingBooks()
        {
            return _context.AccountingBooks;
        }

        // GET: api/AccountingBooks/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccountingBook([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var accountingBook = await _context.AccountingBooks.SingleOrDefaultAsync(m => m.Id == id);

            if (accountingBook == null)
            {
                return NotFound();
            }

            return Ok(accountingBook);
        }

        // PUT: api/AccountingBooks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccountingBook([FromRoute] int id, [FromBody] AccountingBook accountingBook)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != accountingBook.Id)
            {
                return BadRequest();
            }

            _context.Entry(accountingBook).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountingBookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("Your Request Success!");
        }

        // POST: api/AccountingBooks
        [HttpPost]
        public async Task<IActionResult> PostAccountingBook([FromBody] AccountingBook accountingBook)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.AccountingBooks.Add(accountingBook);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccountingBook", new { id = accountingBook.Id }, accountingBook);
        }

        // DELETE: api/AccountingBooks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccountingBook([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var accountingBook = await _context.AccountingBooks.SingleOrDefaultAsync(m => m.Id == id);
            if (accountingBook == null)
            {
                return NotFound();
            }

            _context.AccountingBooks.Remove(accountingBook);
            await _context.SaveChangesAsync();

            return Ok(accountingBook);
        }

        private bool AccountingBookExists(int id)
        {
            return _context.AccountingBooks.Any(e => e.Id == id);
        }
    }
}