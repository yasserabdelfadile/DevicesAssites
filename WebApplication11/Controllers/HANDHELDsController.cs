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
    public class HANDHELDsController : Controller
    {
        private readonly DATABASECONTEXTT _context;

        public HANDHELDsController(DATABASECONTEXTT context)
        {
            _context = context;
        }

        // GET: HANDHELDs
        public async Task<IActionResult> Index()
        {
            var dATABASECONTEXTT = _context.HANDHELDs.Include(h => h.EMPLOYEE).ThenInclude(h=>h.DEPARTMENT).ThenInclude(h=>h.BRANCH).Include(h => h.WAREHOUSE_STOCK)
                .Where(h=>h.WAREHOUSE_STOCK.Name=="Null");
            return View(await dATABASECONTEXTT.ToListAsync());
        }

        public async Task<IActionResult> IndexStock()
        {
            var Resulte=_context?.HANDHELDs?.Include(m=>m.WAREHOUSE_STOCK).ThenInclude(m=>m.BRANCH)
                .Where(m=> m.WAREHOUSE_STOCK.Name !="Null").ToListAsync();
            return View(await Resulte);
        }

        // GET: HANDHELDs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HANDHELDs == null)
            {
                return NotFound();
            }

            var hANDHELD = await _context.HANDHELDs
                .Include(h => h.EMPLOYEE)
                .Include(h => h.WAREHOUSE_STOCK)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hANDHELD == null)
            {
                return NotFound();
            }

            return View(hANDHELD);
        }

        // GET: HANDHELDs/Create
        public IActionResult Create()
        {
            ViewData["EMPLOYEE_ID"] = new SelectList(_context.EMPLOYEES, "ID", "Name");
            ViewData["WAREHOUSE_STOCK_ID"] = new SelectList(_context.WAREHOUSE_STOCK, "ID", "Name");
            return View();
        }

        // POST: HANDHELDs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CODE,NAME,MODEL,SERIAL_NUMBER,Processor,RAM_SIZE,ANDROID_VERSION,Is_warehouse,RECIVED_DEVICE_DATE,RE_RECIVED_DEVICE_DATE,NOTE,EMPLOYEE_ID,WAREHOUSE_STOCK_ID")] HANDHELD hANDHELD)
        {
            try
            {
                 if (ModelState.IsValid)
                            {
                                _context.Add(hANDHELD);
                                await _context.SaveChangesAsync();
              
                                TempData["AlertMessage"] = "Device Created";
                                return RedirectToAction(nameof(Index));
                            }
            }
            catch(Exception ex)
            {
                if(ex.InnerException.Message.Contains("IX_"))
                {
                    ModelState.AddModelError("", "the vluae alerdy existed (dulpicate note allow :try another value Code or Name Or Serial Number)");
                }
                else
                {
                    ModelState.AddModelError("", "Can Not Delete Device");
                }
                return View(hANDHELD);
            }
           
            ViewData["EMPLOYEE_ID"] = new SelectList(_context.EMPLOYEES, "ID", "Name", hANDHELD.EMPLOYEE_ID);
            ViewData["WAREHOUSE_STOCK_ID"] = new SelectList(_context.WAREHOUSE_STOCK, "ID", "Name", hANDHELD.WAREHOUSE_STOCK_ID);
            return View(hANDHELD);
        }

        // GET: HANDHELDs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HANDHELDs == null)
            {
                return NotFound();
            }

            var hANDHELD = await _context.HANDHELDs.FindAsync(id);
            if (hANDHELD == null)
            {
                return NotFound();
            }
            ViewData["EMPLOYEE_ID"] = new SelectList(_context.EMPLOYEES, "ID", "Name", hANDHELD.EMPLOYEE_ID);
            ViewData["WAREHOUSE_STOCK_ID"] = new SelectList(_context.WAREHOUSE_STOCK, "ID", "Name", hANDHELD.WAREHOUSE_STOCK_ID);
            return View(hANDHELD);
        }

        // POST: HANDHELDs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CODE,NAME,MODEL,SERIAL_NUMBER,Processor,RAM_SIZE,ANDROID_VERSION,Is_warehouse,RECIVED_DEVICE_DATE,RE_RECIVED_DEVICE_DATE,NOTE,EMPLOYEE_ID,WAREHOUSE_STOCK_ID")] HANDHELD hANDHELD)
        {

            if (id != hANDHELD.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hANDHELD);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage"] = "Device Updated";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HANDHELDExists(hANDHELD.Id))
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
            ViewData["EMPLOYEE_ID"] = new SelectList(_context.EMPLOYEES, "ID", "Name", hANDHELD.EMPLOYEE_ID);
            ViewData["WAREHOUSE_STOCK_ID"] = new SelectList(_context.WAREHOUSE_STOCK, "ID", "Name", hANDHELD.WAREHOUSE_STOCK_ID);
            return View(hANDHELD);
        }

        // GET: HANDHELDs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HANDHELDs == null)
            {
                return NotFound();
            }

            var hANDHELD = await _context.HANDHELDs
                .Include(h => h.EMPLOYEE)
                .Include(h => h.WAREHOUSE_STOCK)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hANDHELD == null)
            {
                return NotFound();
            }

            return View(hANDHELD);
        }

        // POST: HANDHELDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HANDHELDs == null)
            {
                return Problem("Entity set 'DATABASECONTEXTT.HANDHELDs'  is null.");
            }
            var hANDHELD = await _context.HANDHELDs.FindAsync(id);
            try
            {
                 if (hANDHELD != null)
                            {
                                _context.HANDHELDs.Remove(hANDHELD);
                            }
            
                            await _context.SaveChangesAsync();
                            TempData["AlertMessage"] = "Device Removed";
                            return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                if(ex.InnerException.Message.Contains("FK_"))
                {
                    ModelState.AddModelError("","Device Have a Referenece ");
                }
                else
                {
                    ModelState.AddModelError("", "Device Have a Referenece ");
                }
            }
            return View(hANDHELD);
           
        }

        private bool HANDHELDExists(int id)
        {
          return (_context.HANDHELDs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
