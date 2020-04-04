using Microsoft.EntityFrameworkCore;
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

        public int Stockid { get; set; }
        [Required, MinLength(3), MaxLength(40)]
        public string nombre { get; set; }
        [Required]
        public decimal precio { get; set; }
        public stock Stock { get; set; }


        public class mapear
        {
            public mapear(EntityTypeBuilder<producto> mapeo)
            {
                mapeo.HasKey(x => x.id);
                mapeo.Property(x => x.nombre).HasColumnName("nombre");
                mapeo.Property(x => x.precio).HasColumnName("precio");
                mapeo.HasOne(x => x.Stock);
                mapeo.ToTable("producto");

            }
        }
    }
}