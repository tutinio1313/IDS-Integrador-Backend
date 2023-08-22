namespace IDS_Integrador.Model.Entity.Team
{
    public class Team
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string UrlImage {get; set;} = string.Empty;

        public Team(int ID, string Name, string UrlImage)
        {
            this.ID = ID;
            this.Name = Name;
            this.UrlImage = UrlImage;            
        }
    }
}