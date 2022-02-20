using BackendTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTest.Utility
{
    public static class BeverageHelper
    {
        public static List<Beverage> CoffeeToBeverage(List<CoffeeDTO> coffeeDTOList, string imgURL)
        {
            List<Beverage> beverages = new List<Beverage>();

            foreach(CoffeeDTO coffeeDTO in coffeeDTOList)
            {
                beverages.Add(new Beverage
                {
                    Id = Guid.NewGuid(),
                    Name = coffeeDTO.Title,
                    Price = "$" + new Random().Next(8, 20).ToString() + ".99",
                    Rating = Math.Round(GetRandomRating(), 3),
                    Description = coffeeDTO.Description,
                    Image = imgURL
                });
            }

            return beverages;
        }

        public static List<Beverage> BeerToBeverage(List<BeerDTO> beerDTOList)
        {
            List<Beverage> beverages = new List<Beverage>();

            foreach (BeerDTO beerDTO in beerDTOList)
            {
                beverages.Add(new Beverage
                {
                    Id = Guid.NewGuid(),
                    Name = beerDTO.Name,
                    Price = beerDTO.Price,
                    Rating = Math.Round(beerDTO.Rating.Average),
                    Description = GetBeerDescription(beerDTO.Name),
                    Image = beerDTO.Image
                });
            }

            return beverages;
        }

        private static decimal GetRandomRating()
        {
            Random rng = new Random();

            decimal rating = (decimal)rng.Next(1000, 5000) / 1000;

            return rating;
        }

        private static string GetBeerDescription(string name)
        {
            if (name.Contains("Ale"))
                return BeerDescription.Ale;

            if (name.Contains("Porter"))
                return BeerDescription.Porter;

            if (name.Contains("Stout"))
                return BeerDescription.Stout;

            if (name.Contains("Brown Ale"))
                return BeerDescription.BrownAle;

            if (name.Contains("Pale Ale"))
                return BeerDescription.PaleAle;

            if (name.Contains("IPA"))
                return BeerDescription.IPA;

            return "";
        }
    }
}
