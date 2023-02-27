using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace WebApplication11.Models
{
    [Index(nameof(CODE), IsUnique = true)]

    public class WAREHOUSE_STOCK
    {
        [Key]
        public int ID { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(50)]
        public string CODE { get; set; }
        [StringLength(255)]
        public string? Type { get; set; }
        [StringLength(5000)]
        public string? NOTE { get; set; }
        [ForeignKey("BRANCH")]
        public int? BRANCH_ID { get; set; }
        public BRANCH? BRANCH { get; set; }
        public List<DEVICES>? DEVICEs { get; set; }
        public List<HANDHELD>? handHelds { get; set; }
        public List<ACCESS_POINT>? ACCESS_POINT { get; set; }
        public List<KVM>? KVMS { get; set; }
        public List<UPS>? UPSS { get; set; }
        public List<RACK>? RACKs { get; set; }
        public List<SWITCH>? SWITCHs { get; set; } = null;
        public List<ROUTER>? ROUTERs { get; set; }
        public List<PARCODE_MACHINE>? PARCODE_MACHINEs { get; set; }
        public List<PROJECTOR>? PROJECTORs { get; set; }
        public List<PRINTER>? PRINTERs { get; set; }

    }

}
