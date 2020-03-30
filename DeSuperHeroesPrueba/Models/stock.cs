using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DeSuperHeroesPrueba.Models
{
    [Table("stock")]
    public class stock
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public string RNC { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }

        public class mapear
        {
            public mapear(EntityTypeBuilder<stock> mapeo)
            {
                mapeo.HasKey(x => x.id);
            }
        }


    }
}