using System.ComponentModel.DataAnnotations;

namespace WebApplication11.Models.Userview
{
    public class RoleFormviewModel
    {
        [Required,StringLength(256)]
        public string Name { get; set; }
    }
}
