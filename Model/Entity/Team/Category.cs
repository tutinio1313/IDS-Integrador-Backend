namespace IDS_Integrador.Model.Entity.Team
{
    public class Category
    {
        public int ID {get; set;}
        public string Name {get; set;} = string.Empty;

        public Category(int ID, string Name)
        {
            this.ID = ID;
            this.Name = Name;            
        }          
    }
}