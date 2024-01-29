using HRManagements.Data;
using Microsoft.EntityFrameworkCore;

namespace HRManagements.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new HRManagementsContext(
                serviceProvider.GetRequiredService<DbContextOptions<HRManagementsContext>>()))
            {

                context.Database.EnsureCreated();

                if (context.Department.Any() || context.Employee.Any())
                {
                    return;
                }

                SeedDepartments(context);
                SeedEmployees(context);
            }
        }

        private static void SeedDepartments(HRManagementsContext context)
        {
            var departments = new[]
            {
            new Department { Name = "HR", Code = "HR001", Location = "So 8 Ton That Thuyet", NumberOfEmployees = 0 },
            new Department { Name = "IT", Code = "IT001", Location = "So 8 Ton That Thuyet", NumberOfEmployees = 0 },

        };

            context.Department.AddRange(departments);
            context.SaveChanges();
        }

        private static void SeedEmployees(HRManagementsContext context)
        {
            var employees = new[]
            {
            new Employee { Name = "Quang Nam", Code = "QN001", Rank = "Boss", DepartmentId = 1 },
            new Employee { Name = "Nam Quang", Code = "QN002", Rank = "Developer", DepartmentId = 2 },

        };

            context.Employee.AddRange(employees);
            context.SaveChanges();
        }
    }
}
