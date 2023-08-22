using System.ComponentModel.DataAnnotations;

namespace IDS_Integrador.Model.Entity.Team
{
    public class Match
    {
        [Key]
        public string IDMatch {get; set;}
        public DateTime Date { get; set; }
        public Team LocalTeam {get; set;}
        public Team VisitTeam {get; set;}

        public int LocalTeamGoals {get; set;} = 0;
        public int VisitTeamGoals {get; set;} = 0;
    }
}