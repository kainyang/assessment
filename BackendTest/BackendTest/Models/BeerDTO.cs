using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTest.Models
{
    public class BeerDTO
    {
        public string Name { get; set; }

        public string Price { get; set; }

        public Rating Rating { get; set; }

        public string Image { get; set; }
    }

    public class Rating
    {
        public decimal Average { get; set; }

        public int Reviews { get; set; }
    }
}
