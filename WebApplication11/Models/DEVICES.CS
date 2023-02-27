using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace WebApplication11.Models
{
    [Index(nameof(CODE), IsUnique = true)]
    [Index(nameof(Name), IsUnique = true)]
    [Index(nameof(SERIAL_NO), IsUnique = true)]
    public class DEVICES
    {
        [Key]
        public int ID { get; set; }
        [StringLength(50)]
        public string CODE { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(255)]
        public string? TYPE { get; set; }
        [StringLength(255)]
        [Display(Name = "Model No")]
        public String MODEL_NO { get; set; }
        [StringLength(255)]
        [Display(Name = "Serial No")]
        public String SERIAL_NO { get; set; }
        [StringLength(255)]
        public String PROCESSOR { get; set; }
        [StringLength(255)]
        [Display(Name = "Rame Size")]
        public String RAME_SIZE { get; set; }
        [StringLength(255)]
        public String QUANTITY { get; set; }
        [StringLength(255)]
        [Display(Name = "Bus Speed")]
        public String BUS_SPEED { get; set; }
        [StringLength(255)]
        [Display(Name = "Ram Generation")]
        public String RAM_GENERATION { get; set; }
        [StringLength(255)]
        public String HDD { get; set; }
        [StringLength(255)]
        [Display(Name = "SDD&Nvme")]
        public String SDD_NVME { get; set; }
        [StringLength(255)]
        [Display(Name = "Mointor Branch&Inch")]
        public String MOINTOR_BRANCH_INCH { get; set; }
        [Display(Name="Bisos Version")]
        [StringLength(255)]
        public String BIOS_VERSION { get; set; }
        [StringLength(255)]
        public String WINDOWS { get; set; }
        [Display(Name="Recived Device Date")]
        [DataType(DataType.Date)]
        public DateTime? RECIVED_DEVICE_DATE { get; set; }
        [DataType(DataType.Date)]
        [Display(Name= "Date of receipt of the device")]
        public DateTime? RE_RECIVED_DEVICE_DATE { get; set; }
        [Display(Name = "Is Warehouse")]
        public bool Is_Warehouse { get; set; }
        [StringLength(3000)]
        public String? NOTE { get; set; }
        [ForeignKey("EMPLOYEE")]
        public int? EMPLOYEE_ID { get; set; }
        public EMPLOYEE? EMPLOYEE { get; set; }
        [ForeignKey("WAREHOUSE_STOCK")]
        public int? WAREHOUSE_STOCK_ID { get; set; }
        public WAREHOUSE_STOCK? WAREHOUSE_STOCK { get; set; }


    }
}
