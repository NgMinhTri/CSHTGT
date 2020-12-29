using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CSHTGT.Data.Migrations
{
    public partial class XoaRangBuoc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DoanhNghiepVanTai",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDN = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TinhTrang = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoanhNghiepVanTai", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DonVi",
                columns: table => new
                {
                    MaDonVi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenDonVi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DiaDiem = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    NhiemVu = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonVi", x => x.MaDonVi);
                });

            migrationBuilder.CreateTable(
                name: "HinhThucXuPhat",
                columns: table => new
                {
                    MaHinhThuc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenHinhThuc = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HinhThucXuPhat", x => x.MaHinhThuc);
                });

            migrationBuilder.CreateTable(
                name: "LoaiPhuongTien",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoai = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiPhuongTien", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NguoiThamGiaGiaoThong",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaDoanhNghiepVanTai = table.Column<int>(type: "int", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CMND = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QueQuan = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SDT = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PassWord = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiThamGiaGiaoThong", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NguoiThamGiaGiaoThong_DoanhNghiepVanTai_MaDoanhNghiepVanTai",
                        column: x => x.MaDoanhNghiepVanTai,
                        principalTable: "DoanhNghiepVanTai",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CanBo",
                columns: table => new
                {
                    IDCanBo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaDonVi = table.Column<int>(type: "int", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CMND = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CanBo", x => x.IDCanBo);
                    table.ForeignKey(
                        name: "FK_CanBo_DonVi_MaDonVi",
                        column: x => x.MaDonVi,
                        principalTable: "DonVi",
                        principalColumn: "MaDonVi",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GPLX",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaNgTGGiaoThong = table.Column<int>(type: "int", nullable: false),
                    MaDonVi = table.Column<int>(type: "int", nullable: false),
                    Hang = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayHetHan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoGPLX = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GPLX", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GPLX_DonVi_MaDonVi",
                        column: x => x.MaDonVi,
                        principalTable: "DonVi",
                        principalColumn: "MaDonVi",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GPLX_NguoiThamGiaGiaoThong_MaNgTGGiaoThong",
                        column: x => x.MaNgTGGiaoThong,
                        principalTable: "NguoiThamGiaGiaoThong",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhieuDangKyThuTuc",
                columns: table => new
                {
                    MaPhieu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaDonVi = table.Column<int>(type: "int", nullable: false),
                    MaNgTGGiaoThong = table.Column<int>(type: "int", nullable: false),
                    NgayDangKy = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuDangKyThuTuc", x => x.MaPhieu);
                    table.ForeignKey(
                        name: "FK_PhieuDangKyThuTuc_DonVi_MaDonVi",
                        column: x => x.MaDonVi,
                        principalTable: "DonVi",
                        principalColumn: "MaDonVi",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhieuDangKyThuTuc_NguoiThamGiaGiaoThong_MaNgTGGiaoThong",
                        column: x => x.MaNgTGGiaoThong,
                        principalTable: "NguoiThamGiaGiaoThong",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BienBanViPham",
                columns: table => new
                {
                    MaBienBan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaNgTGGiaoThong = table.Column<int>(type: "int", nullable: false),
                    MaHinhThucXuPhat = table.Column<int>(type: "int", nullable: false),
                    MaCanBo = table.Column<int>(type: "int", nullable: false),
                    NgayViPham = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayLap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HanNopPhat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LoiViPham = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SoQuyetDinh = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SoTienPhat = table.Column<int>(type: "int", nullable: false),
                    TinhTrangNopPhat = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BienBanViPham", x => x.MaBienBan);
                    table.ForeignKey(
                        name: "FK_BienBanViPham_CanBo_MaCanBo",
                        column: x => x.MaCanBo,
                        principalTable: "CanBo",
                        principalColumn: "IDCanBo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BienBanViPham_HinhThucXuPhat_MaHinhThucXuPhat",
                        column: x => x.MaHinhThucXuPhat,
                        principalTable: "HinhThucXuPhat",
                        principalColumn: "MaHinhThuc",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BienBanViPham_NguoiThamGiaGiaoThong_MaNgTGGiaoThong",
                        column: x => x.MaNgTGGiaoThong,
                        principalTable: "NguoiThamGiaGiaoThong",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhuongTien",
                columns: table => new
                {
                    MaPT = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaLoaiPT = table.Column<int>(type: "int", nullable: false),
                    MaNgTGGiaoThong = table.Column<int>(type: "int", nullable: false),
                    MaCanBo = table.Column<int>(type: "int", nullable: false),
                    TenPT = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    BienSo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    NhanHieu = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SoChoNgoi = table.Column<int>(type: "int", nullable: false),
                    SoKhung = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SoMay = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TaiTrong = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LoaiDangKy = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhuongTien", x => x.MaPT);
                    table.ForeignKey(
                        name: "FK_PhuongTien_CanBo_MaCanBo",
                        column: x => x.MaCanBo,
                        principalTable: "CanBo",
                        principalColumn: "IDCanBo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhuongTien_LoaiPhuongTien_MaLoaiPT",
                        column: x => x.MaLoaiPT,
                        principalTable: "LoaiPhuongTien",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhuongTien_NguoiThamGiaGiaoThong_MaNgTGGiaoThong",
                        column: x => x.MaNgTGGiaoThong,
                        principalTable: "NguoiThamGiaGiaoThong",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "File",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaPhieuThuTuc = table.Column<int>(type: "int", nullable: false),
                    TenFile = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LinkFile = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.ID);
                    table.ForeignKey(
                        name: "FK_File_PhieuDangKyThuTuc_MaPhieuThuTuc",
                        column: x => x.MaPhieuThuTuc,
                        principalTable: "PhieuDangKyThuTuc",
                        principalColumn: "MaPhieu",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BienBanViPham_MaCanBo",
                table: "BienBanViPham",
                column: "MaCanBo");

            migrationBuilder.CreateIndex(
                name: "IX_BienBanViPham_MaHinhThucXuPhat",
                table: "BienBanViPham",
                column: "MaHinhThucXuPhat");

            migrationBuilder.CreateIndex(
                name: "IX_BienBanViPham_MaNgTGGiaoThong",
                table: "BienBanViPham",
                column: "MaNgTGGiaoThong");

            migrationBuilder.CreateIndex(
                name: "IX_CanBo_MaDonVi",
                table: "CanBo",
                column: "MaDonVi");

            migrationBuilder.CreateIndex(
                name: "IX_File_MaPhieuThuTuc",
                table: "File",
                column: "MaPhieuThuTuc");

            migrationBuilder.CreateIndex(
                name: "IX_GPLX_MaDonVi",
                table: "GPLX",
                column: "MaDonVi");

            migrationBuilder.CreateIndex(
                name: "IX_GPLX_MaNgTGGiaoThong",
                table: "GPLX",
                column: "MaNgTGGiaoThong");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiThamGiaGiaoThong_MaDoanhNghiepVanTai",
                table: "NguoiThamGiaGiaoThong",
                column: "MaDoanhNghiepVanTai");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuDangKyThuTuc_MaDonVi",
                table: "PhieuDangKyThuTuc",
                column: "MaDonVi");

            migrationBuilder.CreateIndex(
                name: "IX_PhieuDangKyThuTuc_MaNgTGGiaoThong",
                table: "PhieuDangKyThuTuc",
                column: "MaNgTGGiaoThong");

            migrationBuilder.CreateIndex(
                name: "IX_PhuongTien_MaCanBo",
                table: "PhuongTien",
                column: "MaCanBo");

            migrationBuilder.CreateIndex(
                name: "IX_PhuongTien_MaLoaiPT",
                table: "PhuongTien",
                column: "MaLoaiPT");

            migrationBuilder.CreateIndex(
                name: "IX_PhuongTien_MaNgTGGiaoThong",
                table: "PhuongTien",
                column: "MaNgTGGiaoThong");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BienBanViPham");

            migrationBuilder.DropTable(
                name: "File");

            migrationBuilder.DropTable(
                name: "GPLX");

            migrationBuilder.DropTable(
                name: "PhuongTien");

            migrationBuilder.DropTable(
                name: "HinhThucXuPhat");

            migrationBuilder.DropTable(
                name: "PhieuDangKyThuTuc");

            migrationBuilder.DropTable(
                name: "CanBo");

            migrationBuilder.DropTable(
                name: "LoaiPhuongTien");

            migrationBuilder.DropTable(
                name: "NguoiThamGiaGiaoThong");

            migrationBuilder.DropTable(
                name: "DonVi");

            migrationBuilder.DropTable(
                name: "DoanhNghiepVanTai");
        }
    }
}
