using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DeSuperHeroesPrueba.Models
{
    [Table("producto")]
    public class producto
    {
        [Key]
        public int id { get; set; }
        public int idStock { get; set; }
        [Required, MinLength(3), MaxLength(40)]
        public string nombre { get; set; }
        [Required]
        public double precio { get; set; }
        public virtual stock Stock { get; set; }


        public class mapear
        {
            public mapear(EntityTypeBuilder<producto> mapeo)
            {
                mapeo.HasKey(x => x.id);
            }
        }
    }
}