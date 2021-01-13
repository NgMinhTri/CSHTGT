using Microsoft.EntityFrameworkCore.Migrations;

namespace CSHTGT.Data.Migrations
{
    public partial class creattableLOAIDANGKY : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaNgTGGiaoThong2",
                table: "PhieuDangKyThuTuc",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PhieuDangKyThuTuc_MaNgTGGiaoThong2",
                table: "PhieuDangKyThuTuc",
                column: "MaNgTGGiaoThong2");

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuDangKyThuTuc_NguoiThamGiaGiaoThong_MaNgTGGiaoThong2",
                table: "PhieuDangKyThuTuc",
                column: "MaNgTGGiaoThong2",
                principalTable: "NguoiThamGiaGiaoThong",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhieuDangKyThuTuc_NguoiThamGiaGiaoThong_MaNgTGGiaoThong2",
                table: "PhieuDangKyThuTuc");

            migrationBuilder.DropIndex(
                name: "IX_PhieuDangKyThuTuc_MaNgTGGiaoThong2",
                table: "PhieuDangKyThuTuc");

            migrationBuilder.DropColumn(
                name: "MaNgTGGiaoThong2",
                table: "PhieuDangKyThuTuc");
        }
    }
}
