using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JarmuKolcsonzo.Web.Models
{
    [ModelMetadataType(typeof(rendelesMeta))]
    public partial class rendeles
    {
        [NotMapped]
        public bool ArKalkulacio { get; set; }
    }

    public class rendelesMeta
    {
        [DisplayName("Dátum")]
        [DataType(DataType.Date)]
        public DateTime datum { get; set; }
        [DisplayName("Napok száma")]
        public int napok_szama { get; set; }
        [DisplayName("Ár")]
        [DataType(DataType.Currency)]
        public decimal ar { get; set; }

        [DisplayName("Jármű")]
        public int jarmu_id { get; set; }

        [DisplayName("Ügyfél")]
        public int ugyfel_id { get; set; }
    }
}
