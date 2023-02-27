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
    public class PROJECTORsController : Controller
    {
        private readonly DATABASECONTEXTT _context;

        public PROJECTORsController(DATABASECONTEXTT context)
        {
            _context = context;
        }

        // GET: PROJECTORs
        public async Task<IActionResult> Index()
        {
            var dATABASECONTEXTT = _context.PROJECTORS.Include(p => p.BRANCH).Include(p => p.WAREHOUSE_STOCK)
                .Where(p=>p.WAREHOUSE_STOCK.Name=="Null");
            return View(await dATABASECONTEXTT.ToListAsync());
        }


        public async Task<IActionResult> Index1()
        {
            var dATABASECONTEXTT = _context.PROJECTORS.Include(p => p.WAREHOUSE_STOCK).Include(p => p.BRANCH)
                .Where(p=>p.WAREHOUSE_STOCK.Name !="Null");
            return View(await dATABASECONTEXTT.ToListAsync());
        }
        // GET: PROJECTORs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PROJECTORS == null)
            {
                return NotFound();
            }

            var pROJECTOR = await _context.PROJECTORS
                .Include(p => p.BRANCH)
                .Include(p => p.WAREHOUSE_STOCK)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pROJECTOR == null)
            {
                return NotFound();
            }

            return View(pROJECTOR);
        }

        // GET: PROJECTORs/Create
        public IActionResult Create()
        {
            ViewData["BRANCH_ID"] = new SelectList(_context.BRANCHES, "Id", "Name");
            ViewData["WAREHOUSE_STOCK_ID"] = new SelectList(_context.WAREHOUSE_STOCK, "ID", "Name");
            return View();
        }

        // POST: PROJECTORs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CODE,TYPE,SERIAL_NUMBER,IS_Warehouse,NOTE,BRANCH_ID,WAREHOUSE_STOCK_ID")] PROJECTOR pROJECTOR)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pROJECTOR);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Device Created";
                return RedirectToAction(nameof(Index));
            }
            ViewData["BRANCH_ID"] = new SelectList(_context.BRANCHES, "Id", "Name", pROJECTOR.BRANCH_ID);
            ViewData["WAREHOUSE_STOCK_ID"] = new SelectList(_context.WAREHOUSE_STOCK, "ID", "Name", pROJECTOR.WAREHOUSE_STOCK_ID);
            return View(pROJECTOR);
        }

        // GET: PROJECTORs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PROJECTORS == null)
            {
                return NotFound();
            }

            var pROJECTOR = await _context.PROJECTORS.FindAsync(id);
            if (pROJECTOR == null)
            {
                return NotFound();
            }
            ViewData["BRANCH_ID"] = new SelectList(_context.BRANCHES, "Id", "Name", pROJECTOR.BRANCH_ID);
            ViewData["WAREHOUSE_STOCK_ID"] = new SelectList(_context.WAREHOUSE_STOCK, "ID", "Name", pROJECTOR.WAREHOUSE_STOCK_ID);
            return View(pROJECTOR);
        }

        // POST: PROJECTORs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CODE,TYPE,SERIAL_NUMBER,IS_Warehouse,NOTE,BRANCH_ID,WAREHOUSE_STOCK_ID")] PROJECTOR pROJECTOR)
        {
            if (id != pROJECTOR.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pROJECTOR);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage"] = "Device Updated";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PROJECTORExists(pROJECTOR.Id))
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
            ViewData["BRANCH_ID"] = new SelectList(_context.BRANCHES, "Id", "Name", pROJECTOR.BRANCH_ID);
            ViewData["WAREHOUSE_STOCK_ID"] = new SelectList(_context.WAREHOUSE_STOCK, "ID", "Name", pROJECTOR.WAREHOUSE_STOCK_ID);
            return View(pROJECTOR);
        }

        // GET: PROJECTORs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PROJECTORS == null)
            {
                return NotFound();
            }

            var pROJECTOR = await _context.PROJECTORS
                .Include(p => p.BRANCH)
                .Include(p => p.WAREHOUSE_STOCK)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pROJECTOR == null)
            {
                return NotFound();
            }

            return View(pROJECTOR);
        }

        // POST: PROJECTORs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PROJECTORS == null)
            {
                return Problem("Entity set 'DATABASECONTEXTT.PROJECTORS'  is null.");
            }
            var pROJECTOR = await _context.PROJECTORS.FindAsync(id);
            if (pROJECTOR != null)
            {
                _context.PROJECTORS.Remove(pROJECTOR);
            }
            
            await _context.SaveChangesAsync();
            TempData["AlertMessage"] = "Device Deleted";
            return RedirectToAction(nameof(Index));
        }

        private bool PROJECTORExists(int id)
        {
          return (_context.PROJECTORS?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
