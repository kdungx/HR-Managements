using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HRManagements.Data;
using HRManagements.Data;

namespace Enterprise.Controllers
{
    public class ReportController : Controller
    {
        private readonly HRManagementsContext _context;

        public ReportController(HRManagementsContext context)
        {
            _context = context;
        }

        // GET: Report/EmployeeStatistics
        public IActionResult EmployeeStatistics(int departmentId)
        {
            var employees = _context.Employee
                .Include(e => e.Department)
                .Where(e => e.DepartmentId == departmentId)
                .ToList();

            // Implement logic to generate statistics (e.g., calculate average salary, count of employees, etc.)
            // For demonstration purposes, let's calculate the count of employees
            var employeeCount = employees.Count;

            ViewBag.DepartmentName = _context.Department.FirstOrDefault(d => d.Id == departmentId)?.Name;
            ViewBag.EmployeeCount = employeeCount;

            return View();
        }
    }
}