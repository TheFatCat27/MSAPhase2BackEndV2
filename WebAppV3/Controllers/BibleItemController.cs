using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppV3.Models;

namespace WebAppV3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BibleItemController : ControllerBase
    {
        private readonly BibleContext _context;

        public BibleItemController(BibleContext context)
        {
            _context = context;
        }

        // GET: api/BibleItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BibleItem>>> GetBibleItems()
        {
          if (_context.BibleItems == null)
          {
              return NotFound();
          }
            return await _context.BibleItems.ToListAsync();
        }

        // GET: api/BibleItem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BibleItem>> GetBibleItem(long id)
        {
          if (_context.BibleItems == null)
          {
              return NotFound();
          }
            var bibleItem = await _context.BibleItems.FindAsync(id);

            if (bibleItem == null)
            {
                return NotFound();
            }

            return bibleItem;
        }

        // PUT: api/BibleItem/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBibleItem(long id, BibleItem bibleItem)
        {
            if (id != bibleItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(bibleItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BibleItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BibleItem
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BibleItem>> PostBibleItem(BibleItem bibleItem)
        {
          if (_context.BibleItems == null)
          {
              return Problem("Entity set 'BibleContext.BibleItems'  is null.");
          }
            _context.BibleItems.Add(bibleItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBibleItem", new { id = bibleItem.Id }, bibleItem);
        }

        // DELETE: api/BibleItem/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBibleItem(long id)
        {
            if (_context.BibleItems == null)
            {
                return NotFound();
            }
            var bibleItem = await _context.BibleItems.FindAsync(id);
            if (bibleItem == null)
            {
                return NotFound();
            }

            _context.BibleItems.Remove(bibleItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BibleItemExists(long id)
        {
            return (_context.BibleItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
