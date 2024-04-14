using Microsoft.AspNetCore.Mvc;
using Labb_1.Data;
using Labb_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Labb_1.Controllers
{
    public class LeaveApplicationsByMonth : Controller
    {
        private readonly CompanyDbContext _context;

        public LeaveApplicationsByMonth(CompanyDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new LeaveApplicationsViewModel
            {
                Employees = _context.Employee.ToList(),
                Months = GetMonths() // Populate the Months property
            };
            return View(model);
        }

        // Helper method to get a list of months
        private List<DateTime> GetMonths()
        {
            var startDate = new DateTime(2020, 1, 1);
            var endDate = new DateTime(2024, 12, 1);
            var months = new List<DateTime>();
            for (var date = startDate; date <= endDate; date = date.AddMonths(1))
            {
                months.Add(date);
            }
            return months;
        }
    }
}
