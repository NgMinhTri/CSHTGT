using Microsoft.EntityFrameworkCore.Migrations;

namespace CSHTGT.Data.Migrations
{
    public partial class DeleteTableDoanhNVT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NguoiThamGiaGiaoThong_DoanhNghiepVanTai_MaDoanhNghiepVanTai",
                table: "NguoiThamGiaGiaoThong");

            migrationBuilder.DropTable(
                name: "DoanhNghiepVanTai");

            migrationBuilder.DropIndex(
                name: "IX_NguoiThamGiaGiaoThong_MaDoanhNghiepVanTai",
                table: "NguoiThamGiaGiaoThong");

            migrationBuilder.DropColumn(
                name: "MaDoanhNghiepVanTai",
                table: "NguoiThamGiaGiaoThong");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaDoanhNghiepVanTai",
                table: "NguoiThamGiaGiaoThong",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DoanhNghiepVanTai",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiaChi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TenDN = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TinhTrang = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoanhNghiepVanTai", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NguoiThamGiaGiaoThong_MaDoanhNghiepVanTai",
                table: "NguoiThamGiaGiaoThong",
                column: "MaDoanhNghiepVanTai");

            migrationBuilder.AddForeignKey(
                name: "FK_NguoiThamGiaGiaoThong_DoanhNghiepVanTai_MaDoanhNghiepVanTai",
                table: "NguoiThamGiaGiaoThong",
                column: "MaDoanhNghiepVanTai",
                principalTable: "DoanhNghiepVanTai",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
