using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace WebApplication11.Models
{

    [Index(nameof(CODE), IsUnique = true)]
    [Index(nameof(SERIAL_NUMBER), IsUnique = true)]
    public class ACCESS_POINT
    {
        [Key]
        public int ID { get; set; }
          [StringLength(255)]
        public string Name { get; set; }
        [StringLength(55)]
        [NotNull]
        public string CODE { get; set; }
        [NotNull]
        [StringLength(55)]
        public string? TYPE { get; set; }
         [StringLength(55)]
        [Display(Name = "Serial No")]
        public string SERIAL_NUMBER { get; set; }
        [NotNull]
        [StringLength(55)]
        public string LOCATION { get; set; }

        [StringLength(5000)]
        public string? NOTE { get; set; }
        [StringLength(6000)]
        public string? DESCRPTION { get; set; }
        [Display(Name = "Is Warehouse")]
        public bool Is_Warehouse { get; set; }
        [ForeignKey("BRANCH")]
        public int? BRANCH_ID { get; set; }
        public BRANCH? BRANCH { get; set; }
        
        [ForeignKey("WAREHOUSE_STOCK")]
        public int? WAREHOUSE_STOCK_ID { get; set; }
    
        public WAREHOUSE_STOCK? WAREHOUSE_STOCK { get; set; }

    }
}


