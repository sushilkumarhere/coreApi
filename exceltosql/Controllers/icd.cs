using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using exceltosql.Models;

namespace exceltosql.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class icd : ControllerBase
    {
        private readonly Medisuite_rel2Context _context;

        public icd(Medisuite_rel2Context context)
        {
            _context = context;
        }

        // GET: api/icd
        [HttpGet]
        public async Task<ActionResult<IEnumerable<his_icd_diagnosis>>> Gethis_icd_diagnoses()
        {
          if (_context.his_icd_diagnoses == null)
          {
              return NotFound();
          }
            return await _context.his_icd_diagnoses.Take(5).ToListAsync();
        }

        // GET: api/icd/5
        [HttpGet("{id}")]
        public async Task<ActionResult<his_icd_diagnosis>> Gethis_icd_diagnosis(int id)
        {
          if (_context.his_icd_diagnoses == null)
          {
              return NotFound();
          }
            var his_icd_diagnosis = await _context.his_icd_diagnoses.FindAsync(id);

            if (his_icd_diagnosis == null)
            {
                return NotFound();
            }

            return his_icd_diagnosis;
        }

        // PUT: api/icd/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Puthis_icd_diagnosis(int id, his_icd_diagnosis his_icd_diagnosis)
        {
            if (id != his_icd_diagnosis.IcdID)
            {
                return BadRequest();
            }

            _context.Entry(his_icd_diagnosis).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!his_icd_diagnosisExists(id))
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

        // POST: api/icd
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<his_icd_diagnosis>> Posthis_icd_diagnosis(his_icd_diagnosis his_icd_diagnosis)
        {
          if (_context.his_icd_diagnoses == null)
          {
              return Problem("Entity set 'Medisuite_rel2Context.his_icd_diagnoses'  is null.");
          }
            _context.his_icd_diagnoses.Add(his_icd_diagnosis);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gethis_icd_diagnosis", new { id = his_icd_diagnosis.IcdID }, his_icd_diagnosis);
        }

        // DELETE: api/icd/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletehis_icd_diagnosis(int id)
        {
            if (_context.his_icd_diagnoses == null)
            {
                return NotFound();
            }
            var his_icd_diagnosis = await _context.his_icd_diagnoses.FindAsync(id);
            if (his_icd_diagnosis == null)
            {
                return NotFound();
            }

            _context.his_icd_diagnoses.Remove(his_icd_diagnosis);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool his_icd_diagnosisExists(int id)
        {
            return (_context.his_icd_diagnoses?.Any(e => e.IcdID == id)).GetValueOrDefault();
        }
    }
}
