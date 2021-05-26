using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.DTO_s.Products
{
    public class ProductOTO
    {
        public int Id { get; set; }
        public int StockId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
