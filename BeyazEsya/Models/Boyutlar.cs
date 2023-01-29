using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BeyazEsya.Models
{
    [ComplexType] //PrimaryKeyi olan bir class değildir.İçindeki prop ların başka bir class da kullanılması için oluşturulur.
    public class Boyutlar
    {
        public int En { get; set; }
        public int Boy { get; set; }
        public int Derinlik { get; set; }

    }
}