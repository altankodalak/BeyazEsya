using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeyazEsya.Models
{
    public class Sogutucu:BeyazEsya
    {
        public SogutucuTıp SogutucuTıp { get; set; }
        public int Hacım { get; set; }
    }
}