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
    public class ROUTERsController : Controller
    {
        private readonly DATABASECONTEXTT _context;

        public ROUTERsController(DATABASECONTEXTT context)
        {
            _context = context;
        }

        // GET: ROUTERs
        public async Task<IActionResult> Index()
        {
            var dATABASECONTEXTT = _context.ROUTERS.Include(r => r.BRANCH)
                .Include(r => r.WAREHOUSE_STOCK).Where(r=>r.WAREHOUSE_STOCK.Name=="Null");
            return View(await dATABASECONTEXTT.ToListAsync());
        }


        public async Task<IActionResult> Index1()
        {
            var dATABASECONTEXTT = _context?.ROUTERS?.Include(r => r.WAREHOUSE_STOCK).Include(r=>r.BRANCH)
                .Where(r=>r.WAREHOUSE_STOCK.Name !="Null");
            return View(await dATABASECONTEXTT.ToListAsync());
        }

        // GET: ROUTERs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ROUTERS == null)
            {
                return NotFound();
            }

            var rOUTER = await _context.ROUTERS
                .Include(r => r.BRANCH)
                .Include(r => r.WAREHOUSE_STOCK)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rOUTER == null)
            {
                return NotFound();
            }

            return View(rOUTER);
        }

        // GET: ROUTERs/Create
        public IActionResult Create()
        {
            ViewData["BRANCH_ID"] = new SelectList(_context.BRANCHES, "Id", "Name");
            ViewData["WAREHOUSE_STOCK_ID"] = new SelectList(_context.WAREHOUSE_STOCK, "ID", "Name");
            return View();
        }

        // POST: ROUTERs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CODE,SERIAL_NUMBER,LOCATION,NUMBER_OF_PORTS,SERVICES,IP_ADDRESS,MAC_ADDRESS,is_warehouse,NOTE,BRANCH_ID,WAREHOUSE_STOCK_ID")] ROUTER rOUTER)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rOUTER);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Device Created";
                return RedirectToAction(nameof(Index));
            }
            ViewData["BRANCH_ID"] = new SelectList(_context.BRANCHES, "Id", "Name", rOUTER.BRANCH_ID);
            ViewData["WAREHOUSE_STOCK_ID"] = new SelectList(_context.WAREHOUSE_STOCK, "ID", "Name", rOUTER.WAREHOUSE_STOCK_ID);
            return View(rOUTER);
        }

        // GET: ROUTERs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ROUTERS == null)
            {
                return NotFound();
            }

            var rOUTER = await _context.ROUTERS.FindAsync(id);
            if (rOUTER == null)
            {
                return NotFound();
            }
            ViewData["BRANCH_ID"] = new SelectList(_context.BRANCHES, "Id", "Name", rOUTER.BRANCH_ID);
            ViewData["WAREHOUSE_STOCK_ID"] = new SelectList(_context.WAREHOUSE_STOCK, "ID", "Name", rOUTER.WAREHOUSE_STOCK_ID);
            return View(rOUTER);
        }

        // POST: ROUTERs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CODE,SERIAL_NUMBER,LOCATION,NUMBER_OF_PORTS,SERVICES,IP_ADDRESS,MAC_ADDRESS,is_warehouse,NOTE,BRANCH_ID,WAREHOUSE_STOCK_ID")] ROUTER rOUTER)
        {
            if (id != rOUTER.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rOUTER);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage"] = "Device Updated";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ROUTERExists(rOUTER.Id))
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
            ViewData["BRANCH_ID"] = new SelectList(_context.BRANCHES, "Id", "Name", rOUTER.BRANCH_ID);
            ViewData["WAREHOUSE_STOCK_ID"] = new SelectList(_context.WAREHOUSE_STOCK, "ID", "Name", rOUTER.WAREHOUSE_STOCK_ID);
            return View(rOUTER);
        }

        // GET: ROUTERs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ROUTERS == null)
            {
                return NotFound();
            }

            var rOUTER = await _context.ROUTERS
                .Include(r => r.BRANCH)
                .Include(r => r.WAREHOUSE_STOCK)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rOUTER == null)
            {
                return NotFound();
            }

            return View(rOUTER);
        }

        // POST: ROUTERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ROUTERS == null)
            {
                return Problem("Entity set 'DATABASECONTEXTT.ROUTERS'  is null.");
            }
            var rOUTER = await _context.ROUTERS.FindAsync(id);
            if (rOUTER != null)
            {
                _context.ROUTERS.Remove(rOUTER);
            }
            
            await _context.SaveChangesAsync();
            TempData["AlertMessage"] = "Device Deleted";
            return RedirectToAction(nameof(Index));
        }

        private bool ROUTERExists(int id)
        {
          return (_context.ROUTERS?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
