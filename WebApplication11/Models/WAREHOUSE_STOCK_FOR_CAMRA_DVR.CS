using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;


namespace WebApplication11.Models
{
    [Index(nameof(CODE), IsUnique = true)]

    public class WAREHOUSE_STOCK_FOR_CAMRA_DVR
    {
        [Key]
        public int ID { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(50)]
        public string CODE { get; set; }
        [StringLength(255)]
        public string? TYPE { get; set; }

        [StringLength(5000)]
        public string? NOTE { get; set; }
        [ForeignKey("BRANCH")]
        public int? BRANCH_ID { get; set; }
        public BRANCH? BRANCH { get; set; } 
        public List<SURVIEILLANCE>? SURVIEILLANCEs { get; set; }
    }

}
