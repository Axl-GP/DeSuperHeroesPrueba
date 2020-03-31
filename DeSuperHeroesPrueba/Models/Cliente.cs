using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DeSuperHeroesPrueba.Models
{
    [Table("cliente")]
    public partial class Cliente
    {
        [Key]
        public int ID { get; set; }
        [Required, MinLength(3), MaxLength(50)]
        public string nombre { get; set; }
        [Required]
        public string RNC { get; set; }
        [Required, Phone]
        public string telefono { get; set; }
        [Required, EmailAddress]
        public string email { get; set; }
        [Required]
        public string categoria { get; set; }

        

        public class mapear
        {
            public mapear(EntityTypeBuilder<Cliente> mapeo)
            {
                mapeo.HasKey(x => x.ID);
            }
        }
    }
    
}