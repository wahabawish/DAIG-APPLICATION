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
    public class AuthAdminsController : Controller
    {
        private readonly DaigAppContext _context;

        public AuthAdminsController(DaigAppContext context)
        {
            _context = context;
        }

        // GET: AuthAdmins
        public async Task<IActionResult> Index()
        {
            return View(await _context.AuthAdmins.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CheckingIDs(string emis, string passis)
        {
            var authsList = await _context.AuthAdmins.ToListAsync();
            var user = authsList.FirstOrDefault(a => a.Emailis == emis && a.Passwordis == passis);

            if (user != null)
            {
                return RedirectToAction("Index", "DaigTables");
            }
            else
            {
                ModelState.AddModelError("", "Invalid email or password.");
                return View("Index", _context.AuthAdmins.ToList());
            }
        }

        // GET: AuthAdmins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authAdmin = await _context.AuthAdmins
                .FirstOrDefaultAsync(m => m.Id == id);
            if (authAdmin == null)
            {
                return NotFound();
            }

            return View(authAdmin);
        }

        // GET: AuthAdmins/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AuthAdmins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Usernameis,Passwordis,Emailis")] AuthAdmin authAdmin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(authAdmin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(authAdmin);
        }

        // GET: AuthAdmins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authAdmin = await _context.AuthAdmins.FindAsync(id);
            if (authAdmin == null)
            {
                return NotFound();
            }
            return View(authAdmin);
        }

        // POST: AuthAdmins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Usernameis,Passwordis,Emailis")] AuthAdmin authAdmin)
        {
            if (id != authAdmin.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(authAdmin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthAdminExists(authAdmin.Id))
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
            return View(authAdmin);
        }

        // GET: AuthAdmins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var authAdmin = await _context.AuthAdmins
                .FirstOrDefaultAsync(m => m.Id == id);
            if (authAdmin == null)
            {
                return NotFound();
            }

            return View(authAdmin);
        }

        // POST: AuthAdmins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var authAdmin = await _context.AuthAdmins.FindAsync(id);
            if (authAdmin != null)
            {
                _context.AuthAdmins.Remove(authAdmin);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuthAdminExists(int id)
        {
            return _context.AuthAdmins.Any(e => e.Id == id);
        }
    }
}
