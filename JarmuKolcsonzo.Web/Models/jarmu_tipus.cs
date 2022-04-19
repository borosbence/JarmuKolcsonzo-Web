using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace JarmuKolcsonzo.Web.Models
{
    public partial class jarmu_tipus
    {
        public jarmu_tipus()
        {
            jarmu = new HashSet<jarmu>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        public string megnevezes { get; set; }
        [Column(TypeName = "int(2)")]
        public int ferohely { get; set; }

        [InverseProperty("tipus")]
        public virtual ICollection<jarmu> jarmu { get; set; }
    }
}
