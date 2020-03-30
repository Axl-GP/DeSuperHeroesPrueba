
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DeSuperHeroesPrueba.Models
{
    [Table("proveedor")]
    public partial class proveedor
    {
        [Key]
        public int id { get; set; }
        [Required, MinLength(3), MaxLength(40)]
        public string nombre { get; set; }
        [Required]

        public string RNC { get; set; }
        [Required]
        public string telefono { get; set; }

        [Required,EmailAddress]
        public string email { get; set; }

        class mapear
        {
            public mapear(EntityTypeBuilder<proveedor> mapeo)
            {
                mapeo.HasKey(x => x.id);
            }
        }
    }

    
}