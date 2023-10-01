using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace IDS_Integrador.Model.Entity.Team
{
    public class Player
    {
        [Key]
        public required int IDPlayer {get; set;}
        public required string Dorsal {get; set;} = string.Empty; 
        public required string Name { get; set;} = string.Empty;
        public required string Lastname { get; set;} = string.Empty;
        public required DateOnly Birthday { get; set;} 
        public required int CategoryID { get; set;}
        public required int TeamID {get; set;} 
    }
}