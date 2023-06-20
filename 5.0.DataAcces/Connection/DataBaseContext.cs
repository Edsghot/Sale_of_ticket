using _0._0.DataTransfer.DtoAdditional;
using _5._0.DataAcces.Entity;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;

namespace _5._0.DataAcces.Connection
{
    public class DataBaseContext:DbContext
    {
        public DataBaseContext()
        {
            InitAutoMapper.Start();
        }

        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<AdministratorOpening> AdministratorsOpening { get; set; }
        public DbSet<Opening> Openings { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Period> Periods { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleDetail> SaleDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DtoAppSettings.connectionStringSqlServer);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrator>().ToTable("Administrator");
            modelBuilder.Entity<AdministratorOpening>().ToTable("AdministratorOpening");
            modelBuilder.Entity<Opening>().ToTable("Opening");
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Period>().ToTable("Period");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Sale>().ToTable("Sale");
            modelBuilder.Entity<SaleDetail>().ToTable("SaleDetail");
            base.OnModelCreating(modelBuilder);
        }
    }
}
