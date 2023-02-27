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
    public class RACKsController : Controller
    {
        private readonly DATABASECONTEXTT _context;

        public RACKsController(DATABASECONTEXTT context)
        {
            _context = context;
        }

        // GET: RACKs
        public async Task<IActionResult> Index()
        {
            var dATABASECONTEXTT = _context.RACKS.Include(r => r.BRANCH)
                .Include(r => r.WAREHOUSE_STOCK).Where(r=>r.WAREHOUSE_STOCK.Name=="Null");
            return View(await dATABASECONTEXTT.ToListAsync());
        }


        public async Task<IActionResult> Index1()
        {
            var dATABASECONTEXTT = _context.RACKS.Include(r => r.WAREHOUSE_STOCK).Include(r=>r.BRANCH)
                .Where(r=>r.WAREHOUSE_STOCK.Name !="Null");
            return View(await dATABASECONTEXTT.ToListAsync());
        }

        // GET: RACKs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RACKS == null)
            {
                return NotFound();
            }

            var rACK = await _context.RACKS
                .Include(r => r.BRANCH)
                .Include(r => r.WAREHOUSE_STOCK)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rACK == null)
            {
                return NotFound();
            }

            return View(rACK);
        }

        // GET: RACKs/Create
        public IActionResult Create()
        {
            ViewData["BRANCH_ID"] = new SelectList(_context.BRANCHES, "Id", "Name");
            ViewData["WAREHOUSE_STOCK_ID"] = new SelectList(_context.WAREHOUSE_STOCK, "ID", "Name");
            return View();
        }

        // POST: RACKs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CODE,Name,Type,LOCATION,is_warehouse,NOTE,DESCRPTION,BRANCH_ID,WAREHOUSE_STOCK_ID")] RACK rACK)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rACK);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Device Created";
                return RedirectToAction(nameof(Index));
            }
            ViewData["BRANCH_ID"] = new SelectList(_context.BRANCHES, "Id", "Name", rACK.BRANCH_ID);
            ViewData["WAREHOUSE_STOCK_ID"] = new SelectList(_context.WAREHOUSE_STOCK, "ID", "Name", rACK.WAREHOUSE_STOCK_ID);
            return View(rACK);
        }

        // GET: RACKs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RACKS == null)
            {
                return NotFound();
            }

            var rACK = await _context.RACKS.FindAsync(id);
            if (rACK == null)
            {
                return NotFound();
            }
            ViewData["BRANCH_ID"] = new SelectList(_context.BRANCHES, "Id", "Name", rACK.BRANCH_ID);
            ViewData["WAREHOUSE_STOCK_ID"] = new SelectList(_context.WAREHOUSE_STOCK, "ID", "Name", rACK.WAREHOUSE_STOCK_ID);
            return View(rACK);
        }

        // POST: RACKs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CODE,Name,Type,LOCATION,is_warehouse,NOTE,DESCRPTION,BRANCH_ID,WAREHOUSE_STOCK_ID")] RACK rACK)
        {
            if (id != rACK.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rACK);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage"] = "Device Updated";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RACKExists(rACK.Id))
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
            ViewData["BRANCH_ID"] = new SelectList(_context.BRANCHES, "Id", "Name", rACK.BRANCH_ID);
            ViewData["WAREHOUSE_STOCK_ID"] = new SelectList(_context.WAREHOUSE_STOCK, "ID", "Name", rACK.WAREHOUSE_STOCK_ID);
            return View(rACK);
        }

        // GET: RACKs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RACKS == null)
            {
                return NotFound();
            }

            var rACK = await _context.RACKS
                .Include(r => r.BRANCH)
                .Include(r => r.WAREHOUSE_STOCK)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rACK == null)
            {
                return NotFound();
            }

            return View(rACK);
        }

        // POST: RACKs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RACKS == null)
            {
                return Problem("Entity set 'DATABASECONTEXTT.RACKS'  is null.");
            }
            var rACK = await _context.RACKS.FindAsync(id);
            if (rACK != null)
            {
                _context.RACKS.Remove(rACK);
            }
            
            await _context.SaveChangesAsync();
            TempData["AlertMessage"] = "Device Deleted";
            return RedirectToAction(nameof(Index));
        }

        private bool RACKExists(int id)
        {
          return (_context.RACKS?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
