using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeyazEsya.Models
{
    public class Kategorı //A+,B,C gibi enerji sınıflarının kategorisi gibi düşün
    {
        [Key]
        public int Id { get; set; }

        [Required] //Kullanıcının boş geçmesine izin vermez.
        [MaxLength(50)] //Karakter sayısını belirler.
         public string KategorıAdi { get; set; }

        public virtual List<BeyazEsya> Urunler { get; set; }
    }
}