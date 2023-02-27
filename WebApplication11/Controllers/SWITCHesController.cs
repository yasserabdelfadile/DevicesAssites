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
    public class SWITCHesController : Controller
    {
        private readonly DATABASECONTEXTT _context;

        public SWITCHesController(DATABASECONTEXTT context)
        {
            _context = context;
        }

        // GET: SWITCHes
        public async Task<IActionResult> Index()
        {
            var dATABASECONTEXTT = _context.SWITCHS.Include(s => s.BRANCH)
                .Include(s => s.WAREHOUSE_STOCK).Where(s=>s.WAREHOUSE_STOCK.Name=="Null");
            return View(await dATABASECONTEXTT.ToListAsync());
        }

        public async Task<IActionResult> Index1()
        {
            var dATABASECONTEXTT = _context?.SWITCHS?.Include(s => s.WAREHOUSE_STOCK).Include(s=>s.BRANCH)
                .Where(s=> s.WAREHOUSE_STOCK.Name !="Null");
            return View(await dATABASECONTEXTT.ToListAsync());
        }

        // GET: SWITCHes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SWITCHS == null)
            {
                return NotFound();
            }

            var sWITCH = await _context.SWITCHS
                .Include(s => s.BRANCH)
                .Include(s => s.WAREHOUSE_STOCK)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sWITCH == null)
            {
                return NotFound();
            }

            return View(sWITCH);
        }

        // GET: SWITCHes/Create
        public IActionResult Create()
        {
            ViewData["BRANCH_ID"] = new SelectList(_context.BRANCHES, "Id", "Name");
            ViewData["WAREHOUSE_STOCK_ID"] = new SelectList(_context.WAREHOUSE_STOCK, "ID", "Name");
            return View();
        }

        // POST: SWITCHes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,CODE,TYPE,SERIAL_NUMBER,LOCATION,NUMBER_OF_PORTS,ADDTIONAL_PORTS,IP_ADDRESS,is_warehouse,NOTE,WAREHOUSE_STOCK_ID,BRANCH_ID")] SWITCH sWITCH)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sWITCH);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Device Created";
                return RedirectToAction(nameof(Index));
            }
            ViewData["BRANCH_ID"] = new SelectList(_context.BRANCHES, "Id", "Name", sWITCH.BRANCH_ID);
            ViewData["WAREHOUSE_STOCK_ID"] = new SelectList(_context.WAREHOUSE_STOCK, "ID", "Name", sWITCH.WAREHOUSE_STOCK_ID);
            return View(sWITCH);
        }

        // GET: SWITCHes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SWITCHS == null)
            {
                return NotFound();
            }

            var sWITCH = await _context.SWITCHS.FindAsync(id);
            if (sWITCH == null)
            {
                return NotFound();
            }
            ViewData["BRANCH_ID"] = new SelectList(_context.BRANCHES, "Id", "Name", sWITCH.BRANCH_ID);
            ViewData["WAREHOUSE_STOCK_ID"] = new SelectList(_context.WAREHOUSE_STOCK, "ID", "Name", sWITCH.WAREHOUSE_STOCK_ID);
            return View(sWITCH);
        }

        // POST: SWITCHes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,CODE,TYPE,SERIAL_NUMBER,LOCATION,NUMBER_OF_PORTS,ADDTIONAL_PORTS,IP_ADDRESS,is_warehouse,NOTE,WAREHOUSE_STOCK_ID,BRANCH_ID")] SWITCH sWITCH)
        {
            if (id != sWITCH.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sWITCH);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage"] = "Device Updated";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SWITCHExists(sWITCH.ID))
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
            ViewData["BRANCH_ID"] = new SelectList(_context.BRANCHES, "Id", "Name", sWITCH.BRANCH_ID);
            ViewData["WAREHOUSE_STOCK_ID"] = new SelectList(_context.WAREHOUSE_STOCK, "ID", "Name", sWITCH.WAREHOUSE_STOCK_ID);
            return View(sWITCH);
        }

        // GET: SWITCHes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SWITCHS == null)
            {
                return NotFound();
            }

            var sWITCH = await _context.SWITCHS
                .Include(s => s.BRANCH)
                .Include(s => s.WAREHOUSE_STOCK)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (sWITCH == null)
            {
                return NotFound();
            }

            return View(sWITCH);
        }

        // POST: SWITCHes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SWITCHS == null)
            {
                return Problem("Entity set 'DATABASECONTEXTT.SWITCHS'  is null.");
            }
            var sWITCH = await _context.SWITCHS.FindAsync(id);
            if (sWITCH != null)
            {
                _context.SWITCHS.Remove(sWITCH);
            }
            
            await _context.SaveChangesAsync();
            TempData["AlertMessage"] = "Device Deleted";
            return RedirectToAction(nameof(Index));
        }

        private bool SWITCHExists(int id)
        {
          return (_context.SWITCHS?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
