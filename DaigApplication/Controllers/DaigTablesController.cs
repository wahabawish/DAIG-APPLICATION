using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DaigApplication.Models;

namespace DaigApplication.Controllers
{
    public class DaigTablesController : Controller
    {
        private readonly DaigAppContext _context;

        public DaigTablesController(DaigAppContext context)
        {
            _context = context;
        }

        // GET: DaigTables
        public async Task<IActionResult> Index()
        {
            return View(await _context.DaigTables.ToListAsync());
        }

        // GET: DaigTables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var daigTable = await _context.DaigTables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (daigTable == null)
            {
                return NotFound();
            }

            return View(daigTable);
        }

        // GET: DaigTables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DaigTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DaigType,DaigStatus,DaigAvailability")] DaigTable daigTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(daigTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(daigTable);
        }

        // GET: DaigTables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var daigTable = await _context.DaigTables.FindAsync(id);
            if (daigTable == null)
            {
                return NotFound();
            }
            return View(daigTable);
        }

        // POST: DaigTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DaigType,DaigStatus,DaigAvailability")] DaigTable daigTable)
        {
            if (id != daigTable.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(daigTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DaigTableExists(daigTable.Id))
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
            return View(daigTable);
        }

        // GET: DaigTables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var daigTable = await _context.DaigTables
                .FirstOrDefaultAsync(m => m.Id == id);
            if (daigTable == null)
            {
                return NotFound();
            }

            return View(daigTable);
        }

        // POST: DaigTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var daigTable = await _context.DaigTables.FindAsync(id);
            if (daigTable != null)
            {
                _context.DaigTables.Remove(daigTable);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DaigTableExists(int id)
        {
            return _context.DaigTables.Any(e => e.Id == id);
        }
    }
}
