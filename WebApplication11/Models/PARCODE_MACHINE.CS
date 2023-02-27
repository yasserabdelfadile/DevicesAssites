using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace WebApplication11.Models
{
    [Index(nameof(CODE), IsUnique = true)]
    [Index(nameof(SERIAL_NUMBER), IsUnique = true)]
    public class PARCODE_MACHINE
    {
        [Key]
        public int ID { get; set; }
        [StringLength(50)]
        public string CODE { get; set; }
        [StringLength(255)]
        public string MODEL { get; set; }
        [StringLength(255)]
        public string? TYPE { get; set; }
        [StringLength(255)]
        [Display(Name = "Serial No")]
        public string SERIAL_NUMBER { get; set; }
        [Display(Name = "Is Warehouse")]
        public bool Is_Warehouse { get; set; }
        [StringLength(3000)]
        public string? NOTE { get; set; }
        [ForeignKey("BRANCH")]
        public int? BRANCH_ID { get; set; }
        public BRANCH? BRANCH { get; set; }
       
       
        [ForeignKey("WAREHOUSE_STOCK")]
        public int? WAREHOUSE_STOCK_ID { get; set; }
        public WAREHOUSE_STOCK? WAREHOUSE_STOCK { get; set; }
    }
}
