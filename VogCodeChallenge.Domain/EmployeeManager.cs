using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using VogCodeChallenge.Core.Interfaces;
using VogCodeChallenge.Core.Models;
using VogCodeChallenge.Data;

namespace VogCodeChallenge.Domain
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly VogDBContext _dbContext;

        public EmployeeManager(VogDBContext context)
        {
            _dbContext = context;
        }
        public IEnumerable<Employee> GetAll()
        {
            return _dbContext.Employees.Include(p => p.Department);
        }

        public IList<Employee> ListAll()
        {
            return _dbContext.Employees.Include(p => p.Department).ToList();
        }
    }
}
