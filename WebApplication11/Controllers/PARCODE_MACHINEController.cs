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
    public class PARCODE_MACHINEController : Controller
    {
        private readonly DATABASECONTEXTT _context;

        public PARCODE_MACHINEController(DATABASECONTEXTT context)
        {
            _context = context;
        }

        // GET: PARCODE_MACHINE
        public async Task<IActionResult> Index()
        {
            var dATABASECONTEXTT = _context.PARCODE_MACHINES.Include(p => p.BRANCH).Include(p => p.WAREHOUSE_STOCK)
                .Where(p=>p.WAREHOUSE_STOCK.Name=="Null");
            return View(await dATABASECONTEXTT.ToListAsync());
        }
        //where(StartsWith(""))
        public async Task<IActionResult> Index1()
        {
            var dATABASECONTEXTT = _context.PARCODE_MACHINES.Include(p => p.WAREHOUSE_STOCK).Include(p => p.BRANCH)
                .Where(p=> p.WAREHOUSE_STOCK.Name !="Null");
            return View(await dATABASECONTEXTT.ToListAsync());
        }
        // GET: PARCODE_MACHINE/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PARCODE_MACHINES == null)
            {
                return NotFound();
            }

            var pARCODE_MACHINE = await _context.PARCODE_MACHINES
                .Include(p => p.BRANCH)
                .Include(p => p.WAREHOUSE_STOCK)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pARCODE_MACHINE == null)
            {
                return NotFound();
            }

            return View(pARCODE_MACHINE);
        }

        // GET: PARCODE_MACHINE/Create
        public IActionResult Create()
        {
            ViewData["BRANCH_ID"] = new SelectList(_context.BRANCHES, "Id", "Name");
            ViewData["WAREHOUSE_STOCK_ID"] = new SelectList(_context.WAREHOUSE_STOCK, "ID", "Name");
            return View();
        }

        // POST: PARCODE_MACHINE/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CODE,MODEL,TYPE,SERIAL_NUMBER,Is_Warehouse,NOTE,BRANCH_ID,WAREHOUSE_STOCK_ID")] PARCODE_MACHINE pARCODE_MACHINE)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pARCODE_MACHINE);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Device Created";
                return RedirectToAction(nameof(Index));
            }
            ViewData["BRANCH_ID"] = new SelectList(_context.BRANCHES, "Id", "Name", pARCODE_MACHINE.BRANCH_ID);
            ViewData["WAREHOUSE_STOCK_ID"] = new SelectList(_context.WAREHOUSE_STOCK, "ID", "Name", pARCODE_MACHINE.WAREHOUSE_STOCK_ID);
            return View(pARCODE_MACHINE);
        }

        // GET: PARCODE_MACHINE/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PARCODE_MACHINES == null)
            {
                return NotFound();
            }

            var pARCODE_MACHINE = await _context.PARCODE_MACHINES.FindAsync(id);
            if (pARCODE_MACHINE == null)
            {
                return NotFound();
            }
            ViewData["BRANCH_ID"] = new SelectList(_context.BRANCHES, "Id", "Name", pARCODE_MACHINE.BRANCH_ID);
            ViewData["WAREHOUSE_STOCK_ID"] = new SelectList(_context.WAREHOUSE_STOCK, "ID", "Name", pARCODE_MACHINE.WAREHOUSE_STOCK_ID);
            return View(pARCODE_MACHINE);
        }

        // POST: PARCODE_MACHINE/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,CODE,MODEL,TYPE,SERIAL_NUMBER,Is_Warehouse,NOTE,BRANCH_ID,WAREHOUSE_STOCK_ID")] PARCODE_MACHINE pARCODE_MACHINE)
        {
            if (id != pARCODE_MACHINE.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pARCODE_MACHINE);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PARCODE_MACHINEExists(pARCODE_MACHINE.ID))
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
            ViewData["BRANCH_ID"] = new SelectList(_context.BRANCHES, "Id", "Name", pARCODE_MACHINE.BRANCH_ID);
            ViewData["WAREHOUSE_STOCK_ID"] = new SelectList(_context.WAREHOUSE_STOCK, "ID", "Name", pARCODE_MACHINE.WAREHOUSE_STOCK_ID);
            return View(pARCODE_MACHINE);
        }

        // GET: PARCODE_MACHINE/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PARCODE_MACHINES == null)
            {
                return NotFound();
            }

            var pARCODE_MACHINE = await _context.PARCODE_MACHINES
                .Include(p => p.BRANCH)
                .Include(p => p.WAREHOUSE_STOCK)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pARCODE_MACHINE == null)
            {
                return NotFound();
            }

            return View(pARCODE_MACHINE);
        }

        // POST: PARCODE_MACHINE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PARCODE_MACHINES == null)
            {
                return Problem("Entity set 'DATABASECONTEXTT.PARCODE_MACHINES'  is null.");
            }
            var pARCODE_MACHINE = await _context.PARCODE_MACHINES.FindAsync(id);
            if (pARCODE_MACHINE != null)
            {
                _context.PARCODE_MACHINES.Remove(pARCODE_MACHINE);
            }
            
            await _context.SaveChangesAsync();
            TempData["AlertMessage"] = "Device Deleted";
            return RedirectToAction(nameof(Index));
        }

        private bool PARCODE_MACHINEExists(int id)
        {
          return (_context.PARCODE_MACHINES?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
