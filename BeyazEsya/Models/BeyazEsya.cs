using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeyazEsya.Models
{
    public abstract class BeyazEsya
    {
        [Key]
        public int Id { get; set; }
        public string Model { get; set; }
        public string Renk { get; set; }
        public Boyutlar Boyutlar { get; set; }
        [ForeignKey("Kategorı")]
        public int KategorıId { get; set; }
        public virtual Kategorı Kategorı { get; set; }
    }
}