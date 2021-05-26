using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infraestructure.DTO_s.Entries
{
    public class EntryITO
    {
        [Required]
        [Range(minimum:1, maximum:int.MaxValue)]
        public int ProductId { get; set; }
        [Required]
        [Range(minimum: 1, maximum: int.MaxValue)]
        public int ProviderId { get; set; }
        [Required]
        [Range(minimum: 1, maximum: int.MaxValue)]
        public int Quantity { get; set; }
        public DateTime ImportDate { get; set; }
        
    }
}
