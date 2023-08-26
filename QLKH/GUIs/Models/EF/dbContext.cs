using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace GUIs.Models.EF
{
    public partial class dbContext : DbContext
    {
        public dbContext()
            : base("name=dbContext")
        {
        }

        public virtual DbSet<GIANGVIEN> GIANGVIEN { get; set; }
        public virtual DbSet<KHOAHOC> KHOAHOC { get; set; }
        public virtual DbSet<LOPGIANGVIEN> LOPGIANGVIEN { get; set; }
        public virtual DbSet<LOPHOC> LOPHOC { get; set; }
        public virtual DbSet<LOPSINHVIEN> LOPSINHVIEN { get; set; }
        public virtual DbSet<SINHVIEN> SINHVIEN { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GIANGVIEN>()
                .Property(e => e.telephone)
                .IsFixedLength();

            modelBuilder.Entity<SINHVIEN>()
                .Property(e => e.telephone)
                .IsFixedLength();
        }
    }
}
