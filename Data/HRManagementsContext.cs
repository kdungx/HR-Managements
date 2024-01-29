using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HRManagements.Models;

namespace HRManagements.Data
{
    public class HRManagementsContext : DbContext
    {
        public HRManagementsContext (DbContextOptions<HRManagementsContext> options)
            : base(options)
        {
        }

        public DbSet<HRManagements.Models.Department> Department { get; set; } = default!;
        public DbSet<HRManagements.Models.Employee> Employee { get; set; } = default!;
    }
}
