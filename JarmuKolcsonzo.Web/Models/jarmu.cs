using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace JarmuKolcsonzo.Web.Models
{
    [Index(nameof(rendszam), Name = "rendszam", IsUnique = true)]
    [Index(nameof(tipus_id), Name = "tipus_id")]
    public partial class jarmu
    {
        public jarmu()
        {
            rendeles = new HashSet<rendeles>();
        }

        [Key]
        [Column(TypeName = "int(11)")]
        public int id { get; set; }
        [Required]
        [StringLength(7)]
        public string rendszam { get; set; }
        [Column(TypeName = "int(11)")]
        public int tipus_id { get; set; }
        [Column(TypeName = "int(5)")]
        public int dij { get; set; }
        public bool elerheto { get; set; }
        [Column(TypeName = "date")]
        public DateTime? szerviz_datum { get; set; }

        [ForeignKey(nameof(tipus_id))]
        [InverseProperty(nameof(jarmu_tipus.jarmu))]
        public virtual jarmu_tipus tipus { get; set; }
        [InverseProperty("jarmu")]
        public virtual ICollection<rendeles> rendeles { get; set; }
    }
}
