using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using A2_updated_p1.Models;

namespace A2_updated_p1.Controllers
{
    public class FAQsController : Controller
    {
        private readonly AppDbContext _context;

        public FAQsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: FAQs
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.FAQs.Include(f => f.Category).Include(f => f.Topic);
            return View(await appDbContext.ToListAsync());
        }

        // GET: FAQs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FAQs == null)
            {
                return NotFound();
            }

            var fAQ = await _context.FAQs
                .Include(f => f.Category)
                .Include(f => f.Topic)
                .FirstOrDefaultAsync(m => m.FAQId == id);
            if (fAQ == null)
            {
                return NotFound();
            }

            return View(fAQ);
        }

        // GET: FAQs/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId");
            ViewData["TopicId"] = new SelectList(_context.Topics, "TopicId", "TopicId");
            return View();
        }

        // POST: FAQs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FAQId,Question,Answer,TopicId,CategoryId")] FAQ fAQ)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fAQ);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", fAQ.CategoryId);
            ViewData["TopicId"] = new SelectList(_context.Topics, "TopicId", "TopicId", fAQ.TopicId);
            return View(fAQ);
        }

        // GET: FAQs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FAQs == null)
            {
                return NotFound();
            }

            var fAQ = await _context.FAQs.FindAsync(id);
            if (fAQ == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", fAQ.CategoryId);
            ViewData["TopicId"] = new SelectList(_context.Topics, "TopicId", "TopicId", fAQ.TopicId);
            return View(fAQ);
        }

        // POST: FAQs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FAQId,Question,Answer,TopicId,CategoryId")] FAQ fAQ)
        {
            if (id != fAQ.FAQId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fAQ);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FAQExists(fAQ.FAQId))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", fAQ.CategoryId);
            ViewData["TopicId"] = new SelectList(_context.Topics, "TopicId", "TopicId", fAQ.TopicId);
            return View(fAQ);
        }

        // GET: FAQs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FAQs == null)
            {
                return NotFound();
            }

            var fAQ = await _context.FAQs
                .Include(f => f.Category)
                .Include(f => f.Topic)
                .FirstOrDefaultAsync(m => m.FAQId == id);
            if (fAQ == null)
            {
                return NotFound();
            }

            return View(fAQ);
        }

        // POST: FAQs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FAQs == null)
            {
                return Problem("Entity set 'AppDbContext.FAQs'  is null.");
            }
            var fAQ = await _context.FAQs.FindAsync(id);
            if (fAQ != null)
            {
                _context.FAQs.Remove(fAQ);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FAQExists(int id)
        {
          return (_context.FAQs?.Any(e => e.FAQId == id)).GetValueOrDefault();
        }
    }
}
