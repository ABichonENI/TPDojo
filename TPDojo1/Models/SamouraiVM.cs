using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BO;

namespace TPDojo1.Models
{
    public class SamouraiVM
    {
        public Samourai Samourai { get; set; }

        public List<Arme> Armes { get; set; }
        
        public int? IdArmeSamourai { get; set; }

        public List<ArtMartial> ArtMartials { get; set; }

        public List<int> IdArtmartials { get; set; }

    }
}