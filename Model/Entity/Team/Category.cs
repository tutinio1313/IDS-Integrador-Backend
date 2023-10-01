using System.ComponentModel.DataAnnotations;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace IDS_Integrador.Model.Entity.Team
{
    public class Category
    {
        [Key]
        public int IdCategory { get; set;}
        public string Name {get; set;} = string.Empty;
    }
}