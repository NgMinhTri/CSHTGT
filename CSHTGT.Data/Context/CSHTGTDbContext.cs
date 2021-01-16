using CSHTGT.Data.Extension;
using CSHTGT.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CSHTGT.Data.Context
{
    public class CSHTGTDbContext : DbContext
    {
        public CSHTGTDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<BienBanViPham> BienBanViPhams { get; set; }
        public DbSet<CanBo> CanBos { get; set; }
        //public DbSet<DoanhNghiepVanTai> DoanhNghiepVanTais { get; set; }
        public DbSet<DonVi> DonVis { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<GPLX> GPLXes { get; set; }
        public DbSet<HinhThucXuPhat> HinhThucXuPhats { get; set; }
        //public DbSet<HoSoDangKyPhuongTien> HoSoDangKyPhuongTiens { get; set; }
        //public DbSet<HoSoSangTenPhuongTien> HoSoSangTenPhuongTiens { get; set; }
        //public DbSet<HoSoThuHoiPhuongTien> HoSoThuHoiPhuongTiens { get; set; }
        public DbSet<LoaiPhuongTien> LoaiPhuongTiens { get; set; }
        public DbSet<NguoiThamGiaGiaoThong> NguoiThamGiaGiaoThongs { get; set; }
        public DbSet<PhieuDangKyThuTuc> PhieuDangKyThuTucs { get; set; }
        public DbSet<PhuongTien> PhuongTiens { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
            modelBuilder.Entity<NguoiThamGiaGiaoThong>()
                .HasIndex(n => new { n.CMND, n.SDT, n.Email, n.UserName })
                .IsUnique();

            modelBuilder.Entity<PhuongTien>()
                .HasIndex(p => new { p.BienSo })
                .IsUnique();
            modelBuilder.Entity<CanBo>()
               .HasIndex(n => new { n.CMND, n.SDT, n.Email, n.UserName })
               .IsUnique();

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=.;Database=CSHTGT;Trusted_Connection=True;");
        }
    }
}
