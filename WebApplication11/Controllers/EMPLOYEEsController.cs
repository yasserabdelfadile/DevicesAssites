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
    public class EMPLOYEEsController : Controller
    {
        private readonly DATABASECONTEXTT _context;

        public EMPLOYEEsController(DATABASECONTEXTT context)
        {
            _context = context;
        }

        // GET: EMPLOYEEs
        public async Task<IActionResult> Index()
        {
            var dATABASECONTEXTT = _context.EMPLOYEES.Include(e => e.BRANCH).Include(e => e.DEPARTMENT);
            return View(await dATABASECONTEXTT.ToListAsync());
        }

        // GET: EMPLOYEEs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EMPLOYEES == null)
            {
                return NotFound();
            }

            var eMPLOYEE = await _context.EMPLOYEES
                .Include(e => e.BRANCH)
                .Include(e => e.DEPARTMENT)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (eMPLOYEE == null)
            {
                return NotFound();
            }

            return View(eMPLOYEE);
        }

        // GET: EMPLOYEEs/Create
        public IActionResult Create()
        {
            ViewData["BRANCH_ID"] = new SelectList(_context.BRANCHES, "Id", "Name");
            ViewData["DEPARTMENT_ID"] = new SelectList(_context.DEPARTMENTS, "ID", "Name");
            return View();
        }

        // POST: EMPLOYEEs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,CODE,PHONE,EMAIL,ADDRESS,NOTE,STARTEDATE,ENDDATE,BRANCH_ID,DEPARTMENT_ID")] EMPLOYEE eMPLOYEE)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eMPLOYEE);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Device Created";
                return RedirectToAction(nameof(Index));
            }
            ViewData["BRANCH_ID"] = new SelectList(_context.BRANCHES, "Id", "Name", eMPLOYEE.BRANCH_ID);
            ViewData["DEPARTMENT_ID"] = new SelectList(_context.DEPARTMENTS, "ID", "Name", eMPLOYEE.DEPARTMENT_ID);
            return View(eMPLOYEE);
        }

        // GET: EMPLOYEEs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EMPLOYEES == null)
            {
                return NotFound();
            }

            var eMPLOYEE = await _context.EMPLOYEES.FindAsync(id);
            if (eMPLOYEE == null)
            {
                return NotFound();
            }
            ViewData["BRANCH_ID"] = new SelectList(_context.BRANCHES, "Id", "Name", eMPLOYEE.BRANCH_ID);
            ViewData["DEPARTMENT_ID"] = new SelectList(_context.DEPARTMENTS, "ID", "Name", eMPLOYEE.DEPARTMENT_ID);
            return View(eMPLOYEE);
        }

        // POST: EMPLOYEEs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,CODE,PHONE,EMAIL,ADDRESS,NOTE,STARTEDATE,ENDDATE,BRANCH_ID,DEPARTMENT_ID")] EMPLOYEE eMPLOYEE)
        {
            if (id != eMPLOYEE.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eMPLOYEE);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EMPLOYEEExists(eMPLOYEE.ID))
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
            ViewData["BRANCH_ID"] = new SelectList(_context.BRANCHES, "Id", "Name", eMPLOYEE.BRANCH_ID);
            ViewData["DEPARTMENT_ID"] = new SelectList(_context.DEPARTMENTS, "ID", "Name", eMPLOYEE.DEPARTMENT_ID);
            return View(eMPLOYEE);
        }

        // GET: EMPLOYEEs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EMPLOYEES == null)
            {
                return NotFound();
            }

            var eMPLOYEE = await _context.EMPLOYEES
                .Include(e => e.BRANCH)
                .Include(e => e.DEPARTMENT)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (eMPLOYEE == null)
            {
                return NotFound();
            }

            return View(eMPLOYEE);
        }

        // POST: EMPLOYEEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EMPLOYEES == null)
            {
                return Problem("Entity set 'DATABASECONTEXTT.EMPLOYEES'  is null.");
            }
            var eMPLOYEE = await _context.EMPLOYEES.FindAsync(id);
            if (eMPLOYEE != null)
            {
                _context.EMPLOYEES.Remove(eMPLOYEE);
            }
            
            await _context.SaveChangesAsync();
            TempData["AlertMessage"] = "Device Deleted";
            return RedirectToAction(nameof(Index));
        }

        private bool EMPLOYEEExists(int id)
        {
          return (_context.EMPLOYEES?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
