using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public int StockId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Stock Stock { get; set; }

    }
}