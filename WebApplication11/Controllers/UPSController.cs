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
    public class UPSController : Controller
    {
        private readonly DATABASECONTEXTT _context;

        public UPSController(DATABASECONTEXTT context)
        {
            _context = context;
        }

        // GET: UPS
        public async Task<IActionResult> Index()
        {
            var dATABASECONTEXTT = _context.UPSES.Include(u => u.BRANCH)
                .Include(u => u.WAREHOUSE_STOCK).Where(u=>u.WAREHOUSE_STOCK.Name=="Null");
            return View(await dATABASECONTEXTT.ToListAsync());
        }

        public async Task<IActionResult> Index1()
        {
            var dATABASECONTEXTT = _context.UPSES.Include(u => u.WAREHOUSE_STOCK).Include(u => u.BRANCH)
                .Where(u=>u.WAREHOUSE_STOCK.Name !="Null");
            return View(await dATABASECONTEXTT.ToListAsync());
        }

        // GET: UPS/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UPSES == null)
            {
                return NotFound();
            }

            var uPS = await _context.UPSES
                .Include(u => u.BRANCH)
                .Include(u => u.WAREHOUSE_STOCK)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (uPS == null)
            {
                return NotFound();
            }

            return View(uPS);
        }

        // GET: UPS/Create
        public IActionResult Create()
        {
            ViewData["BRANCH_ID"] = new SelectList(_context.BRANCHES, "Id", "Name");
            ViewData["WAREHOUSE_STOCK_ID"] = new SelectList(_context.WAREHOUSE_STOCK, "ID", "Name");
            return View();
        }

        // POST: UPS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CODE,TYPE,SERIAL_NUMBER,CAPASTY,is_warehouse,LOCATION,NOTE,BRANCH_ID,WAREHOUSE_STOCK_ID")] UPS uPS)
        {
            if (ModelState.IsValid)
            {
                _context.Add(uPS);
                await _context.SaveChangesAsync(); 
                TempData["AlertMessage"] = "Device Created";
                return RedirectToAction(nameof(Index));
            }
            ViewData["BRANCH_ID"] = new SelectList(_context.BRANCHES, "Id", "Name", uPS.BRANCH_ID);
            ViewData["WAREHOUSE_STOCK_ID"] = new SelectList(_context.WAREHOUSE_STOCK, "ID", "Name", uPS.WAREHOUSE_STOCK_ID);
            return View(uPS);
        }

        // GET: UPS/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UPSES == null)
            {
                return NotFound();
            }

            var uPS = await _context.UPSES.FindAsync(id);
            if (uPS == null)
            {
                return NotFound();
            }
            ViewData["BRANCH_ID"] = new SelectList(_context.BRANCHES, "Id", "Name", uPS.BRANCH_ID);
            ViewData["WAREHOUSE_STOCK_ID"] = new SelectList(_context.WAREHOUSE_STOCK, "ID", "Name", uPS.WAREHOUSE_STOCK_ID);
            return View(uPS);
        }

        // POST: UPS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CODE,TYPE,SERIAL_NUMBER,CAPASTY,is_warehouse,LOCATION,NOTE,BRANCH_ID,WAREHOUSE_STOCK_ID")] UPS uPS)
        {
            if (id != uPS.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uPS);
                    await _context.SaveChangesAsync(); TempData["AlertMessage"] = "Device Updated";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UPSExists(uPS.Id))
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
            ViewData["BRANCH_ID"] = new SelectList(_context.BRANCHES, "Id", "Name", uPS.BRANCH_ID);
            ViewData["WAREHOUSE_STOCK_ID"] = new SelectList(_context.WAREHOUSE_STOCK, "ID", "Name", uPS.WAREHOUSE_STOCK_ID);
            return View(uPS);
        }

        // GET: UPS/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UPSES == null)
            {
                return NotFound();
            }

            var uPS = await _context.UPSES
                .Include(u => u.BRANCH)
                .Include(u => u.WAREHOUSE_STOCK)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (uPS == null)
            {
                return NotFound();
            }

            return View(uPS);
        }

        // POST: UPS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UPSES == null)
            {
                return Problem("Entity set 'DATABASECONTEXTT.UPSES'  is null.");
            }
            var uPS = await _context.UPSES.FindAsync(id);
            if (uPS != null)
            {
                _context.UPSES.Remove(uPS);
            }
            
            await _context.SaveChangesAsync();
            TempData["AlertMessage"] = "Device Deleted";
            return RedirectToAction(nameof(Index));
        }

        private bool UPSExists(int id)
        {
          return (_context.UPSES?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
