using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace WebApplication11.Models
{
    [Index(nameof(CODE), IsUnique = true)]
    public class BRANCH
    {
        [Key]
        public int Id { get; set; }
        [NotNull]
        [StringLength(50)]
        public string CODE { get; set; }
        [NotNull]
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(255)]
        public string? ADDRESS { get; set; }
        [Phone]
        [StringLength(25)]
        public string? PHONE { get; set; }
        [EmailAddress]
        [StringLength(255)]
        public string? EMAIL { get; set; }
        [DataType(DataType.Date)]
        [Display(Name="Open Date")]
        public DateTime? OPEN_DATE { get; set; } = null;
        [StringLength(3000)]
        public string? NOTE { get; set; }
        [StringLength(5000)]
        public string? DESCRPTION { get; set; }
        public List<EMPLOYEE>? Employees { get; set; }
        public List<KVM>? KVMS { get; set; }
        public List<PARCODE_MACHINE>? PARCODE_MACHINEs { get; set; }
        public List<PROJECTOR>? PROJECTORs { get; set; }
        public List<RACK>? RACKs { get; set; }
        public List<ROUTER>? ROUTERs { get; set; }
        public List<UPS>? UPs { get; set; }
        public List<SWITCH>? SWITCHes { get; set; }
        public List<WAREHOUSE_STOCK>? WAREHOUSE_STOCK { get; set; }
        public List<WAREHOUSE_STOCK_FOR_CAMRA_DVR>? WAREHOUSE_STOCK_FOR_CAMRA_DVRs { get; set; }
        public List<PRINTER>? PRINTERs { get; set; }
        public List<SURVIEILLANCE>? SURVIEILLANCEs { get; set; }
        public List<ACCESS_POINT>? ACCESS_POINTs { get; set; }



    }
}
