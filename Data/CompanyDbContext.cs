using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Labb_1.Models;

namespace Labb_1.Data
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options) : base(options)
        {

        }
        public DbSet<Labb_1.Models.Employee> Employee { get; set; } = default!;
        public DbSet<Labb_1.Models.Leave> Leave { get; set; } = default!;

        public DbSet<Labb_1.Models.LeaveList> LeaveList { get; set; } = default!;

    }
}
