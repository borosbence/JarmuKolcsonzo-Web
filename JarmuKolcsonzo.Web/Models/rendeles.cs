using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace JarmuKolcsonzo.Web.Models
{
    [Index(nameof(jarmu_id), Name = "jarmu_id")]
    [Index(nameof(ugyfel_id), Name = "ugyfel_id")]
    public partial class rendeles
    {
        [Key]
        [Column(TypeName = "int(11)")]
        public int id { get; set; }
        [Column(TypeName = "int(11)")]
        public int ugyfel_id { get; set; }
        [Column(TypeName = "int(11)")]
        public int jarmu_id { get; set; }
        [Column(TypeName = "date")]
        public DateTime datum { get; set; }
        [Column(TypeName = "int(3)")]
        public int napok_szama { get; set; }
        public decimal ar { get; set; }

        [ForeignKey(nameof(jarmu_id))]
        [InverseProperty("rendeles")]
        public virtual jarmu jarmu { get; set; }
        [ForeignKey(nameof(ugyfel_id))]
        [InverseProperty("rendeles")]
        public virtual ugyfel ugyfel { get; set; }
    }
}
