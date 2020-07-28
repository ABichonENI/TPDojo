using System.Collections.Generic;

namespace BO
{
    public class Samourai : DbItem
    {
        public int Id { get; set; }
        public int Force { get; set; }
        public string Nom { get; set; }
        public virtual Arme Arme { get; set; }
        public List<ArtMartial> ArtMartials { get; set; }
        int DbItem.Id { get => this.Id; set => this.Id = value ; }
    }
}
