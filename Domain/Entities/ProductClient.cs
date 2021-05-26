using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProductClient
    {
        public int ProductClientId { get; set; }
        public int ClientId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime BillDate { get; set; }
        public Product Product { get; set; }
        public Client Client { get; set; }

    }
}
