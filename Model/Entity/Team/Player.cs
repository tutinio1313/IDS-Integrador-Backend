using System.ComponentModel.DataAnnotations;

namespace IDS_Integrador.Model.Entity.Team
{
    public class Player
    {
        [Key]
        public string IDPlayer {get; set;}
        public string Name { get; set;}
        public string Lastname { get; set;}
        public DateOnly Birthday { get; set;}
        public Category Category { get; set;}
        public Team Team {get; set;}
    }
}