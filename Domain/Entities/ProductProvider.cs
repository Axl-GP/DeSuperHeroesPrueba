using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProductProvider
    {
        public int ProductProviderId { get; set; }
        public int ProductId { get; set; }
        public int ProviderId { get; set; }
        public int Quantity { get; set;}
        public DateTime ImportDate { get; set; }
        public Product Product {get;set;}
        public Provider Provider { get; set; }

    }
}
