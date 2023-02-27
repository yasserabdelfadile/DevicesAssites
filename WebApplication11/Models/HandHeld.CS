using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace WebApplication11.Models
{
    [Index(nameof(CODE), IsUnique = true)]
    [Index(nameof(SERIAL_NUMBER),IsUnique =true)]
    public class HANDHELD

    {
        [Key]
        public int Id { get; set; }
        [StringLength(30)]
        [Display(Name ="Code")]
        public string CODE { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name ="Name")]
        public string NAME { get; set; }
        [Required]
        [StringLength(30)]
        [Display(Name ="Model")]
        public string MODEL { get; set; }
        [StringLength(50)]
        [Required]
        [Display(Name ="Serial Number")]
        public string SERIAL_NUMBER { get; set; }
        [StringLength(55)]
        [Required]
        public string Processor { get; set; }
        [StringLength(55)]
        [Required]
        [Display(Name ="Rame Size")]
        public string RAM_SIZE { get; set; }
        [Required]
        [StringLength(55)]
        [Display(Name ="Android Version")]
        public string ANDROID_VERSION { get; set; }
        [Required]
        [Display(Name ="Is Warehouse")]
        public bool Is_warehouse { get; set; } 
        [DataType(DataType.Date)]
        [Display(Name ="Reccived Decvice Date")]
        public DateTime? RECIVED_DEVICE_DATE { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Device delivery date")]
        public DateTime? RE_RECIVED_DEVICE_DATE { get; set; }
        public string? NOTE { get; set; }
        [ForeignKey("EMPLOYEE")]
        public int? EMPLOYEE_ID { get; set; }
        public EMPLOYEE? EMPLOYEE { get; set; }
        [ForeignKey("WAREHOUSE_STOCK")]
        public int? WAREHOUSE_STOCK_ID { get; set; }
        public WAREHOUSE_STOCK? WAREHOUSE_STOCK { get; set; }



    }
}
