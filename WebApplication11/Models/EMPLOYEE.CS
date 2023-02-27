using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace WebApplication11.Models
{
    [Index(nameof(CODE), IsUnique = true)]

    public class EMPLOYEE
    {
        [Key]
        public int ID { get; set; }
        [NotNull]
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(50)]
        public string CODE { get; set; }
        [Phone]
        [StringLength(25)]
        public string? PHONE { get; set; }
        [EmailAddress]
        [StringLength(255)]
        public String? EMAIL { get; set; }
        [StringLength(255)]
        public String? ADDRESS { get; set; }
        [StringLength(3000)]
        public String? NOTE { get; set; }
        [DataType(DataType.Date)]
        [Display(Name="Starte Date")]
        public DateTime? STARTEDATE { get; set; }
        [DataType(DataType.Date)]
        [Display(Name="End Date")]
        public DateTime? ENDDATE { get; set; }
        [ForeignKey("BRANCH")]
        public int? BRANCH_ID { get; set; }
        public BRANCH? BRANCH { get; set; }
        [ForeignKey("DEPARTMENT")]
        public int? DEPARTMENT_ID { get; set; }
        public DEPARTMENT? DEPARTMENT { get; set; } = null;
        public List<DEVICES>? DEVICESES { get; set; }
        public List<HANDHELD>? handHelds { get; set; }


    }
}
