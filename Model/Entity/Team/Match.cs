using System.ComponentModel.DataAnnotations;

namespace IDS_Integrador.Model.Entity.Team
{
    public class Match
    {
        [Key]
        public string IDMatch {get; set;} = String.Empty;
        public DateTime Date { get; set; }
        public required Team LocalTeam {get; set;}
        public required Team VisitTeam {get; set;}

        public int LocalTeamGoals {get; set;} = 0;
        public int VisitTeamGoals {get; set;} = 0;
    }
}