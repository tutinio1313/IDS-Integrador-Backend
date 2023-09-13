using System.ComponentModel.DataAnnotations;

namespace IDS_Integrador.Model.Entity.Team
{
    public class Team
    {
        [Key]
        public string IDTeam {get; set;} = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string UrlImage {get; set;} = string.Empty;
    }
}