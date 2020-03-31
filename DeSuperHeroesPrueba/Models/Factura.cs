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
    [Table("factura")]
    public class Factura
    {
        [Key]
        public int idFactura { get; set; }
        
        public int idCliente { get; set; }

        [Required, Range(1,50)]
        public int cantidad { get; set; }

        [Required]
        public decimal total { get; set; }
        [Required]
        public DateTime fecha { get; set; }
        public Cliente cliente { get; set; }

         public class mapear
        {
            public mapear(EntityTypeBuilder<Factura> mapeo)
            {
                mapeo.HasKey(x => x.idFactura);
                mapeo.Property(x => x.fecha).HasColumnName("fecha");
                mapeo.Property(x => x.cantidad).HasColumnName("canidad");
                mapeo.Property(x => x.total).HasColumnName("total");
                mapeo.HasOne(x => x.cliente);
                mapeo.ToTable("factura");

            }
        }
    }
}