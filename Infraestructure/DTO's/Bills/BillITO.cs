using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infraestructure.DTO_s.Bills
{
    public class BillITO
    {
        [Required]
        public int ClientId { get; set; }
        [Required]
        [Range(minimum: 1,maximum:int.MaxValue,ErrorMessage ="La cantidad de productos comprados debe ser mayor a 1.")]
        public int Quantity { get; set; }
        [Required]
        public decimal Total { get; set; }
        public DateTime Date { get { return DateTime.UtcNow; } }

    }
}
