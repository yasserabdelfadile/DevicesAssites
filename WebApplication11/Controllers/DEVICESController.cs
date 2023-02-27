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
    public class DEVICESController : Controller
    {
        private readonly DATABASECONTEXTT _context;

        public DEVICESController(DATABASECONTEXTT context)
        {
            _context = context;
        }

        // GET: DEVICES
        public async Task<IActionResult> Index()
        {
            var dATABASECONTEXTT = _context.DEVICESES.Include(d => d.EMPLOYEE).ThenInclude(d=>d.DEPARTMENT).ThenInclude(d=>d.BRANCH).Include(d => d.WAREHOUSE_STOCK)
                .Where(d=>d.WAREHOUSE_STOCK.Name =="Null");
            return View(await dATABASECONTEXTT.ToListAsync());
        }
        public IActionResult Device_stock()
        {
            var resulte = _context.DEVICESES.Where(d=>d.WAREHOUSE_STOCK.Name !="Null" ).Include(d => d.WAREHOUSE_STOCK).ThenInclude(d=>d.BRANCH).ToList();
            return View(resulte);
        }

        // GET: DEVICES/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DEVICESES == null)
            {
                return NotFound();
            }

            var dEVICES = await _context.DEVICESES
                .Include(d => d.EMPLOYEE)
                .Include(d => d.WAREHOUSE_STOCK)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dEVICES == null)
            {
                return NotFound();
            }

            return View(dEVICES);
        }

        // GET: DEVICES/Create
        public IActionResult Create()
        {
            ViewData["EMPLOYEE_ID"] = new SelectList(_context.EMPLOYEES, "ID", "Name");
            ViewData["WAREHOUSE_STOCK_ID"] = new SelectList(_context.WAREHOUSE_STOCK, "ID", "Name");
            return View();
        }

        // POST: DEVICES/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CODE,Name,TYPE,MODEL_NO,SERIAL_NO,PROCESSOR,RAME_SIZE,QUANTITY,BUS_SPEED,RAM_GENERATION,HDD,SDD_NVME,MOINTOR_BRANCH_INCH,BIOS_VERSION,WINDOWS,RECIVED_DEVICE_DATE,RE_RECIVED_DEVICE_DATE,Is_Warehouse,NOTE,EMPLOYEE_ID,WAREHOUSE_STOCK_ID")] DEVICES dEVICES)
        {
            try
            {
                 if (ModelState.IsValid)
                            {
                                _context.Add(dEVICES);
                                await _context.SaveChangesAsync();
                    TempData["AlertMessage"] = "Device Created";
                    return RedirectToAction(nameof(Index));
                            }
            }
            catch(Exception ex)
            {
                if (ex.InnerException.Message.Contains("IX_"))
                {
                    ModelState.AddModelError("", "the vluae alerdy existed (dulpicate note allow :try another value Code or Name Or Serial Number)");
                }
                else
                {
                    ModelState.AddModelError("", "Can Not Delete Device");
                }
            }



           
            ViewData["EMPLOYEE_ID"] = new SelectList(_context.EMPLOYEES, "ID", "Name", dEVICES.EMPLOYEE_ID);
            ViewData["WAREHOUSE_STOCK_ID"] = new SelectList(_context.WAREHOUSE_STOCK, "ID", "Name", dEVICES.WAREHOUSE_STOCK_ID);
            return View(dEVICES);
        }

        // GET: DEVICES/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DEVICESES == null)
            {
                return NotFound();
            }

            var dEVICES = await _context.DEVICESES.FindAsync(id);
            if (dEVICES == null)
            {
                return NotFound();
            }
            ViewData["EMPLOYEE_ID"] = new SelectList(_context.EMPLOYEES, "ID", "Name", dEVICES.EMPLOYEE_ID);
            ViewData["WAREHOUSE_STOCK_ID"] = new SelectList(_context.WAREHOUSE_STOCK, "ID", "Name", dEVICES.WAREHOUSE_STOCK_ID);
            return View(dEVICES);
        }

        // POST: DEVICES/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,CODE,Name,TYPE,MODEL_NO,SERIAL_NO,PROCESSOR,RAME_SIZE,QUANTITY,BUS_SPEED,RAM_GENERATION,HDD,SDD_NVME,MOINTOR_BRANCH_INCH,BIOS_VERSION,WINDOWS,RECIVED_DEVICE_DATE,RE_RECIVED_DEVICE_DATE,Is_Warehouse,NOTE,EMPLOYEE_ID,WAREHOUSE_STOCK_ID")] DEVICES dEVICES)
        {
            if (id != dEVICES.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dEVICES);
                    TempData["AlertMessage"] = "Device Update";
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DEVICESExists(dEVICES.ID))
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
            ViewData["EMPLOYEE_ID"] = new SelectList(_context.EMPLOYEES, "ID", "Name", dEVICES.EMPLOYEE_ID);
            ViewData["WAREHOUSE_STOCK_ID"] = new SelectList(_context.WAREHOUSE_STOCK, "ID", "Name", dEVICES.WAREHOUSE_STOCK_ID);
            return View(dEVICES);
        }

        // GET: DEVICES/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DEVICESES == null)
            {
                return NotFound();
            }

            var dEVICES = await _context.DEVICESES
                .Include(d => d.EMPLOYEE)
                .Include(d => d.WAREHOUSE_STOCK)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dEVICES == null)
            {
                return NotFound();
            }

            return View(dEVICES);
        }

        // POST: DEVICES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DEVICESES == null)
            {
                return Problem("Entity set 'DATABASECONTEXTT.DEVICESES'  is null.");
            }
            var dEVICES = await _context.DEVICESES.FindAsync(id);
            try
            {
                 if (dEVICES != null)
                            {
                                _context.DEVICESES.Remove(dEVICES);
                            }
            
                            await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Device Removed";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message.Contains("FK_"))
                {
                    ModelState.AddModelError("", "The Device has a reference with Warehouse stock or employee ");
                }
                else
                {
                    ModelState.AddModelError("", "Can Not Delete Device");
                }
            }

                return View(dEVICES);

           
        }

        private bool DEVICESExists(int id)
        {
          return (_context.DEVICESES?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
