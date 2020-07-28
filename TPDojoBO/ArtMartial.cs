using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class ArtMartial : DbItem
    {
        public int Id { get; set; }

        public string Nom { get; set; }

        int DbItem.Id { get => this.Id; set => this.Id = value; }

    }
}
