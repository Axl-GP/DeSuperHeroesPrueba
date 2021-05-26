using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infraestructure.DTO_s.Sells
{
    public class SellITO
    {
        [Required]
        [Range(minimum: 1, maximum: int.MaxValue)]
        public int ClientId { get; set; }
        [Required]
        [Range(minimum: 1, maximum: int.MaxValue)]
        public int ProductId { get; set; }
        [Required]
        [Range(minimum: 1, maximum: int.MaxValue)]
        public int Quantity { get; set; }
        public DateTime BillDate { get { return DateTime.UtcNow; } }
    }
}
