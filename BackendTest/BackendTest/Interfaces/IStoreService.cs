using BackendTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTest.Interfaces
{
    public interface IStoreService
    {
        Task<Store> GetByLocationAsync(string location);

        Task CreateAsync(Store store);
    }
}
