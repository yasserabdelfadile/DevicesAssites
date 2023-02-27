using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication11.Models;

namespace WebApplication11.Controllers
{
    [Authorize(Roles = "User")]
    public class DEPARTMENTsController : Controller
    {
        private readonly DATABASECONTEXTT _context;

        public DEPARTMENTsController(DATABASECONTEXTT context)
        {
            _context = context;
        }

        // GET: DEPARTMENTs
        public async Task<IActionResult> Index()
        {
            var dATABASECONTEXTT = _context.DEPARTMENTS.Include(d => d.BRANCH);
            return View(await dATABASECONTEXTT.ToListAsync());
        }

        // GET: DEPARTMENTs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DEPARTMENTS == null)
            {
                return NotFound();
            }

            var dEPARTMENT = await _context.DEPARTMENTS
                .Include(d => d.BRANCH)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dEPARTMENT == null)
            {
                return NotFound();
            }

            return View(dEPARTMENT);
        }

        // GET: DEPARTMENTs/Create
        public IActionResult Create()
        {
            ViewData["BRANCH_ID"] = new SelectList(_context.BRANCHES, "Id", "Name");
            return View();
        }

        // POST: DEPARTMENTs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,CODE,PHONE,EMAIL,NOTE,Description,BRANCH_ID")] DEPARTMENT dEPARTMENT)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dEPARTMENT);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Device Created";
                return RedirectToAction(nameof(Index));
            }
            ViewData["BRANCH_ID"] = new SelectList(_context.BRANCHES, "Id", "Name", dEPARTMENT.BRANCH_ID);
            return View(dEPARTMENT);
        }

        // GET: DEPARTMENTs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DEPARTMENTS == null)
            {
                return NotFound();
            }

            var dEPARTMENT = await _context.DEPARTMENTS.FindAsync(id);
            if (dEPARTMENT == null)
            {
                return NotFound();
            }
            ViewData["BRANCH_ID"] = new SelectList(_context.BRANCHES, "Id", "Name", dEPARTMENT.BRANCH_ID);
            return View(dEPARTMENT);
        }

        // POST: DEPARTMENTs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,CODE,PHONE,EMAIL,NOTE,Description,BRANCH_ID")] DEPARTMENT dEPARTMENT)
        {
            if (id != dEPARTMENT.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dEPARTMENT);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DEPARTMENTExists(dEPARTMENT.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["AlertMessage"] = "Device Updated";
                return RedirectToAction(nameof(Index));
            }
            ViewData["BRANCH_ID"] = new SelectList(_context.BRANCHES, "Id", "Name", dEPARTMENT.BRANCH_ID);
            return View(dEPARTMENT);
        }

        // GET: DEPARTMENTs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DEPARTMENTS == null)
            {
                return NotFound();
            }

            var dEPARTMENT = await _context.DEPARTMENTS
                .Include(d => d.BRANCH)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dEPARTMENT == null)
            {
                return NotFound();
            }

            return View(dEPARTMENT);
        }

        // POST: DEPARTMENTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DEPARTMENTS == null)
            {
                return Problem("Entity set 'DATABASECONTEXTT.DEPARTMENTS'  is null.");
            }
            var dEPARTMENT = await _context.DEPARTMENTS.FindAsync(id);
            if (dEPARTMENT != null)
            {
                _context.DEPARTMENTS.Remove(dEPARTMENT);
            }
            
            await _context.SaveChangesAsync();
            TempData["AlertMessage"] = "Device Deleted";
            return RedirectToAction(nameof(Index));
        }

        private bool DEPARTMENTExists(int id)
        {
          return (_context.DEPARTMENTS?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
