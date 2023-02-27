using Microsoft.EntityFrameworkCore;

namespace WebApplication11.Models
{
    public class DATABASECONTEXTT: DbContext
    {
        public DATABASECONTEXTT(DbContextOptions<DATABASECONTEXTT> options)
            : base(options)
        {
        }

        public DbSet<DEVICES>? DEVICESES { get; set; }
        public DbSet<EMPLOYEE>? EMPLOYEES { get; set; }
        public DbSet<DEPARTMENT>? DEPARTMENTS { get; set; }
        public DbSet<BRANCH>? BRANCHES { get; set; }
        public DbSet<ACCESS_POINT>? ACCESS_POINTS { get; set; }
        public DbSet<KVM>? KVMS { get; set; }
        public DbSet<PARCODE_MACHINE>? PARCODE_MACHINES { get; set; }
        public DbSet<PRINTER>? PRINTERS { get; set; }
        public DbSet<PROJECTOR>? PROJECTORS { get; set; }
        public DbSet<RACK>? RACKS { get; set; }
        public DbSet<ROUTER>? ROUTERS { get; set; }
        public DbSet<SURVIEILLANCE>? SURVIEILLANCES { get; set; }
        public DbSet<SWITCH>? SWITCHS { get; set; }
        public DbSet<UPS>? UPSES { get; set; }
        public DbSet<HANDHELD>? HANDHELDs { get; set; }
        public DbSet<WAREHOUSE_STOCK>? WAREHOUSE_STOCK { get; set; }
        public DbSet<WAREHOUSE_STOCK_FOR_CAMRA_DVR>? WAREHOUSE_STOCK_FOR_CAMRA_DVRS { get; set; }
        public DbSet<USERES>? USERES { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<SURVIEILLANCE>()
        //        .HasOne(p => p.WAREHOUSE_STOCK_FOR_CAMRA_DVR)
        //        .WithMany(p => p.SURVIEILLANCEs);
        //}
    }
    
}
