using BackendTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTest.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetEmployeesAsync();

        Task CreateAsync(Employee employee);
    }
}
