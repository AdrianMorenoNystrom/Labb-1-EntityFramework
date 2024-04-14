using Labb_1.Data;
using Labb_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Labb_1.Controllers
{
    public class EmployeeLeaveController : Controller
    {
        private readonly CompanyDbContext _context;

        public EmployeeLeaveController(CompanyDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? employeeId)
        {
            var employees = await _context.Employee.ToListAsync();

            var query = from ll in _context.Leave
                        join e in _context.Employee on ll.EmployeeId equals e.EmployeeId
                        join l in _context.Leave on ll.LeaveId equals l.LeaveId
                        where !employeeId.HasValue || e.EmployeeId == employeeId
                        select new { e.EmployeeName, l.LeaveType, ll.StartDate, ll.EndDate };

            var leaveHistory = await query.Select(x => new EmployeeWithLeave
            {
                EmployeeName = x.EmployeeName,
                LeaveType = x.LeaveType.ToString(),
                StartDate = x.StartDate,
                EndDate = x.EndDate
            }).ToListAsync();

            string selectedEmployee = null;
            if (employeeId.HasValue)
            {
                var selectedEmp = await _context.Employee
                    .Where(e => e.EmployeeId == employeeId.Value)
                    .FirstOrDefaultAsync();

                selectedEmployee = selectedEmp?.EmployeeName;
            }

            var viewModel = new EmployeeLeaveViewModel
            {
                Employees = employees,
                LeaveHistory = leaveHistory,
                SelectedEmployee = selectedEmployee
            };

            return View(viewModel);
        }
    }
}
