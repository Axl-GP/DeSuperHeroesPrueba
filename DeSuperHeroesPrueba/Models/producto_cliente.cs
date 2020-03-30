using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DeSuperHeroesPrueba.Models
{
    [Table("producto_cliente")]
    public class producto_cliente
    {
        [Key]

        public int idproducto_cliente { get; set; }
        public int idcliente { get; set; }
        public int idproducto { get; set; }
        [Required]
        public int cantidad { get; set; }
    
        public DateTime fechaFactura { get; set; }

        public virtual producto producto { get; set; }
        public virtual Cliente cliente { get; set; }

        public class mapear
        {
            public mapear(EntityTypeBuilder<producto_cliente> mapeo)
            {
                mapeo.HasKey(x => new { x.idproducto, x.idcliente, x.idproducto_cliente });

            }
        }
    }
}
