using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication11.Models;

namespace WebApplication11.Controllers
{
    [Authorize(Roles = "User")]
    public class BRANCHesController : Controller
    {
        private readonly DATABASECONTEXTT _context;

        public BRANCHesController(DATABASECONTEXTT context)
        {
            _context = context;
        }

        // GET: BRANCHes
        public async Task<IActionResult> Index()
        {
              return _context.BRANCHES != null ? 
                          View(await _context.BRANCHES.ToListAsync()) :
                          Problem("Entity set 'DATABASECONTEXTT.BRANCHES'  is null.");
        }

        // GET: BRANCHes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BRANCHES == null)
            {
                return NotFound();
            }

            var bRANCH = await _context.BRANCHES
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bRANCH == null)
            {
                return NotFound();
            }

            return View(bRANCH);
        }

        // GET: BRANCHes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BRANCHes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CODE,Name,ADDRESS,PHONE,EMAIL,OPEN_DATE,NOTE,DESCRPTION")] BRANCH bRANCH)
        {
            try { 
            if (ModelState.IsValid)
            {
                _context.Add(bRANCH);
                await _context.SaveChangesAsync();
                    TempData["AlertMessage"] = "Device Created";
                    return RedirectToAction(nameof(Index));
            }
            }
            catch(Exception ex)
            {
                if (ex.InnerException.Message.Contains("IX_"))
                {
                    ModelState.AddModelError("", "The Value Inserted Is Already Existed Duplicate Not Allow ( Try Another Value )");
                }
                else
                {
                    ModelState.AddModelError("", "Can Not Insert Duplicat VALUE");
                }
            }
            return View(bRANCH);
        }

        // GET: BRANCHes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BRANCHES == null)
            {
                return NotFound();
            }

            var bRANCH = await _context.BRANCHES.FindAsync(id);
            if (bRANCH == null)
            {
                return NotFound();
            }
            return View(bRANCH);
        }

        // POST: BRANCHes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CODE,Name,ADDRESS,PHONE,EMAIL,OPEN_DATE,NOTE,DESCRPTION")] BRANCH bRANCH)
        {
            if (id != bRANCH.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bRANCH);
                    TempData["AlertMessage"] = "Device Updated";
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BRANCHExists(bRANCH.Id))
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
            return View(bRANCH);
        }

        // GET: BRANCHes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BRANCHES == null)
            {
                return NotFound();
            }

            var bRANCH = await _context.BRANCHES
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bRANCH == null)
            {
                return NotFound();
            }

            return View(bRANCH);
        }

        // POST: BRANCHes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BRANCHES == null)
            {
                return Problem("Entity set 'DATABASECONTEXTT.BRANCHES'  is null.");
            }
            var bRANCH = await _context.BRANCHES.FindAsync(id);
            try
            {
                
                if (bRANCH != null)
                {
                    _context.BRANCHES.Remove(bRANCH);
                }

                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Device Deleted";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message.Contains("Fk_"))
                {
                    ModelState.AddModelError("", "Unable to save changes the branch have areference with other warehouse stock");
                }
                else
                {
                    ModelState.AddModelError("", "unable to Delete  branch that have a department,warehouse stock reference");
                }
            }
            return View(bRANCH);
           
        }

        private bool BRANCHExists(int id)
        {
          return (_context.BRANCHES?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
