namespace IDS_Integrador.Model.Entity.Team
{
    public class Player
    {
        public int Id { get; set;}
        public string Name { get; set;}
        public string Lastname { get; set;}
        public DateOnly Birthday { get; set;}
        public Category Category { get; set;}
        public Team Team {get; set;}

        public Player(int ID, string Name, string Lastname, DateOnly Birthday, Category Category, Team Team)
        {
            this.Id = ID;
            this.Name = Name;
            this.Lastname = Lastname;
            this.Birthday = Birthday;
            this.Category = Category;
            this.Team = Team;            
        }
    }
}