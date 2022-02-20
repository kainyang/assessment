using BackendTest.Interfaces;
using BackendTest.Models;
using BackendTest.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BackendTest.Services
{
    public class DrinksService : IDrinksService
    {
        private readonly HttpClient _httpClient;

        public DrinksService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Beverage>> GetCoffees()
        {
            //Beers: https://api.sampleapis.com/beers/ale 

            var responseString = await _httpClient.GetStringAsync("https://api.sampleapis.com/coffee/hot");

            var randomCoffeeResponse = await _httpClient.GetStringAsync("https://coffee.alexflipnote.dev/random.json");

            List<CoffeeDTO> coffees = JsonConvert.DeserializeObject<List<CoffeeDTO>>(responseString);

            CoffeeImageDTO randomCoffeeImage = JsonConvert.DeserializeObject<CoffeeImageDTO>(randomCoffeeResponse);

            return BeverageHelper.CoffeeToBeverage(coffees, randomCoffeeImage.File);
        }

        public async Task<List<Beverage>> GetBeers()
        {
            var responseString = await _httpClient.GetStringAsync("https://api.sampleapis.com/beers/ale");

            List<BeerDTO> beers = JsonConvert.DeserializeObject<List<BeerDTO>>(responseString);

            return BeverageHelper.BeerToBeverage(beers);
        }
    }
}
