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
    public class HisICD : Controller
    {
        private readonly Medisuite_rel2Context _context;

        public HisICD(Medisuite_rel2Context context)
        {
            _context = context;
        }

        // GET: HisICD
        public async Task<IActionResult> Index()
        {
              return _context.his_icd_diagnoses != null ? 
                          View(await _context.his_icd_diagnoses.ToListAsync()) :
                          Problem("Entity set 'Medisuite_rel2Context.his_icd_diagnoses'  is null.");
        }

        // GET: HisICD/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.his_icd_diagnoses == null)
            {
                return NotFound();
            }

            var his_icd_diagnosis = await _context.his_icd_diagnoses
                .FirstOrDefaultAsync(m => m.IcdID == id);
            if (his_icd_diagnosis == null)
            {
                return NotFound();
            }

            return View(his_icd_diagnosis);
        }

        // GET: HisICD/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HisICD/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IcdID,IcdCode,LD")] his_icd_diagnosis his_icd_diagnosis)
        {
            if (ModelState.IsValid)
            {
                _context.Add(his_icd_diagnosis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(his_icd_diagnosis);
        }

        // GET: HisICD/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.his_icd_diagnoses == null)
            {
                return NotFound();
            }

            var his_icd_diagnosis = await _context.his_icd_diagnoses.FindAsync(id);
            if (his_icd_diagnosis == null)
            {
                return NotFound();
            }
            return View(his_icd_diagnosis);
        }

        // POST: HisICD/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IcdID,IcdCode,LD")] his_icd_diagnosis his_icd_diagnosis)
        {
            if (id != his_icd_diagnosis.IcdID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(his_icd_diagnosis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!his_icd_diagnosisExists(his_icd_diagnosis.IcdID))
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
            return View(his_icd_diagnosis);
        }

        // GET: HisICD/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.his_icd_diagnoses == null)
            {
                return NotFound();
            }

            var his_icd_diagnosis = await _context.his_icd_diagnoses
                .FirstOrDefaultAsync(m => m.IcdID == id);
            if (his_icd_diagnosis == null)
            {
                return NotFound();
            }

            return View(his_icd_diagnosis);
        }

        // POST: HisICD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.his_icd_diagnoses == null)
            {
                return Problem("Entity set 'Medisuite_rel2Context.his_icd_diagnoses'  is null.");
            }
            var his_icd_diagnosis = await _context.his_icd_diagnoses.FindAsync(id);
            if (his_icd_diagnosis != null)
            {
                _context.his_icd_diagnoses.Remove(his_icd_diagnosis);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool his_icd_diagnosisExists(int id)
        {
          return (_context.his_icd_diagnoses?.Any(e => e.IcdID == id)).GetValueOrDefault();
        }
    }
}
