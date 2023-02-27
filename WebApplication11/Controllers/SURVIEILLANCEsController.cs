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
    [Authorize(Roles = "Admin")]
    public class SURVIEILLANCEsController : Controller
    {
        private readonly DATABASECONTEXTT _context;

        public SURVIEILLANCEsController(DATABASECONTEXTT context)
        {
            _context = context;
        }

        // GET: SURVIEILLANCEs
        public async Task<IActionResult> Index()
        {
            var dATABASECONTEXTT = _context.SURVIEILLANCES.Include(s => s.BRANCH)
                .Include(s=>s.WAREHOUSE_STOCK_FOR_CAMRA_DVR).Where(s=>s.WAREHOUSE_STOCK_FOR_CAMRA_DVR.Name=="Null");
            return View(await dATABASECONTEXTT.ToListAsync());
        }


        public async Task<IActionResult> Index1()
        {
            var dATABASECONTEXTT = _context?.SURVIEILLANCES?.Include(s => s.WAREHOUSE_STOCK_FOR_CAMRA_DVR).Include(s=>s.BRANCH)
                .Where(s=> s.WAREHOUSE_STOCK_FOR_CAMRA_DVR.Name !="Null");
            return View(await dATABASECONTEXTT.ToListAsync());
        }

        // GET: SURVIEILLANCEs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SURVIEILLANCES == null)
            {
                return NotFound();
            }

            var sURVIEILLANCE = await _context.SURVIEILLANCES
                .Include(s => s.BRANCH).Include(s=>s.WAREHOUSE_STOCK_FOR_CAMRA_DVR)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sURVIEILLANCE == null)
            {
                return NotFound();
            }

            return View(sURVIEILLANCE);
        }

        // GET: SURVIEILLANCEs/Create
        public IActionResult Create()
        {
            ViewData["BRANCH_ID"] = new SelectList(_context.BRANCHES, "Id", "Name");
            ViewData["WAREHOUSE_STOCK_FOR_CAMRA_DVR_ID"] = new SelectList(_context.WAREHOUSE_STOCK_FOR_CAMRA_DVRS, "ID", "Name");
            return View();
        }

        // POST: SURVIEILLANCEs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,Model,Type,Serial_Number,Internail_Ip,Externail_IP,Port_number,DVR_NVR_MODEL,NUMBER_OF_CHANNEL,USED_CHANNEL,CONECTIVETY_TYPE,STORAGE,USER_LOGIN,PASSWORD,VERIFICATION_CODE,is_warehouse,Note,BRANCH_ID,WAREHOUSE_STOCK_FOR_CAMRA_DVR_ID")] SURVIEILLANCE sURVIEILLANCE)
        {
            try
            {
                  if (ModelState.IsValid)
                            {
                                _context.Add(sURVIEILLANCE);
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
                    ModelState.AddModelError("", "Can Not Save Device");
                }
            }
          
            ViewData["BRANCH_ID"] = new SelectList(_context.BRANCHES, "Id", "Name", sURVIEILLANCE.BRANCH_ID);
            ViewData["WAREHOUSE_STOCK_FOR_CAMRA_DVR_ID"] = new SelectList(_context.WAREHOUSE_STOCK_FOR_CAMRA_DVRS, "ID", "Name", sURVIEILLANCE.WAREHOUSE_STOCK_FOR_CAMRA_DVR_ID);
           
            return View(sURVIEILLANCE);
        }

        // GET: SURVIEILLANCEs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SURVIEILLANCES == null)
            {
                return NotFound();
            }

            var sURVIEILLANCE = await _context.SURVIEILLANCES.FindAsync(id);
            if (sURVIEILLANCE == null)
            {
                return NotFound();
            }
            ViewData["BRANCH_ID"] = new SelectList(_context.BRANCHES, "Id", "Name", sURVIEILLANCE.BRANCH_ID);
            ViewData["WAREHOUSE_STOCK_FOR_CAMRA_DVR_ID"] = new SelectList(_context.WAREHOUSE_STOCK_FOR_CAMRA_DVRS, "ID", "Name", sURVIEILLANCE.WAREHOUSE_STOCK_FOR_CAMRA_DVR_ID);
            return View(sURVIEILLANCE);
        }

        // POST: SURVIEILLANCEs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Code,Model,Type,Serial_Number,Internail_Ip,Externail_IP,Port_number,DVR_NVR_MODEL,NUMBER_OF_CHANNEL,USED_CHANNEL,CONECTIVETY_TYPE,STORAGE,USER_LOGIN,PASSWORD,VERIFICATION_CODE,is_warehouse,Note,BRANCH_ID,WAREHOUSE_STOCK_FOR_CAMRA_DVR_ID")] SURVIEILLANCE sURVIEILLANCE)
        {
            if (id != sURVIEILLANCE.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sURVIEILLANCE);
                    await _context.SaveChangesAsync();
                    TempData["AlertMessage"] = "Device Updated";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SURVIEILLANCEExists(sURVIEILLANCE.Id))
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
            ViewData["BRANCH_ID"] = new SelectList(_context.BRANCHES, "Id", "Name", sURVIEILLANCE.BRANCH_ID);
            ViewData["WAREHOUSE_STOCK_FOR_CAMRA_DVR_ID"] = new SelectList(_context.WAREHOUSE_STOCK_FOR_CAMRA_DVRS, "ID", "Name", sURVIEILLANCE.WAREHOUSE_STOCK_FOR_CAMRA_DVR_ID);

            return View(sURVIEILLANCE);
        }

        // GET: SURVIEILLANCEs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SURVIEILLANCES == null)
            {
                return NotFound();
            }

            var sURVIEILLANCE = await _context.SURVIEILLANCES
                .Include(s => s.BRANCH).Include(s=>s.WAREHOUSE_STOCK_FOR_CAMRA_DVR)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sURVIEILLANCE == null)
            {
                return NotFound();
            }

            return View(sURVIEILLANCE);
        }

        // POST: SURVIEILLANCEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SURVIEILLANCES == null)
            {
                return Problem("Entity set 'DATABASECONTEXTT.SURVIEILLANCES'  is null.");
            }
            var sURVIEILLANCE = await _context.SURVIEILLANCES.FindAsync(id);
            if (sURVIEILLANCE != null)
            {
                _context.SURVIEILLANCES.Remove(sURVIEILLANCE);
            }
            
            await _context.SaveChangesAsync();
            TempData["AlertMessage"] = "Device Deleted";
            return RedirectToAction(nameof(Index));

        }

        private bool SURVIEILLANCEExists(int id)
        {
          return (_context.SURVIEILLANCES?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
