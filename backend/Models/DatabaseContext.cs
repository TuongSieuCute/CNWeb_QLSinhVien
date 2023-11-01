using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace backend.Models;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Giangvien> Giangviens { get; set; }

    public virtual DbSet<Hocki> Hockis { get; set; }

    public virtual DbSet<Ketqua> Ketquas { get; set; }

    public virtual DbSet<Khoa> Khoas { get; set; }

    public virtual DbSet<Lophocphan> Lophocphans { get; set; }

    public virtual DbSet<Monhoc> Monhocs { get; set; }

    public virtual DbSet<Sinhvien> Sinhviens { get; set; }

    public virtual DbSet<Taikhoan> Taikhoans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=DESKTOP-GOEUFGD\\SQLEXPRESS;Database=QUANLYSINHVIEN;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Giangvien>(entity =>
        {
            entity.HasKey(e => e.Magv).HasName("PK__GIANGVIE__603F38B1B8F3C3D0");

            entity.ToTable("GIANGVIEN");

            entity.Property(e => e.Magv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MAGV");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Mak)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MAK");
            entity.Property(e => e.Sodienthoai)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("SODIENTHOAI");
            entity.Property(e => e.Tengv)
                .HasMaxLength(50)
                .HasColumnName("TENGV");

            entity.HasOne(d => d.MakNavigation).WithMany(p => p.Giangviens)
                .HasForeignKey(d => d.Mak)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GIANGVIEN__MAK__403A8C7D");
        });

        modelBuilder.Entity<Hocki>(entity =>
        {
            entity.HasKey(e => e.Mahk).HasName("PK__HOCKI__603F20C531F11E95");

            entity.ToTable("HOCKI");

            entity.Property(e => e.Mahk)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MAHK");
            entity.Property(e => e.Namhoc)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("NAMHOC");
            entity.Property(e => e.Ngaybatdau)
                .HasColumnType("date")
                .HasColumnName("NGAYBATDAU");
            entity.Property(e => e.Ngayketthuc)
                .HasColumnType("date")
                .HasColumnName("NGAYKETTHUC");
            entity.Property(e => e.Tenhk)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("TENHK");
        });

        modelBuilder.Entity<Ketqua>(entity =>
        {
            entity.HasKey(e => e.Makq).HasName("PK__KETQUA__603F59379C0A0B09");

            entity.ToTable("KETQUA");

            entity.Property(e => e.Makq)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MAKQ");
            entity.Property(e => e.Diemck)
                .HasColumnType("decimal(10, 1)")
                .HasColumnName("DIEMCK");
            entity.Property(e => e.Diemgk)
                .HasColumnType("decimal(10, 1)")
                .HasColumnName("DIEMGK");
            entity.Property(e => e.Diemtb)
                .HasColumnType("decimal(10, 1)")
                .HasColumnName("DIEMTB");
            entity.Property(e => e.Mahk)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MAHK");
            entity.Property(e => e.Mamh)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MAMH");
            entity.Property(e => e.Masv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MASV");

            entity.HasOne(d => d.MahkNavigation).WithMany(p => p.Ketquas)
                .HasForeignKey(d => d.Mahk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__KETQUA__MAHK__4D94879B");

            entity.HasOne(d => d.MamhNavigation).WithMany(p => p.Ketquas)
                .HasForeignKey(d => d.Mamh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__KETQUA__MAMH__4BAC3F29");

            entity.HasOne(d => d.MasvNavigation).WithMany(p => p.Ketquas)
                .HasForeignKey(d => d.Masv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__KETQUA__MASV__4CA06362");
        });

        modelBuilder.Entity<Khoa>(entity =>
        {
            entity.HasKey(e => e.Mak).HasName("PK__KHOA__C7907785524FDF82");

            entity.ToTable("KHOA");

            entity.Property(e => e.Mak)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MAK");
            entity.Property(e => e.Tenk)
                .HasMaxLength(50)
                .HasColumnName("TENK");
        });

        modelBuilder.Entity<Lophocphan>(entity =>
        {
            entity.HasKey(e => e.Malhp).HasName("PK__LOPHOCPH__7A3D1B6E2FED3DC3");

            entity.ToTable("LOPHOCPHAN");

            entity.Property(e => e.Malhp)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MALHP");
            entity.Property(e => e.Giohocbatdau).HasColumnName("GIOHOCBATDAU");
            entity.Property(e => e.Giohocketthuc).HasColumnName("GIOHOCKETTHUC");
            entity.Property(e => e.Magv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MAGV");
            entity.Property(e => e.Mahk)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MAHK");
            entity.Property(e => e.Mak)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MAK");
            entity.Property(e => e.Mamh)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MAMH");
            entity.Property(e => e.Ngaybatdau)
                .HasColumnType("date")
                .HasColumnName("NGAYBATDAU");
            entity.Property(e => e.Ngayketthuc)
                .HasColumnType("date")
                .HasColumnName("NGAYKETTHUC");
            entity.Property(e => e.Soluongsv).HasColumnName("SOLUONGSV");

            entity.HasOne(d => d.MagvNavigation).WithMany(p => p.Lophocphans)
                .HasForeignKey(d => d.Magv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LOPHOCPHAN__MAGV__47DBAE45");

            entity.HasOne(d => d.MahkNavigation).WithMany(p => p.Lophocphans)
                .HasForeignKey(d => d.Mahk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LOPHOCPHAN__MAHK__48CFD27E");

            entity.HasOne(d => d.MakNavigation).WithMany(p => p.Lophocphans)
                .HasForeignKey(d => d.Mak)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LOPHOCPHAN__MAK__45F365D3");

            entity.HasOne(d => d.MamhNavigation).WithMany(p => p.Lophocphans)
                .HasForeignKey(d => d.Mamh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LOPHOCPHAN__MAMH__46E78A0C");
        });

        modelBuilder.Entity<Monhoc>(entity =>
        {
            entity.HasKey(e => e.Mamh).HasName("PK__MONHOC__603F69EBB5C7F0AD");

            entity.ToTable("MONHOC");

            entity.Property(e => e.Mamh)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MAMH");
            entity.Property(e => e.Mak)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MAK");
            entity.Property(e => e.Sotinchi).HasColumnName("SOTINCHI");
            entity.Property(e => e.Tenmh)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TENMH");

            entity.HasOne(d => d.MakNavigation).WithMany(p => p.Monhocs)
                .HasForeignKey(d => d.Mak)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MONHOC__MAK__3D5E1FD2");
        });

        modelBuilder.Entity<Sinhvien>(entity =>
        {
            entity.HasKey(e => e.Masv).HasName("PK__SINHVIEN__60228A2819F20108");

            entity.ToTable("SINHVIEN");

            entity.Property(e => e.Masv)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MASV");
            entity.Property(e => e.Diachi)
                .HasMaxLength(100)
                .HasColumnName("DIACHI");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Gioitinh)
                .HasMaxLength(5)
                .HasColumnName("GIOITINH");
            entity.Property(e => e.Hotensv)
                .HasMaxLength(50)
                .HasColumnName("HOTENSV");
            entity.Property(e => e.Mak)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MAK");
            entity.Property(e => e.Ngaysinh)
                .HasColumnType("date")
                .HasColumnName("NGAYSINH");
            entity.Property(e => e.Sodienthoai)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("SODIENTHOAI");

            entity.HasOne(d => d.MakNavigation).WithMany(p => p.Sinhviens)
                .HasForeignKey(d => d.Mak)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SINHVIEN__MAK__4316F928");

            entity.HasMany(d => d.Malhps).WithMany(p => p.Masvs)
                .UsingEntity<Dictionary<string, object>>(
                    "Dangki",
                    r => r.HasOne<Lophocphan>().WithMany()
                        .HasForeignKey("Malhp")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__DANGKI__MALHP__5165187F"),
                    l => l.HasOne<Sinhvien>().WithMany()
                        .HasForeignKey("Masv")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__DANGKI__MASV__5070F446"),
                    j =>
                    {
                        j.HasKey("Masv", "Malhp").HasName("PK__DANGKI__97815B9E96C2AA14");
                        j.ToTable("DANGKI");
                        j.IndexerProperty<string>("Masv")
                            .HasMaxLength(10)
                            .IsUnicode(false)
                            .HasColumnName("MASV");
                        j.IndexerProperty<string>("Malhp")
                            .HasMaxLength(10)
                            .IsUnicode(false)
                            .HasColumnName("MALHP");
                    });
        });

        modelBuilder.Entity<Taikhoan>(entity =>
        {
            entity.HasKey(e => e.Username).HasName("PK__TAIKHOAN__B15BE12F5535F0B6");

            entity.ToTable("TAIKHOAN");

            entity.Property(e => e.Username)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("USERNAME");
            entity.Property(e => e.Loaitk).HasColumnName("LOAITK");
            entity.Property(e => e.Password)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
