using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HotelDB.Controllers
{
    public class StaffRolesController : Controller
    {
        private readonly HotelManagementContext _context;

        public StaffRolesController(HotelManagementContext context)
        {
            _context = context;
        }

        // GET: StaffRoles
        public async Task<IActionResult> Index()
        {
            var hotelManagementContext = _context.StaffRoles.Include(s => s.Role).Include(s => s.Staff);
            return View(await hotelManagementContext.ToListAsync());
        }

        // GET: StaffRoles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StaffRoles == null)
            {
                return NotFound();
            }

            var staffRole = await _context.StaffRoles
                .Include(s => s.Role)
                .Include(s => s.Staff)
                .FirstOrDefaultAsync(m => m.StaffID == id);
            if (staffRole == null)
            {
                return NotFound();
            }

            return View(staffRole);
        }

        // GET: StaffRoles/Create
        public IActionResult Create()
        {
            ViewData["RoleID"] = new SelectList(_context.Roles, "RoleID", "RoleID");
            ViewData["StaffID"] = new SelectList(_context.Staffs, "StaffID", "StaffID");
            return View();
        }

        // POST: StaffRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StaffID,RoleID")] StaffRole staffRole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staffRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoleID"] = new SelectList(_context.Roles, "RoleID", "RoleID", staffRole.RoleID);
            ViewData["StaffID"] = new SelectList(_context.Staffs, "StaffID", "StaffID", staffRole.StaffID);
            return View(staffRole);
        }

        // GET: StaffRoles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StaffRoles == null)
            {
                return NotFound();
            }

            var staffRole = await _context.StaffRoles.FindAsync(id);
            if (staffRole == null)
            {
                return NotFound();
            }
            ViewData["RoleID"] = new SelectList(_context.Roles, "RoleID", "RoleID", staffRole.RoleID);
            ViewData["StaffID"] = new SelectList(_context.Staffs, "StaffID", "StaffID", staffRole.StaffID);
            return View(staffRole);
        }

        // POST: StaffRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StaffID,RoleID")] StaffRole staffRole)
        {
            if (id != staffRole.StaffID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staffRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffRoleExists(staffRole.StaffID))
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
            ViewData["RoleID"] = new SelectList(_context.Roles, "RoleID", "RoleID", staffRole.RoleID);
            ViewData["StaffID"] = new SelectList(_context.Staffs, "StaffID", "StaffID", staffRole.StaffID);
            return View(staffRole);
        }

        // GET: StaffRoles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StaffRoles == null)
            {
                return NotFound();
            }

            var staffRole = await _context.StaffRoles
                .Include(s => s.Role)
                .Include(s => s.Staff)
                .FirstOrDefaultAsync(m => m.StaffID == id);
            if (staffRole == null)
            {
                return NotFound();
            }

            return View(staffRole);
        }

        // POST: StaffRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StaffRoles == null)
            {
                return Problem("Entity set 'HotelManagementContext.StaffRoles'  is null.");
            }
            var staffRole = await _context.StaffRoles.FindAsync(id);
            if (staffRole != null)
            {
                _context.StaffRoles.Remove(staffRole);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaffRoleExists(int id)
        {
          return (_context.StaffRoles?.Any(e => e.StaffID == id)).GetValueOrDefault();
        }
    }
}
