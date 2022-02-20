using BackendTest.Interfaces;
using BackendTest.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackendTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CafeController : ControllerBase
    {
        private readonly IStoreService _storeService;
        private readonly IEmployeeService _employeeService;

        public CafeController(IStoreService storeService, IEmployeeService employeeService)
        {
            _storeService = storeService;
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<Store>> Get(string location)
        {
            var store = await _storeService.GetByLocationAsync(location.ToLower());

            if (store is null)
            {
                return NotFound();
            }

            return store;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Store store)
        {
            try
            {
                await _storeService.CreateAsync(store);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex);
            }

            return Ok();
        }

        [HttpGet("Employees")]
        public async Task<ActionResult<List<Employee>>> Employees()
        {
            var employees = await _employeeService.GetEmployeesAsync();

            if (employees is null)
            {
                return NotFound();
            }

            return employees;
        }

        [HttpPost("Employee")]
        public async Task<IActionResult> Employee([FromBody] Employee employee)
        {
            try
            {
                await _employeeService.CreateAsync(employee);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex);
            }

            return Ok();
        }
    }
}
