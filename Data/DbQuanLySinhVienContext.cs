using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BT_QUANLYSINHVIEN.Data;

public partial class DbQuanLySinhVienContext : DbContext
{
    public DbQuanLySinhVienContext()
    {
    }

    public DbQuanLySinhVienContext(DbContextOptions<DbQuanLySinhVienContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbGiaovien> TbGiaoviens { get; set; }

    public virtual DbSet<TbKhoa> TbKhoas { get; set; }

    public virtual DbSet<TbLophocphan> TbLophocphans { get; set; }

    public virtual DbSet<TbLopsinhhoat> TbLopsinhhoats { get; set; }

    public virtual DbSet<TbSinhvien> TbSinhviens { get; set; }

    public virtual DbSet<TbTruong> TbTruongs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=Thanh\\SQLEXPRESS;Initial Catalog=dbQuanLySinhVien;User ID=sa;Password=thanh@2003;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbGiaovien>(entity =>
        {
            entity.HasKey(e => e.Magiaovien).HasName("PK__tbGIAOVI__C509E6ADFB21B0E8");

            entity.ToTable("tbGIAOVIEN");

            entity.Property(e => e.Magiaovien)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MAGIAOVIEN");
            entity.Property(e => e.Diachi)
                .HasMaxLength(100)
                .HasColumnName("DIACHI");
            entity.Property(e => e.Makhoa)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MAKHOA");
            entity.Property(e => e.Sdt)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SDT");
            entity.Property(e => e.Tengiaovien)
                .HasMaxLength(50)
                .HasColumnName("TENGIAOVIEN");

            entity.HasOne(d => d.MakhoaNavigation).WithMany(p => p.TbGiaoviens)
                .HasForeignKey(d => d.Makhoa)
                .HasConstraintName("FK__tbGIAOVIE__MAKHO__3D5E1FD2");
        });

        modelBuilder.Entity<TbKhoa>(entity =>
        {
            entity.HasKey(e => e.Makhoa).HasName("PK__tbKHOA__22F4177004B9C7B7");

            entity.ToTable("tbKHOA");

            entity.Property(e => e.Makhoa)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MAKHOA");
            entity.Property(e => e.Matruong)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MATRUONG");
            entity.Property(e => e.Tenkhoa)
                .HasMaxLength(50)
                .HasColumnName("TENKHOA");

            entity.HasOne(d => d.MatruongNavigation).WithMany(p => p.TbKhoas)
                .HasForeignKey(d => d.Matruong)
                .HasConstraintName("FK__tbKHOA__MATRUONG__38996AB5");
        });

        modelBuilder.Entity<TbLophocphan>(entity =>
        {
            entity.HasKey(e => e.Mahocphan).HasName("PK__tbLOPHOC__93ACA5395CE13E6B");

            entity.ToTable("tbLOPHOCPHAN");

            entity.Property(e => e.Mahocphan)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MAHOCPHAN");
            entity.Property(e => e.Magiaovien)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MAGIAOVIEN");
            entity.Property(e => e.Soluong).HasColumnName("SOLUONG");
            entity.Property(e => e.Tenhocphan)
                .HasMaxLength(50)
                .HasColumnName("TENHOCPHAN");

            entity.HasOne(d => d.MagiaovienNavigation).WithMany(p => p.TbLophocphans)
                .HasForeignKey(d => d.Magiaovien)
                .HasConstraintName("FK__tbLOPHOCP__MAGIA__403A8C7D");
        });

        modelBuilder.Entity<TbLopsinhhoat>(entity =>
        {
            entity.HasKey(e => e.Malop).HasName("PK__tbLOPSIN__7A3DE211E50518A8");

            entity.ToTable("tbLOPSINHHOAT");

            entity.Property(e => e.Malop)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MALOP");
            entity.Property(e => e.Magiaovien)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MAGIAOVIEN");
            entity.Property(e => e.Makhoa)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MAKHOA");
            entity.Property(e => e.Soluong).HasColumnName("SOLUONG");
            entity.Property(e => e.Tenlop)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TENLOP");

            entity.HasOne(d => d.MagiaovienNavigation).WithMany(p => p.TbLopsinhhoats)
                .HasForeignKey(d => d.Magiaovien)
                .HasConstraintName("FK__tbLOPSINH__MAGIA__4316F928");

            entity.HasOne(d => d.MakhoaNavigation).WithMany(p => p.TbLopsinhhoats)
                .HasForeignKey(d => d.Makhoa)
                .HasConstraintName("FK__tbLOPSINH__MAKHO__440B1D61");
        });

        modelBuilder.Entity<TbSinhvien>(entity =>
        {
            entity.HasKey(e => e.Masinhvien).HasName("PK__tbSINHVI__268986638DB0D683");

            entity.ToTable("tbSINHVIEN");

            entity.Property(e => e.Masinhvien)
                .ValueGeneratedNever()
                .HasColumnName("MASINHVIEN");
            entity.Property(e => e.Diachi)
                .HasMaxLength(100)
                .HasColumnName("DIACHI");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Gioitinh)
                .HasMaxLength(10)
                .HasColumnName("GIOITINH");
            entity.Property(e => e.Malop)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MALOP");
            entity.Property(e => e.Ngaysinh).HasColumnName("NGAYSINH");
            entity.Property(e => e.Tensinhvien)
                .HasMaxLength(50)
                .HasColumnName("TENSINHVIEN");

            entity.HasOne(d => d.MalopNavigation).WithMany(p => p.TbSinhviens)
                .HasForeignKey(d => d.Malop)
                .HasConstraintName("FK__tbSINHVIE__MALOP__48CFD27E");
        });

        modelBuilder.Entity<TbTruong>(entity =>
        {
            entity.HasKey(e => e.Matruong).HasName("PK__tbTRUONG__4A7436426B2BB3D3");

            entity.ToTable("tbTRUONG");

            entity.Property(e => e.Matruong)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MATRUONG");
            entity.Property(e => e.Diachi)
                .HasMaxLength(100)
                .HasColumnName("DIACHI");
            entity.Property(e => e.Tentruong)
                .HasMaxLength(50)
                .HasColumnName("TENTRUONG");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
