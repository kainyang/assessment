using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTest.Models
{
    public class CoffeeDTO
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string[] Ingredients { get; set; }
    }

    public class CoffeeImageDTO
    {
        public string File { get; set; }
    }
}
