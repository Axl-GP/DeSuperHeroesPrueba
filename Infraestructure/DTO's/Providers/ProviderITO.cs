using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Infraestructure.DTO_s.Providers
{
    public class ProviderITO
    {
        [Required]
        [MinLength(3), MaxLength(60)]
        public string Name { get; set; }
        [Required]
        [MinLength(11)]
        public string RNC { get; set; }
        [Required]
        [MinLength(12)]
        public string PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

    }
}
