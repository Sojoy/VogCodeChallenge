using System;
using System.Collections.Generic;
using System.Text;
using VogCodeChallenge.Core.Models;

namespace VogCodeChallenge.Core.Interfaces
{
    public interface IEmployeeManager
    {
        IEnumerable<Employee> GetAll();
        IList<Employee> ListAll();
    }
}
