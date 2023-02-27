using System.ComponentModel.DataAnnotations;

namespace WebApplication11.Models
{
    public class USERES
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string USERNAME { get; set; }
        [Required]
        public string PASSWORD { get; set; }
    }

}
