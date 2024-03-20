using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using exceltosql.Models;

namespace exceltosql.Controllers
{
    public class emp : Controller
    {
        private readonly Medisuite_rel2Context _context;

        public emp(Medisuite_rel2Context context)
        {
            _context = context;
        }

        // GET: emp
        public async Task<IActionResult> Index()
        {
              return _context.emp != null ? 
                          View(await _context.emp.ToListAsync()) :
                          Problem("Entity set 'Medisuite_rel2Context.emp'  is null.");
        }

        // GET: emp/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.emp == null)
            {
                return NotFound();
            }

            var emp = await _context.emp
                .FirstOrDefaultAsync(m => m.Id == id);
            if (emp == null)
            {
                return NotFound();
            }

            return View(emp);
        }

        // GET: emp/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: emp/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Gender")] emp emp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(emp);
        }

        // GET: emp/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.emp == null)
            {
                return NotFound();
            }

            var emp = await _context.emp.FindAsync(id);
            if (emp == null)
            {
                return NotFound();
            }
            return View(emp);
        }

        // POST: emp/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Gender")] emp emp)
        {
            

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    
                    
                }
                return RedirectToAction(nameof(Index));
            }
            return View(emp);
        }

        // GET: emp/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.emp == null)
            {
                return NotFound();
            }

            var emp = await _context.emp
                .FirstOrDefaultAsync(m => m.Id == id);
            if (emp == null)
            {
                return NotFound();
            }

            return View(emp);
        }

        // POST: emp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.emp == null)
            {
                return Problem("Entity set 'Medisuite_rel2Context.emp'  is null.");
            }
            var emp = await _context.emp.FindAsync(id);
            if (emp != null)
            {
                _context.emp.Remove(emp);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool empExists(int id)
        {
          return (_context.emp?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
