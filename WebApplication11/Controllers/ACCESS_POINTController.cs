using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication11.Models;

namespace WebApplication11.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ACCESS_POINTController : Controller
    {
        private readonly DATABASECONTEXTT _context;

        public ACCESS_POINTController(DATABASECONTEXTT context)
        {
            _context = context;
        }

        // GET: ACCESS_POINT
        public async Task<IActionResult> Index()
        {
            var Resulte = _context.ACCESS_POINTS.Include(m => m.WAREHOUSE_STOCK).Include(m => m.BRANCH)
                .Where(m=>m.WAREHOUSE_STOCK.Name=="Null").ToListAsync();
            return View(await Resulte);
              //return _context.ACCESS_POINTS != null ? 
              //            View(await Resulte.ToListAsync()) :
              //            Problem("Entity set 'DATABASECONTEXTT.ACCESS_POINTS'  is null.");
        }


        public async Task<IActionResult> IndexStock()
        {
            var resulte= _context.ACCESS_POINTS.Include(m=>m.WAREHOUSE_STOCK).Include(m=>m.BRANCH)
                .Where(m=> m.WAREHOUSE_STOCK.Name !="Null").ToListAsync();
            return View(await resulte);
        }
        // GET: ACCESS_POINT/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ACCESS_POINTS == null)
            {
                return NotFound();
            }

            var aCCESS_POINT = await _context.ACCESS_POINTS.Include(m=>m.WAREHOUSE_STOCK).Include(m=>m.BRANCH)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (aCCESS_POINT == null)
            {
                return NotFound();
            }

            return View(aCCESS_POINT);
        }

        // GET: ACCESS_POINT/Create
        public IActionResult Create()
        {
            ViewData["BRANCH_ID"] = new SelectList(_context.BRANCHES, "Id", "Name");
            ViewData["WAREHOUSE_STOCK_ID"] = new SelectList(_context.WAREHOUSE_STOCK, "ID", "Name");
            return View();
        }

        // POST: ACCESS_POINT/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,CODE,TYPE,SERIAL_NUMBER,LOCATION,NOTE,DESCRPTION,Is_Warehouse,BRANCH_ID,WAREHOUSE_STOCK_ID")] ACCESS_POINT aCCESS_POINT)
        {
            try
            { 
                     if (ModelState.IsValid)
                    {
                        _context.Add(aCCESS_POINT);
                        await _context.SaveChangesAsync();
                    TempData["AlertMessage"] = "Device Created";
                    return RedirectToAction(nameof(Index));
                    }
            }
            catch (Exception ex) 
            {
                if (ex.InnerException.Message.Contains("IX_"))
                {
                    ModelState.AddModelError("", "the value alredy existed (Duplicate Note Aloow) :Try Another Value");
                }
                else
                {
                    ModelState.AddModelError("", "Can Not Delete Device");
                }


            }
           
            ViewData["BRANCH_ID"] = new SelectList(_context.BRANCHES, "Id", "Name");
            ViewData["WAREHOUSE_STOCK_ID"] = new SelectList(_context.WAREHOUSE_STOCK, "ID", "Name");
            return View(aCCESS_POINT);
        }

        // GET: ACCESS_POINT/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ACCESS_POINTS == null)
            {
                return NotFound();
            }

            var aCCESS_POINT = await _context.ACCESS_POINTS.FindAsync(id);
            if (aCCESS_POINT == null)
            {
                return NotFound();
            }
            ViewData["BRANCH_ID"] = new SelectList(_context.BRANCHES, "Id", "Name",aCCESS_POINT.BRANCH_ID);
            ViewData["WAREHOUSE_STOCK_ID"] = new SelectList(_context.WAREHOUSE_STOCK, "ID", "Name",aCCESS_POINT.WAREHOUSE_STOCK_ID);
            return View(aCCESS_POINT);
        }

        // POST: ACCESS_POINT/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,CODE,TYPE,SERIAL_NUMBER,LOCATION,NOTE,DESCRPTION,Is_Warehouse,BRANCH_ID,WAREHOUSE_STOCK_ID")] ACCESS_POINT aCCESS_POINT)
        {
            if (id != aCCESS_POINT.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aCCESS_POINT);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ACCESS_POINTExists(aCCESS_POINT.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["AlertMessage"] = "Device Update";
                return RedirectToAction(nameof(Index));
            }
            ViewData["BRANCH_ID"] = new SelectList(_context.BRANCHES, "Id", "Name",aCCESS_POINT.BRANCH_ID);
            ViewData["WAREHOUSE_STOCK_ID"] = new SelectList(_context.WAREHOUSE_STOCK, "ID", "Name",aCCESS_POINT.WAREHOUSE_STOCK_ID);
            return View(aCCESS_POINT);
        }

        // GET: ACCESS_POINT/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ACCESS_POINTS == null)
            {
                return NotFound();
            }

            var aCCESS_POINT = await _context.ACCESS_POINTS.Include(s=>s.WAREHOUSE_STOCK).Include(s=>s.BRANCH)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (aCCESS_POINT == null)
            {
                return NotFound();
            }

            return View(aCCESS_POINT);
        }

        // POST: ACCESS_POINT/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ACCESS_POINTS == null)
            {
                return Problem("Entity set 'DATABASECONTEXTT.ACCESS_POINTS'  is null.");
            }
            var aCCESS_POINT = await _context.ACCESS_POINTS.FindAsync(id);
            try
            {
              if (aCCESS_POINT != null)
               {
                 _context.ACCESS_POINTS.Remove(aCCESS_POINT);
                }
            
            await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Device Deleted";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex) 
            {
                if (ex.InnerException.Message.Contains("FK_"))
                {
                    ModelState.AddModelError("", "The Device has a reference with Warehouse stock or Branch");
                }
                else
                {
                    ModelState.AddModelError("", "Can Not Delete Device");
                }
            }
          return View(aCCESS_POINT);
        }

        private bool ACCESS_POINTExists(int id)
        {
          return (_context.ACCESS_POINTS?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
