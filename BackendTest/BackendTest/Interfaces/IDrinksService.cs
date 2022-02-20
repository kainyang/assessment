using BackendTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTest.Interfaces
{
    public interface IDrinksService
    {
        Task<List<Beverage>> GetCoffees();

        Task<List<Beverage>> GetBeers();
    }
}
