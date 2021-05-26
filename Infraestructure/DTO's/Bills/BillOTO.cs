using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.DTO_s.Bill
{
    public class BillOTO
    {
        public int BillId { get; }
        public int Quantity { get; }
        public decimal Total { get; }
        public DateTime Date { get; }
        public Client Client { get; }
    }
}
