using System.ComponentModel.DataAnnotations;

namespace IDS_Integrador.Model.Entity.Team
{
    public class Player
    {
        [Key]
        public string IDPlayer {get; set;} = string.Empty;
        public string Name { get; set;} = string.Empty;
        public string Lastname { get; set;} = string.Empty;
        public DateOnly Birthday { get; set;}
        public Category? Category { get; set;}
        public required Team Team {get; set;} 
    }
}