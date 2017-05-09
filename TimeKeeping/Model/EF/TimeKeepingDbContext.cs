namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TimeKeepingDbContext : DbContext
    {
        public TimeKeepingDbContext()
            : base("name=TimeKeepingDbContext")
        {
        }

        public virtual DbSet<CaLamViec> CaLamViecs { get; set; }
        public virtual DbSet<ChamCong> ChamCongs { get; set; }
        public virtual DbSet<ChucVu> ChucVus { get; set; }
        public virtual DbSet<Luong> Luongs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<PhongBan> PhongBans { get; set; }
        public virtual DbSet<PhuCap> PhuCaps { get; set; }
        public virtual DbSet<Quyen> Quyens { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<ThuongPhat> ThuongPhats { get; set; }
        public virtual DbSet<TinhTrang> TinhTrangs { get; set; }
        public virtual DbSet<TraLuong> TraLuongs { get; set; }
        public virtual DbSet<ViewChamCong> ViewChamCongs { get; set; }
        public virtual DbSet<ViewNhanVien> ViewNhanViens { get; set; }
        public virtual DbSet<ViewPhuCap> ViewPhuCaps { get; set; }
        public virtual DbSet<ViewTaiKhoan> ViewTaiKhoans { get; set; }
        public virtual DbSet<ViewThuongPhat> ViewThuongPhats { get; set; }
        public virtual DbSet<ViewTraLuong> ViewTraLuongs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NhanVien>()
                .Property(e => e.CMND)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.DienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.AnhDaiDien)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.TenDangNhap)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<TinhTrang>()
                .Property(e => e.KiHieu)
                .IsUnicode(false);

            modelBuilder.Entity<ViewChamCong>()
                .Property(e => e.KiHieu)
                .IsUnicode(false);

            modelBuilder.Entity<ViewNhanVien>()
                .Property(e => e.CMND)
                .IsUnicode(false);

            modelBuilder.Entity<ViewNhanVien>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<ViewNhanVien>()
                .Property(e => e.DienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<ViewNhanVien>()
                .Property(e => e.AnhDaiDien)
                .IsUnicode(false);

            modelBuilder.Entity<ViewTaiKhoan>()
                .Property(e => e.TenDangNhap)
                .IsUnicode(false);

            modelBuilder.Entity<ViewTaiKhoan>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);
        }
    }
}
