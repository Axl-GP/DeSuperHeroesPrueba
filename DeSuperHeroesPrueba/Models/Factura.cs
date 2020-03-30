using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DeSuperHeroesPrueba.Models
{
    [Table("factura")]
    public class Factura
    {
        [Key]
        public int id { get; set; }
        
        public int idCliente { get; set; }

        [Required, Range(1,50)]
        public int cantidad { get; set; }

        [Required]
        public double total { get; set; }
        [Required]
        public DateTime fecha { get; set; }
        public virtual Cliente Cliente { get; set; }

        class mapear
        {
            public mapear(EntityTypeBuilder<Factura> mapeo)
            {
                mapeo.HasKey(x => x.id);
            }
        }
    }
}