namespace BO
{
    public class Arme : DbItem
    {
        private int id;
        public string Nom { get; set; }
        public int Degats { get; set; }

        public int Id { get => this.id; set => this.id = value; }

    }
}