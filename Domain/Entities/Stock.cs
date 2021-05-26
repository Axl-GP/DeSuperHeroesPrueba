
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Stock
    {
        public int Id { get; set; }   
        public string ProductType { get; set; }
        public int Quantity { get; set; }
        public DateTime LastDate { get; set; }
        public string Image { get; set; }
        

    }
}