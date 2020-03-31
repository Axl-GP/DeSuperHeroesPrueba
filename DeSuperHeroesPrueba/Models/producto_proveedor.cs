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
    [Table("producto_proveedor")]
    public class producto_proveedor
    {
        [Key]
        public int idproducto_proveedor { get; set; }

     

        public int idproducto { get; set; }

      

        public int idproveedor { get; set; }

        [Required]
        public int cantidad { get; set;
        }
        [Required]
        public DateTime fechaImporte { get; set; }

        public virtual producto producto{get;set;}

        public virtual proveedor proveedor { get; set; }

        public class mapear
        {
            public mapear(EntityTypeBuilder<producto_proveedor> mapeo)
            {
                mapeo.HasKey(x => new { x.idproducto, x.idproducto_proveedor, x.idproveedor });
                mapeo.Property(x => x.cantidad).HasColumnName("cantidad");
                mapeo.Property(x => x.fechaImporte).HasColumnName("fechaImporte");
                mapeo.HasOne(x => new { x.proveedor, x.producto });
                mapeo.ToTable("producto_proveedor");
            }
        }
    }
}
