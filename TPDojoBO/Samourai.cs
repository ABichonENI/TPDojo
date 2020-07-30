using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BO
{
    public class Samourai : DbItem
    {
        private int id;
        public int Force { get; set; }
        public string Nom { get; set; }
        public virtual Arme Arme { get; set; }
        public virtual List<ArtMartial> ArtMartials { get; set; }
        public int Id { get => this.id; set => this.id = value ; }
        
        [NotMapped]
        public int Potentiel 
        { get
            {
                int samPotentiel = this.Force;
            
                if (this.Arme != null)
            {
                samPotentiel  += this.Arme.Degats;
            }
                //samPotentiel *= (this.ArtMartials.Count);
                return samPotentiel;
            }
            }
    }
}
