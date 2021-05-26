using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.DTO_s.Entries
{
    public class EntryOTO
    {
        public int ProductProviderId { get; set; }
        public int ProductId { get; set; }
        public int ProviderId { get; set; }
        public int Quantity { get; set; }
        public DateTime ImportDate { get; set; }
        public string Date { get { return ImportDate.ToString("dd-MM-yyyy"); } }
    }
}
