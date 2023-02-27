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
    public class PRINTERsController : Controller
    {
        private readonly DATABASECONTEXTT _context;

        public PRINTERsController(DATABASECONTEXTT context)
        {
            _context = context;
        }

        // GET: PRINTERs
        public async Task<IActionResult> Index()
        {
            var dATABASECONTEXTT = _context.PRINTERS.Include(p => p.BRANCH).Include(p => p.DEPARTMENT)
                .Include(p => p.WAREHOUSE_STOCK).Where(p=>p.WAREHOUSE_STOCK.Name=="Null");
            return View(await dATABASECONTEXTT.ToListAsync());
        }
        public async Task<IActionResult> Index1()
        {
            var dATABASECONTEXTT = _context.PRINTERS.Include(p => p.DEPARTMENT).Include(p => p.WAREHOUSE_STOCK).Include(p=>p.BRANCH)
                .Where(p=>p.WAREHOUSE_STOCK.Name != "Null");
            return View(await dATABASECONTEXTT.ToListAsync());
        }

        // GET: PRINTERs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PRINTERS == null)
            {
                return NotFound();
            }

            var pRINTER = await _context.PRINTERS
                .Include(p => p.BRANCH)
                .Include(p => p.DEPARTMENT)
                .Include(p => p.WAREHOUSE_STOCK)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pRINTER == null)
            {
                return NotFound();
            }

            return View(pRINTER);
        }

        // GET: PRINTERs/Create
        public IActionResult Create()
        {
            ViewData["BRANCH_ID"] = new SelectList(_context.BRANCHES, "Id", "Name");
            ViewData["DEPARTMENT_ID"] = new SelectList(_context.DEPARTMENTS, "ID", "Name");
            ViewData["WAREHOUSE_STOCK_ID"] = new SelectList(_context.WAREHOUSE_STOCK, "ID", "Name");
            return View();
        }

        // POST: PRINTERs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CODE,TYPE,SERIAL_NUMBER,Is_Warehouse,NOTE,DESCRPTION,BRANCH_ID,DEPARTMENT_ID,WAREHOUSE_STOCK_ID")] PRINTER pRINTER)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pRINTER);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Device Created";
                return RedirectToAction(nameof(Index));
            }
            ViewData["BRANCH_ID"] = new SelectList(_context.BRANCHES, "Id", "Name", pRINTER.BRANCH_ID);
            ViewData["DEPARTMENT_ID"] = new SelectList(_context.DEPARTMENTS, "ID", "Name", pRINTER.DEPARTMENT_ID);
            ViewData["WAREHOUSE_STOCK_ID"] = new SelectList(_context.WAREHOUSE_STOCK, "ID", "Name", pRINTER.WAREHOUSE_STOCK_ID);
            return View(pRINTER);
        }

        // GET: PRINTERs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PRINTERS == null)
            {
                return NotFound();
            }

            var pRINTER = await _context.PRINTERS.FindAsync(id);
            if (pRINTER == null)
            {
                return NotFound();
            }
            ViewData["BRANCH_ID"] = new SelectList(_context.BRANCHES, "Id", "Name", pRINTER.BRANCH_ID);
            ViewData["DEPARTMENT_ID"] = new SelectList(_context.DEPARTMENTS, "ID", "Name", pRINTER.DEPARTMENT_ID);
            ViewData["WAREHOUSE_STOCK_ID"] = new SelectList(_context.WAREHOUSE_STOCK, "ID", "Name", pRINTER.WAREHOUSE_STOCK_ID);
            return View(pRINTER);
        }

        // POST: PRINTERs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CODE,TYPE,SERIAL_NUMBER,Is_Warehouse,NOTE,DESCRPTION,BRANCH_ID,DEPARTMENT_ID,WAREHOUSE_STOCK_ID")] PRINTER pRINTER)
        {
            if (id != pRINTER.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pRINTER);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PRINTERExists(pRINTER.Id))
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
            ViewData["BRANCH_ID"] = new SelectList(_context.BRANCHES, "Id", "Name", pRINTER.BRANCH_ID);
            ViewData["DEPARTMENT_ID"] = new SelectList(_context.DEPARTMENTS, "ID", "Name", pRINTER.DEPARTMENT_ID);
            ViewData["WAREHOUSE_STOCK_ID"] = new SelectList(_context.WAREHOUSE_STOCK, "ID", "Name", pRINTER.WAREHOUSE_STOCK_ID);
            return View(pRINTER);
        }

        // GET: PRINTERs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PRINTERS == null)
            {
                return NotFound();
            }

            var pRINTER = await _context.PRINTERS
                .Include(p => p.BRANCH)
                .Include(p => p.DEPARTMENT)
                .Include(p => p.WAREHOUSE_STOCK)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pRINTER == null)
            {
                return NotFound();
            }

            return View(pRINTER);
        }

        // POST: PRINTERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PRINTERS == null)
            {
                return Problem("Entity set 'DATABASECONTEXTT.PRINTERS'  is null.");
            }
            var pRINTER = await _context.PRINTERS.FindAsync(id);
            if (pRINTER != null)
            {
                _context.PRINTERS.Remove(pRINTER);
            }
            
            await _context.SaveChangesAsync();
            TempData["AlertMessage"] = "Device Deleted";
            return RedirectToAction(nameof(Index));
        }

        private bool PRINTERExists(int id)
        {
          return (_context.PRINTERS?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
