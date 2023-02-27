using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace WebApplication11.Models
{
    [Index(nameof(CODE), IsUnique = true)]
    public class DEPARTMENT
    {
        [Key]
        public int ID { get; set; }
        [NotNull]
        [StringLength(100)]
        [Required]
        public string Name { get; set; }
        [StringLength(50)]
        public string CODE { get; set; }
        [Phone]
        [StringLength(25)]
        public string? PHONE { get; set; }
        [EmailAddress]
        [StringLength(255)]
        public String? EMAIL { get; set; }
        [StringLength(3000)]
        public string? NOTE { get; set; }
        [StringLength(5000)]
        public string? Description { get; set; }
        [ForeignKey("BRANCH")]
        public int? BRANCH_ID { get; set; }
        public BRANCH? BRANCH { get; set; }

    }
}
