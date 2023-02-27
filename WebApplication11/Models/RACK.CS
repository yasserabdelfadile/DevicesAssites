using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


namespace WebApplication11.Models
{

    [Index(nameof(CODE), IsUnique = true)]
         public class RACK
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string CODE { get; set; }
        [StringLength(255)]
         
        public string Name { get; set; }
        [StringLength(255)]
        public string? Type { get; set; }
        [StringLength(255)]
         public string LOCATION { get; set; }
        [Display(Name = "Is Warehouse")]
        public bool is_warehouse { get; set; }
        [StringLength(3000)]
        public string? NOTE { get; set; }
        [StringLength(5000)]
        public string? DESCRPTION { get; set; }
        [ForeignKey("BRANCH")]
        public int? BRANCH_ID { get; set; }
        public BRANCH? BRANCH { get; set; }
       
         [ForeignKey("WAREHOUSE_STOCK")]
        public int? WAREHOUSE_STOCK_ID { get; set; }
        public WAREHOUSE_STOCK? WAREHOUSE_STOCK { get; set; }
    }
}
