using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VogCodeChallenge.Core.Models;

namespace VogCodeChallenge.Data
{
    public class VogDBInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new VogDBContext(serviceProvider.GetRequiredService<DbContextOptions<VogDBContext>>()))
            {
                if (context.Employees.Any())
                {
                    return;
                }

                //seed departments
                var departments = new List<Department>()
                {
                    new Department{ ID=1, Name="IT Department", Address="8 Campton street, Alberta"},
                    new Department{ ID=2, Name="Human Resources", Address="10 CBD Road, Ottawa"}
                };
                context.Departments.AddRange(departments);

                //seed employees
                var employees = new List<Employee>()
                {
                    new Employee { ID=1, FirstName = "Bill", LastName="Gate", JobTitle = "Head of Department", Address = "1 Joseph Bush street, Canada", Department = departments[0] },
                    new Employee { ID=2, FirstName = "Emmanuel", LastName = "Kant", JobTitle = "Manager", Address = "3 Investment road, Victoria Island, Australia", Department = departments[1]},
                    new Employee { ID=3, FirstName = "Mark", LastName="Zuckerberg", JobTitle = "Lead Developer", Address = "9 Louis street, Alberta, Canada", Department = departments[0] },
                    new Employee { ID=4, FirstName = "David", LastName="Hume", JobTitle = "Assistant Manager", Address = "20 Louis solomon close, Victoria Island, Lagos", Department = departments[1] },
                    new Employee { ID=5, FirstName = "Steve", LastName="Jobs", JobTitle = "Lead Architect", Address = "Plot 101 Central Business District, Lagos", Department = departments[0] }
                };
                context.Employees.AddRange(employees);
                context.SaveChanges();
            }
        }
    }
}
