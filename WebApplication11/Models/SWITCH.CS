using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


namespace WebApplication11.Models
{
    [Index(nameof(CODE), IsUnique = true)]
    [Index(nameof(SERIAL_NUMBER), IsUnique = true)]
    public class SWITCH
    {
        [Key]
        public int ID { get; set; }
        [StringLength(255)]

        public string Name { get; set; }
        [StringLength(50)]

        public string CODE { get; set; }
        [StringLength(255)]
        public string? TYPE { get; set; }
        [StringLength(255)]
        [Display(Name = "Serial No")]
        public string SERIAL_NUMBER { get; set; }
        [StringLength(255)]
        public string LOCATION { get; set; }
       
        [StringLength(255)]
        [Display(Name = "Number Of Ports")]
        public string? NUMBER_OF_PORTS { get; set; }
        [StringLength(255)]
        [Display(Name = "Additional Ports")]
        public string? ADDTIONAL_PORTS { get; set; }
        [StringLength(255)]
        [Display(Name = "IP Address")]
        public string? IP_ADDRESS { get; set; }
        [Display(Name = "Is Warehouse")]
        public bool is_warehouse { get; set; }
        [StringLength(255)]
        public string? NOTE { get; set; }
        [ForeignKey("WAREHOUSE_STOCK")]
        public int? WAREHOUSE_STOCK_ID { get; set; }
        public WAREHOUSE_STOCK? WAREHOUSE_STOCK { get; set; }
        [ForeignKey("BRANCH")]
        public int? BRANCH_ID { get; set; }
        public BRANCH? BRANCH { get; set; }
    }

}
