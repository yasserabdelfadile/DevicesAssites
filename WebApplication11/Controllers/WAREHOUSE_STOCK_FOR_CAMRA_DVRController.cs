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
    public class WAREHOUSE_STOCK_FOR_CAMRA_DVRController : Controller
    {
        private readonly DATABASECONTEXTT _context;

        public WAREHOUSE_STOCK_FOR_CAMRA_DVRController(DATABASECONTEXTT context)
        {
            _context = context;
        }

        // GET: WAREHOUSE_STOCK_FOR_CAMRA_DVR
        public async Task<IActionResult> Index()
        {
            var dATABASECONTEXTT = _context.WAREHOUSE_STOCK_FOR_CAMRA_DVRS.Include(w => w.BRANCH);
            return View(await dATABASECONTEXTT.ToListAsync());
        }

        // GET: WAREHOUSE_STOCK_FOR_CAMRA_DVR/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.WAREHOUSE_STOCK_FOR_CAMRA_DVRS == null)
            {
                return NotFound();
            }

            var WAREHOUSE_STOCK_FOR_CAMRA_DVR = await _context.WAREHOUSE_STOCK_FOR_CAMRA_DVRS
                .Include(w => w.BRANCH)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (WAREHOUSE_STOCK_FOR_CAMRA_DVR == null)
            {
                return NotFound();
            }

            return View(WAREHOUSE_STOCK_FOR_CAMRA_DVR);
        }

        // GET: WAREHOUSE_STOCK_FOR_CAMRA_DVR/Create
        public IActionResult Create()
        {
            ViewData["BRANCH_ID"] = new SelectList(_context.BRANCHES, "Id", "Name");
            return View();
        }

        // POST: WAREHOUSE_STOCK_FOR_CAMRA_DVR/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,CODE,TYPE,NOTE,BRANCH_ID")] WAREHOUSE_STOCK_FOR_CAMRA_DVR WAREHOUSE_STOCK_FOR_CAMRA_DVR)
        {
            try
            {
                 if (ModelState.IsValid)
                            {
                                _context.Add(WAREHOUSE_STOCK_FOR_CAMRA_DVR);
                                await _context.SaveChangesAsync();
                    TempData["AlertMessage"] = "Device Created";
                    return RedirectToAction(nameof(Index));
                            }
            }

            catch (Exception ex)
            {
                if(ex.InnerException.Message.Contains("IX_"))
                {
                    ModelState.AddModelError("", "the vluae alerdy existed (dulpicate note allow :try another value Code )");
                }
                else
                {
                    ModelState.AddModelError("", "Can Not Delete Device");
                }


            }



           
            ViewData["BRANCH_ID"] = new SelectList(_context.BRANCHES, "Id", "Name", WAREHOUSE_STOCK_FOR_CAMRA_DVR.BRANCH_ID);
            return View(WAREHOUSE_STOCK_FOR_CAMRA_DVR);
        }

        // GET: WAREHOUSE_STOCK_FOR_CAMRA_DVR/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.WAREHOUSE_STOCK_FOR_CAMRA_DVRS == null)
            {
                return NotFound();
            }

            var WAREHOUSE_STOCK_FOR_CAMRA_DVR = await _context.WAREHOUSE_STOCK_FOR_CAMRA_DVRS.FindAsync(id);
            if (WAREHOUSE_STOCK_FOR_CAMRA_DVR == null)
            {
                return NotFound();
            }
            ViewData["BRANCH_ID"] = new SelectList(_context.BRANCHES, "Id", "Name", WAREHOUSE_STOCK_FOR_CAMRA_DVR.BRANCH_ID);
            return View(WAREHOUSE_STOCK_FOR_CAMRA_DVR);
        }

        // POST: WAREHOUSE_STOCK_FOR_CAMRA_DVR/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,CODE,TYPE,NOTE,BRANCH_ID")] WAREHOUSE_STOCK_FOR_CAMRA_DVR WAREHOUSE_STOCK_FOR_CAMRA_DVR)
        {
            if (id != WAREHOUSE_STOCK_FOR_CAMRA_DVR.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(WAREHOUSE_STOCK_FOR_CAMRA_DVR);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage"] = "Device Updated";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WAREHOUSE_STOCK_FOR_CAMRA_DVRExists(WAREHOUSE_STOCK_FOR_CAMRA_DVR.ID))
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
            ViewData["BRANCH_ID"] = new SelectList(_context.BRANCHES, "Id", "Name", WAREHOUSE_STOCK_FOR_CAMRA_DVR.BRANCH_ID);
            return View(WAREHOUSE_STOCK_FOR_CAMRA_DVR);
        }

        // GET: WAREHOUSE_STOCK_FOR_CAMRA_DVR/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.WAREHOUSE_STOCK_FOR_CAMRA_DVRS == null)
            {
                return NotFound();
            }

            var WAREHOUSE_STOCK_FOR_CAMRA_DVR = await _context.WAREHOUSE_STOCK_FOR_CAMRA_DVRS
                .Include(w => w.BRANCH)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (WAREHOUSE_STOCK_FOR_CAMRA_DVR == null)
            {
                return NotFound();
            }

            return View(WAREHOUSE_STOCK_FOR_CAMRA_DVR);
        }

        // POST: WAREHOUSE_STOCK_FOR_CAMRA_DVR/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.WAREHOUSE_STOCK_FOR_CAMRA_DVRS == null)
            {
                return Problem("Entity set 'DATABASECONTEXTT.WAREHOUSE_STOCK_FOR_CAMRA_DVRS'  is null.");
            }
            var WAREHOUSE_STOCK_FOR_CAMRA_DVR = await _context.WAREHOUSE_STOCK_FOR_CAMRA_DVRS.FindAsync(id);
            if (WAREHOUSE_STOCK_FOR_CAMRA_DVR != null)
            {
                _context.WAREHOUSE_STOCK_FOR_CAMRA_DVRS.Remove(WAREHOUSE_STOCK_FOR_CAMRA_DVR);
            }
            
            await _context.SaveChangesAsync();
            TempData["AlertMessage"] = "Device Deleted";
            return RedirectToAction(nameof(Index));
        }

        private bool WAREHOUSE_STOCK_FOR_CAMRA_DVRExists(int id)
        {
          return (_context.WAREHOUSE_STOCK_FOR_CAMRA_DVRS?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
