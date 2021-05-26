using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RNC { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Category { get; set; }

    }
    
}