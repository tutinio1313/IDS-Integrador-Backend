using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace IDS_Integrador.Model.Entity.Team
{
    public class Match
    {
        [Key]
        public int IDMatch {get; set;}
        public DateTime Date { get; set; }
        //Team[] teams = new Team[2];  The first place on the array is for the local Player and the second one is for the visitor team.
        public required int LocalTeamID {get; set;}
        public required int VisitorTeamID {get; set;}
        
        [ForeignKey("CategoryID")]
        public required Category category {get; set;}
        public int LocalTeamGoals {get; set;} = 0;
        public int VisitTeamGoals {get; set;} = 0;
    }
}