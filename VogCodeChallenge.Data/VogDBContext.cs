using Microsoft.EntityFrameworkCore;
using System;
using VogCodeChallenge.Core.Models;

namespace VogCodeChallenge.Data
{
    public class VogDBContext: DbContext
    {
        public VogDBContext(DbContextOptions<VogDBContext> options)
       : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Department>()
                .HasIndex(p => p.Address)
                .IsUnique();  //make the Address unique
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
