﻿// <auto-generated />
using System;
using CSHTGT.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CSHTGT.Data.Migrations
{
    [DbContext(typeof(CSHTGTDbContext))]
    [Migration("20210111042127_CSHTGT_DB")]
    partial class CSHTGT_DB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("CSHTGT.Data.Models.BienBanViPham", b =>
                {
                    b.Property<int>("MaBienBan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("HanNopPhat")
                        .HasColumnType("datetime2");

                    b.Property<string>("LoiViPham")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("MaCanBo")
                        .HasColumnType("int");

                    b.Property<int>("MaHinhThucXuPhat")
                        .HasColumnType("int");

                    b.Property<int>("MaNgTGGiaoThong")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayLap")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayViPham")
                        .HasColumnType("datetime2");

                    b.Property<string>("SoQuyetDinh")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("SoTienPhat")
                        .HasColumnType("int");

                    b.Property<string>("TinhTrangNopPhat")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("MaBienBan");

                    b.HasIndex("MaCanBo");

                    b.HasIndex("MaHinhThucXuPhat");

                    b.HasIndex("MaNgTGGiaoThong");

                    b.ToTable("BienBanViPham");
                });

            modelBuilder.Entity("CSHTGT.Data.Models.CanBo", b =>
                {
                    b.Property<int>("IDCanBo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CMND")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("DiaChi")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Email")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("HoTen")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("MaDonVi")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("SDT")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("UserName")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("IDCanBo");

                    b.HasIndex("MaDonVi");

                    b.ToTable("CanBo");
                });

            modelBuilder.Entity("CSHTGT.Data.Models.DonVi", b =>
                {
                    b.Property<int>("MaDonVi")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("DiaDiem")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("NhiemVu")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("TenDonVi")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("MaDonVi");

                    b.ToTable("DonVi");
                });

            modelBuilder.Entity("CSHTGT.Data.Models.File", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("LinkFile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaPhieuThuTuc")
                        .HasColumnType("int");

                    b.Property<string>("TenFile")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("ID");

                    b.HasIndex("MaPhieuThuTuc");

                    b.ToTable("File");
                });

            modelBuilder.Entity("CSHTGT.Data.Models.GPLX", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Hang")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("MaDonVi")
                        .HasColumnType("int");

                    b.Property<int>("MaNgTGGiaoThong")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayHetHan")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<string>("SoGPLX")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("TrangThai")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("ID");

                    b.HasIndex("MaDonVi");

                    b.HasIndex("MaNgTGGiaoThong");

                    b.ToTable("GPLX");
                });

            modelBuilder.Entity("CSHTGT.Data.Models.HinhThucXuPhat", b =>
                {
                    b.Property<int>("MaHinhThuc")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("MoTa")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("TenHinhThuc")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("MaHinhThuc");

                    b.ToTable("HinhThucXuPhat");
                });

            modelBuilder.Entity("CSHTGT.Data.Models.LoaiPhuongTien", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("MoTa")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("TenLoai")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("ID");

                    b.ToTable("LoaiPhuongTien");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            MoTa = "Phương tiện giao thông cơ giới đường bộ bao gồm xe ô tô; máy kéo; rơ moóc hoặc sơ mi rơ moóc được kéo bởi xe ô tô, máy kéo; xe máy (2 bánh, 3 bánh); xe đạp điện và các loại xe tương tự khác",
                            TenLoai = "Xe cơ giới"
                        },
                        new
                        {
                            ID = 2,
                            MoTa = "Phương tiện giao thông thô sơ đường bộ bao gồm xe đạp, xe xích lô, xe lăn, xe kéo và các loại xe tương tự khác.",
                            TenLoai = "Xe thô sơ"
                        },
                        new
                        {
                            ID = 3,
                            MoTa = "Tàu Container là phương tiện vận tải biển có cấu trúc đặc biệt, để chứa một lượng lớn hàng hóa được xếp trong các loại Container khác nhau.",
                            TenLoai = "Tàu Container"
                        },
                        new
                        {
                            ID = 4,
                            MoTa = "là một chiếc tàu thủy (hoạt động trên sông hoặc ven biển) chuyên chở hành khách cùng phương tiện của họ trên những tuyến đường và lịch trình cố định.",
                            TenLoai = "Phà"
                        },
                        new
                        {
                            ID = 5,
                            MoTa = "là một thuyền có đáy bằng, một phương tiện dùng để chở các hàng hóa nặng di chuyển chủ yếu ở các con kênh hoặc các con sông.",
                            TenLoai = "Sà lan"
                        });
                });

            modelBuilder.Entity("CSHTGT.Data.Models.NguoiThamGiaGiaoThong", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CMND")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("DiaChi")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("NgaySinh")
                        .HasColumnType("datetime2");

                    b.Property<string>("PassWord")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("QueQuan")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("SDT")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("ID");

                    b.ToTable("NguoiThamGiaGiaoThong");
                });

            modelBuilder.Entity("CSHTGT.Data.Models.PhieuDangKyThuTuc", b =>
                {
                    b.Property<int>("MaPhieu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("MaDonVi")
                        .HasColumnType("int");

                    b.Property<int>("MaNgTGGiaoThong")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayDangKy")
                        .HasColumnType("datetime2");

                    b.HasKey("MaPhieu");

                    b.HasIndex("MaDonVi");

                    b.HasIndex("MaNgTGGiaoThong");

                    b.ToTable("PhieuDangKyThuTuc");
                });

            modelBuilder.Entity("CSHTGT.Data.Models.PhuongTien", b =>
                {
                    b.Property<int>("MaPT")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("BienSo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("MaLoaiPT")
                        .HasColumnType("int");

                    b.Property<int>("MaNgTGGiaoThong")
                        .HasColumnType("int");

                    b.Property<string>("NhanHieu")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("SoChoNgoi")
                        .HasColumnType("int");

                    b.Property<string>("SoKhung")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("SoMay")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("TaiTrong")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("TenPT")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("TrangThai")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("MaPT");

                    b.HasIndex("MaLoaiPT");

                    b.HasIndex("MaNgTGGiaoThong");

                    b.ToTable("PhuongTien");
                });

            modelBuilder.Entity("CSHTGT.Data.Models.BienBanViPham", b =>
                {
                    b.HasOne("CSHTGT.Data.Models.CanBo", "CanBo")
                        .WithMany("BienBanViPhams")
                        .HasForeignKey("MaCanBo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CSHTGT.Data.Models.HinhThucXuPhat", "HinhThucXuPhat")
                        .WithMany("BienBanViPhams")
                        .HasForeignKey("MaHinhThucXuPhat")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CSHTGT.Data.Models.NguoiThamGiaGiaoThong", "NguoiThamGiaGiaoThong")
                        .WithMany("BienBanViPhams")
                        .HasForeignKey("MaNgTGGiaoThong")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CanBo");

                    b.Navigation("HinhThucXuPhat");

                    b.Navigation("NguoiThamGiaGiaoThong");
                });

            modelBuilder.Entity("CSHTGT.Data.Models.CanBo", b =>
                {
                    b.HasOne("CSHTGT.Data.Models.DonVi", "DonVi")
                        .WithMany("CanBos")
                        .HasForeignKey("MaDonVi")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DonVi");
                });

            modelBuilder.Entity("CSHTGT.Data.Models.File", b =>
                {
                    b.HasOne("CSHTGT.Data.Models.PhieuDangKyThuTuc", "PhieuDangKyThuTuc")
                        .WithMany("Files")
                        .HasForeignKey("MaPhieuThuTuc")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PhieuDangKyThuTuc");
                });

            modelBuilder.Entity("CSHTGT.Data.Models.GPLX", b =>
                {
                    b.HasOne("CSHTGT.Data.Models.DonVi", "DonVi")
                        .WithMany("GPLXes")
                        .HasForeignKey("MaDonVi")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CSHTGT.Data.Models.NguoiThamGiaGiaoThong", "NguoiThamGiaGiaoThong")
                        .WithMany("GPLXes")
                        .HasForeignKey("MaNgTGGiaoThong")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DonVi");

                    b.Navigation("NguoiThamGiaGiaoThong");
                });

            modelBuilder.Entity("CSHTGT.Data.Models.PhieuDangKyThuTuc", b =>
                {
                    b.HasOne("CSHTGT.Data.Models.DonVi", "DonVi")
                        .WithMany("PhieuDangKyThuTucs")
                        .HasForeignKey("MaDonVi")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CSHTGT.Data.Models.NguoiThamGiaGiaoThong", "NguoiThamGiaGiaoThong")
                        .WithMany()
                        .HasForeignKey("MaNgTGGiaoThong")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DonVi");

                    b.Navigation("NguoiThamGiaGiaoThong");
                });

            modelBuilder.Entity("CSHTGT.Data.Models.PhuongTien", b =>
                {
                    b.HasOne("CSHTGT.Data.Models.LoaiPhuongTien", "LoaiPhuongTien")
                        .WithMany("PhuongTiens")
                        .HasForeignKey("MaLoaiPT")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CSHTGT.Data.Models.NguoiThamGiaGiaoThong", "NguoiThamGiaGiaoThong")
                        .WithMany("PhuongTiens")
                        .HasForeignKey("MaNgTGGiaoThong")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LoaiPhuongTien");

                    b.Navigation("NguoiThamGiaGiaoThong");
                });

            modelBuilder.Entity("CSHTGT.Data.Models.CanBo", b =>
                {
                    b.Navigation("BienBanViPhams");
                });

            modelBuilder.Entity("CSHTGT.Data.Models.DonVi", b =>
                {
                    b.Navigation("CanBos");

                    b.Navigation("GPLXes");

                    b.Navigation("PhieuDangKyThuTucs");
                });

            modelBuilder.Entity("CSHTGT.Data.Models.HinhThucXuPhat", b =>
                {
                    b.Navigation("BienBanViPhams");
                });

            modelBuilder.Entity("CSHTGT.Data.Models.LoaiPhuongTien", b =>
                {
                    b.Navigation("PhuongTiens");
                });

            modelBuilder.Entity("CSHTGT.Data.Models.NguoiThamGiaGiaoThong", b =>
                {
                    b.Navigation("BienBanViPhams");

                    b.Navigation("GPLXes");

                    b.Navigation("PhuongTiens");
                });

            modelBuilder.Entity("CSHTGT.Data.Models.PhieuDangKyThuTuc", b =>
                {
                    b.Navigation("Files");
                });
#pragma warning restore 612, 618
        }
    }
}
