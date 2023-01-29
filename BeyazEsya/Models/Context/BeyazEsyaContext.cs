using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BeyazEsya.Models.Context
{
    public class BeyazEsyaContext:DbContext
    {
        public virtual DbSet<Kategorı> Kategoriler { get; set; }
        public virtual DbSet<CamasırMakınesı> CamasırMakınesı { get; set; }
        public virtual DbSet<Sogutucu> Sogutucu { get; set; }
        
    }
}