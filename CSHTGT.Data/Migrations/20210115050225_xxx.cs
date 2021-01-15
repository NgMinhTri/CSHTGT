using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CSHTGT.Data.Migrations
{
    public partial class xxx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    HoTen = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CMND = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QueQuan = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SDT = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    PassWord = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiThamGiaGiaoThong", x => x.ID);
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
                    MaNgTGGiaoThong = table.Column<int>(type: "int", nullable: false),
                    CMNDNgLienQuan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayDangKy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    XetDuyet = table.Column<int>(type: "int", nullable: false),
                    LoaiDangKy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenPT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BienSo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NhanHieu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoChoNgoi = table.Column<int>(type: "int", nullable: false),
                    SoKhung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoMay = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuDangKyThuTuc", x => x.MaPhieu);
                    table.ForeignKey(
                        name: "FK_PhieuDangKyThuTuc_NguoiThamGiaGiaoThong_MaNgTGGiaoThong",
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
                    TenPT = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    BienSo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NhanHieu = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    SoChoNgoi = table.Column<int>(type: "int", nullable: false),
                    SoKhung = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SoMay = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TaiTrong = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TrangThai = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    XetDuyet = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhuongTien", x => x.MaPT);
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

            migrationBuilder.InsertData(
                table: "LoaiPhuongTien",
                columns: new[] { "ID", "MoTa", "TenLoai" },
                values: new object[,]
                {
                    { 1, "Phương tiện giao thông cơ giới đường bộ bao gồm xe ô tô; máy kéo; rơ moóc hoặc sơ mi rơ moóc được kéo bởi xe ô tô, máy kéo; xe máy (2 bánh, 3 bánh); xe đạp điện và các loại xe tương tự khác", "Xe cơ giới" },
                    { 2, "Phương tiện giao thông thô sơ đường bộ bao gồm xe đạp, xe xích lô, xe lăn, xe kéo và các loại xe tương tự khác.", "Xe thô sơ" },
                    { 3, "Tàu Container là phương tiện vận tải biển có cấu trúc đặc biệt, để chứa một lượng lớn hàng hóa được xếp trong các loại Container khác nhau.", "Tàu Container" },
                    { 4, "là một chiếc tàu thủy (hoạt động trên sông hoặc ven biển) chuyên chở hành khách cùng phương tiện của họ trên những tuyến đường và lịch trình cố định.", "Phà" },
                    { 5, "là một thuyền có đáy bằng, một phương tiện dùng để chở các hàng hóa nặng di chuyển chủ yếu ở các con kênh hoặc các con sông.", "Sà lan" }
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
                name: "IX_GPLX_MaDonVi",
                table: "GPLX",
                column: "MaDonVi");

            migrationBuilder.CreateIndex(
                name: "IX_GPLX_MaNgTGGiaoThong",
                table: "GPLX",
                column: "MaNgTGGiaoThong");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiThamGiaGiaoThong_CMND_SDT_Email_UserName",
                table: "NguoiThamGiaGiaoThong",
                columns: new[] { "CMND", "SDT", "Email", "UserName" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhieuDangKyThuTuc_MaNgTGGiaoThong",
                table: "PhieuDangKyThuTuc",
                column: "MaNgTGGiaoThong");

            migrationBuilder.CreateIndex(
                name: "IX_PhuongTien_BienSo",
                table: "PhuongTien",
                column: "BienSo",
                unique: true);

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
                name: "GPLX");

            migrationBuilder.DropTable(
                name: "PhieuDangKyThuTuc");

            migrationBuilder.DropTable(
                name: "PhuongTien");

            migrationBuilder.DropTable(
                name: "CanBo");

            migrationBuilder.DropTable(
                name: "HinhThucXuPhat");

            migrationBuilder.DropTable(
                name: "LoaiPhuongTien");

            migrationBuilder.DropTable(
                name: "NguoiThamGiaGiaoThong");

            migrationBuilder.DropTable(
                name: "DonVi");
        }
    }
}
