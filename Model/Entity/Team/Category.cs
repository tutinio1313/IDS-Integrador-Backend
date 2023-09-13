using System.ComponentModel.DataAnnotations;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace IDS_Integrador.Model.Entity.Team
{
    public class Category
    {
        [Key]
        public string IdCategory { get; set;} = string.Empty;
        public string Name {get; set;} = string.Empty;
    }
}