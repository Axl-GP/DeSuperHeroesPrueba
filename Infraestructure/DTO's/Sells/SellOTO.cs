using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.DTO_s.Sells
{
    public class SellOTO
    {
        public int ProductClientId { get; set; }
        public int ClientId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime BillDate { get; set; }
    }
}
