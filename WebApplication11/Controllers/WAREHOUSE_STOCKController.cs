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
    public class WAREHOUSE_STOCKController : Controller
    {
        private readonly DATABASECONTEXTT _context;

        public WAREHOUSE_STOCKController(DATABASECONTEXTT context)
        {
            _context = context;
        }

        // GET: WAREHOUSE_STOCK
        public async Task<IActionResult> Index()
        {
            var dATABASECONTEXTT = _context.WAREHOUSE_STOCK.Include(w => w.BRANCH);
            return View(await dATABASECONTEXTT.ToListAsync());
        }

        // GET: WAREHOUSE_STOCK/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.WAREHOUSE_STOCK == null)
            {
                return NotFound();
            }

            var wAREHOUSE_STOCK = await _context.WAREHOUSE_STOCK
                .Include(w => w.BRANCH)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (wAREHOUSE_STOCK == null)
            {
                return NotFound();
            }

            return View(wAREHOUSE_STOCK);
        }

        // GET: WAREHOUSE_STOCK/Create
        public IActionResult Create()
        {
            ViewData["BRANCH_ID"] = new SelectList(_context.BRANCHES, "Id", "Name");
            return View();
        }

        // POST: WAREHOUSE_STOCK/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,CODE,Type,NOTE,BRANCH_ID")] WAREHOUSE_STOCK wAREHOUSE_STOCK)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wAREHOUSE_STOCK);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Device Created";
                return RedirectToAction(nameof(Index));
            }
            ViewData["BRANCH_ID"] = new SelectList(_context.BRANCHES, "Id", "Name", wAREHOUSE_STOCK.BRANCH_ID);
            return View(wAREHOUSE_STOCK);
        }

        // GET: WAREHOUSE_STOCK/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.WAREHOUSE_STOCK == null)
            {
                return NotFound();
            }

            var wAREHOUSE_STOCK = await _context.WAREHOUSE_STOCK.FindAsync(id);
            if (wAREHOUSE_STOCK == null)
            {
                return NotFound();
            }
            ViewData["BRANCH_ID"] = new SelectList(_context.BRANCHES, "Id", "Name", wAREHOUSE_STOCK.BRANCH_ID);
            return View(wAREHOUSE_STOCK);
        }

        // POST: WAREHOUSE_STOCK/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,CODE,Type,NOTE,BRANCH_ID")] WAREHOUSE_STOCK wAREHOUSE_STOCK)
        {
            if (id != wAREHOUSE_STOCK.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wAREHOUSE_STOCK);
                    await _context.SaveChangesAsync(); 
                    TempData["AlertMessage"] = "Device Updated";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WAREHOUSE_STOCKExists(wAREHOUSE_STOCK.ID))
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
            ViewData["BRANCH_ID"] = new SelectList(_context.BRANCHES, "Id", "Name", wAREHOUSE_STOCK.BRANCH_ID);
            return View(wAREHOUSE_STOCK);
        }

        // GET: WAREHOUSE_STOCK/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.WAREHOUSE_STOCK == null)
            {
                return NotFound();
            }

            var wAREHOUSE_STOCK = await _context.WAREHOUSE_STOCK
                .Include(w => w.BRANCH)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (wAREHOUSE_STOCK == null)
            {
                return NotFound();
            }

            return View(wAREHOUSE_STOCK);
        }

        // POST: WAREHOUSE_STOCK/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.WAREHOUSE_STOCK == null)
            {
                return Problem("Entity set 'DATABASECONTEXTT.WAREHOUSE_STOCK'  is null.");
            }
            var wAREHOUSE_STOCK = await _context.WAREHOUSE_STOCK.FindAsync(id);
            if (wAREHOUSE_STOCK != null)
            {
                _context.WAREHOUSE_STOCK.Remove(wAREHOUSE_STOCK);
            }
            
            await _context.SaveChangesAsync(); 
            TempData["AlertMessage"] = "Device Deleted";
            return RedirectToAction(nameof(Index));
        }

        private bool WAREHOUSE_STOCKExists(int id)
        {
          return (_context.WAREHOUSE_STOCK?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
