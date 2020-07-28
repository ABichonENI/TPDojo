namespace BO
{
    public class Arme : DbItem
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public int Degats { get; set; }

        int DbItem.Id { get => this.Id; set => this.Id = value; }

    }
}