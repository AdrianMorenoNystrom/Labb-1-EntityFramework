using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Labb_1.Data;
using Labb_1.Models;

namespace Labb_1.Controllers
{
    public class LeaveListsController : Controller
    {
        private readonly CompanyDbContext _context;

        public LeaveListsController(CompanyDbContext context)
        {
            _context = context;
        }

        // GET: LeaveLists
        public async Task<IActionResult> Index()
        {
            var companyDbContext = _context.LeaveList.Include(l => l.Employee).Include(l => l.Leave);
            return View(await companyDbContext.ToListAsync());
        }

        // GET: LeaveLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveList = await _context.LeaveList
                .Include(l => l.Employee)
                .Include(l => l.Leave)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leaveList == null)
            {
                return NotFound();
            }

            return View(leaveList);
        }

        // GET: LeaveLists/Create
        public IActionResult Create()
        {
            ViewData["FkEmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeName");
            ViewData["FkLeaveId"] = new SelectList(_context.Leave, "LeaveId", "LeaveId");
            return View();
        }

        // POST: LeaveLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FkEmployeeId,FkLeaveId")] LeaveList leaveList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(leaveList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkEmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeName", leaveList.FkEmployeeId);
            ViewData["FkLeaveId"] = new SelectList(_context.Leave, "LeaveId", "LeaveId", leaveList.FkLeaveId);
            return View(leaveList);
        }

        // GET: LeaveLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveList = await _context.LeaveList.FindAsync(id);
            if (leaveList == null)
            {
                return NotFound();
            }
            ViewData["FkEmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeName", leaveList.FkEmployeeId);
            ViewData["FkLeaveId"] = new SelectList(_context.Leave, "LeaveId", "LeaveId", leaveList.FkLeaveId);
            return View(leaveList);
        }

        // POST: LeaveLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FkEmployeeId,FkLeaveId")] LeaveList leaveList)
        {
            if (id != leaveList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leaveList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaveListExists(leaveList.Id))
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
            ViewData["FkEmployeeId"] = new SelectList(_context.Employee, "EmployeeId", "EmployeeName", leaveList.FkEmployeeId);
            ViewData["FkLeaveId"] = new SelectList(_context.Leave, "LeaveId", "LeaveId", leaveList.FkLeaveId);
            return View(leaveList);
        }

        // GET: LeaveLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveList = await _context.LeaveList
                .Include(l => l.Employee)
                .Include(l => l.Leave)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leaveList == null)
            {
                return NotFound();
            }

            return View(leaveList);
        }

        // POST: LeaveLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var leaveList = await _context.LeaveList.FindAsync(id);
            if (leaveList != null)
            {
                _context.LeaveList.Remove(leaveList);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeaveListExists(int id)
        {
            return _context.LeaveList.Any(e => e.Id == id);
        }
    }
}
