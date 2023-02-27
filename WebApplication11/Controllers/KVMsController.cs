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
    public class KVMsController : Controller
    {
        private readonly DATABASECONTEXTT _context;

        public KVMsController(DATABASECONTEXTT context)
        {
            _context = context;
        }

        // GET: KVMs
        public async Task<IActionResult> Index()
        {
            var dATABASECONTEXTT = _context.KVMS.Include(k => k.BRANCH).Include(k => k.WAREHOUSE_STOCK)
                .Where(k=>k.WAREHOUSE_STOCK.Name=="Null");
            return View(await dATABASECONTEXTT.ToListAsync());
        }

        public async Task<IActionResult> Index1()
        {
            var dATABASECONTEXTT = _context.KVMS.Include(k => k.WAREHOUSE_STOCK).Include(K=>K.BRANCH)
                .Where(k =>k.WAREHOUSE_STOCK.Name !="Null");
            return View(await dATABASECONTEXTT.ToListAsync());
        }

        // GET: KVMs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.KVMS == null)
            {
                return NotFound();
            }

            var kVM = await _context.KVMS
                .Include(k => k.BRANCH)
                .Include(k => k.WAREHOUSE_STOCK)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (kVM == null)
            {
                return NotFound();
            }

            return View(kVM);
        }

        // GET: KVMs/Create
        public IActionResult Create()
        {
            ViewData["BRANCH_ID"] = new SelectList(_context.BRANCHES, "Id", "Name");
            ViewData["WAREHOUSE_STOCK_ID"] = new SelectList(_context.WAREHOUSE_STOCK, "ID", "Name");
            return View();
        }

        // POST: KVMs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,CODE,TYPE,SERIAL_NUMBER,Is_Warehouse,NOTE,BRANCH_ID,WAREHOUSE_STOCK_ID")] KVM kVM)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kVM);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Device Created";
                return RedirectToAction(nameof(Index));
            }
            ViewData["BRANCH_ID"] = new SelectList(_context.BRANCHES, "Id", "Name", kVM.BRANCH_ID);
            ViewData["WAREHOUSE_STOCK_ID"] = new SelectList(_context.WAREHOUSE_STOCK, "ID", "Name", kVM.WAREHOUSE_STOCK_ID);
            return View(kVM);
        }

        // GET: KVMs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.KVMS == null)
            {
                return NotFound();
            }

            var kVM = await _context.KVMS.FindAsync(id);
            if (kVM == null)
            {
                return NotFound();
            }
            ViewData["BRANCH_ID"] = new SelectList(_context.BRANCHES, "Id", "Name", kVM.BRANCH_ID);
            ViewData["WAREHOUSE_STOCK_ID"] = new SelectList(_context.WAREHOUSE_STOCK, "ID", "Name", kVM.WAREHOUSE_STOCK_ID);
            return View(kVM);
        }

        // POST: KVMs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,CODE,TYPE,SERIAL_NUMBER,Is_Warehouse,NOTE,BRANCH_ID,WAREHOUSE_STOCK_ID")] KVM kVM)
        {
            if (id != kVM.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kVM);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KVMExists(kVM.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["AlertMessage"] = "Device UPdated";
                return RedirectToAction(nameof(Index));
            }
            ViewData["BRANCH_ID"] = new SelectList(_context.BRANCHES, "Id", "Name", kVM.BRANCH_ID);
            ViewData["WAREHOUSE_STOCK_ID"] = new SelectList(_context.WAREHOUSE_STOCK, "ID", "Name", kVM.WAREHOUSE_STOCK_ID);
            return View(kVM);
        }

        // GET: KVMs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.KVMS == null)
            {
                return NotFound();
            }

            var kVM = await _context.KVMS
                .Include(k => k.BRANCH)
                .Include(k => k.WAREHOUSE_STOCK)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (kVM == null)
            {
                return NotFound();
            }

            return View(kVM);
        }

        // POST: KVMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.KVMS == null)
            {
                return Problem("Entity set 'DATABASECONTEXTT.KVMS'  is null.");
            }
            var kVM = await _context.KVMS.FindAsync(id);
            if (kVM != null)
            {
                _context.KVMS.Remove(kVM);
            }
            
            await _context.SaveChangesAsync();
            TempData["AlertMessage"] = "Device Deleted";
            return RedirectToAction(nameof(Index));
        }

        private bool KVMExists(int id)
        {
          return (_context.KVMS?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
