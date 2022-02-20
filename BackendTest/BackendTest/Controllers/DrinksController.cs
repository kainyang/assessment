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
    public class DrinksController : ControllerBase
    {
        private readonly IDrinksService drinksService;

        public DrinksController(IDrinksService drinksService)
        {
            this.drinksService = drinksService;
        }

        [HttpGet]
        public async Task<List<Beverage>> Get(DrinksType type)
        {
            if (type == DrinksType.Coffee)
            {
                try
                {
                    return await drinksService.GetCoffees();
                }
                catch(Exception ex)
                {
                    throw new Exception("Error: " + ex);
                }
            }

            if (type == DrinksType.Beers)
            {
                try
                {
                    return await drinksService.GetBeers();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error: " + ex);
                }
            }

            throw new Exception("Error: Wrong type given");
        }
    }
}
