using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
 

namespace WebApplication11.Models
{
    [Index(nameof(Code), IsUnique = true)]
    [Index(nameof(Serial_Number), IsUnique = true)]
    public class SURVIEILLANCE
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Code { get; set; }
        [StringLength(255)]
        public string Model { get; set; }
        [StringLength(255)]
        public string? Type { get; set; }
        [StringLength(255)]
        [Display(Name = "Serial No")]
        public string Serial_Number { get; set; }
        [StringLength(255)]
        [Display(Name = "Internial IP")]

        public string Internail_Ip { get; set; }
        [Display(Name = "Enternial IP")]
        [StringLength(255)]
        public string Externail_IP { get; set; }
        [StringLength(255)]
        [Display(Name = "Port Number")]
        public string Port_number { get; set; }
        [StringLength(255)]
        [Display(Name = "DVR&NVR Model")]
        public string? DVR_NVR_MODEL { get; set; }
        [StringLength(255)]
        [Display(Name = "Number Of Channel")]
        public string NUMBER_OF_CHANNEL { get; set; }
        [StringLength(255)]
        [Display(Name = "Used Channel")]
        public string USED_CHANNEL { get; set; }
        [StringLength(255)]
        [Display(Name = "Conectivety Type")]
        public string CONECTIVETY_TYPE { get; set; }
        [StringLength(255)]
        public string STORAGE { get; set; }
        [StringLength(255)]
        [Display(Name = "User Login")]
        public string USER_LOGIN { get; set; }
        [StringLength(255)]
        public string PASSWORD { get; set; }
        [StringLength(255)]
        [Display(Name = "Verification Code")]
        public string VERIFICATION_CODE { get; set; }
        [Display(Name = "Is Warehouse")]
        public bool is_warehouse { get; set; }
        [StringLength(3000)]
        public string? Note { get; set; }
        [ForeignKey("BRANCH")]
        public int? BRANCH_ID { get; set; }
        public BRANCH? BRANCH { get; set; }
         [ForeignKey("WAREHOUSE_STOCK_FOR_CAMRA_DVR")]
        public int? WAREHOUSE_STOCK_FOR_CAMRA_DVR_ID { get; set; }
        public WAREHOUSE_STOCK_FOR_CAMRA_DVR? WAREHOUSE_STOCK_FOR_CAMRA_DVR { get; set; }
    }

}
