using Microsoft.EntityFrameworkCore.Migrations;

namespace CSHTGT.Data.Migrations
{
    public partial class SetUniqueAttribute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_PhuongTien_BienSo",
                table: "PhuongTien",
                column: "BienSo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NguoiThamGiaGiaoThong_CMND_SDT_Email_UserName",
                table: "NguoiThamGiaGiaoThong",
                columns: new[] { "CMND", "SDT", "Email", "UserName" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PhuongTien_BienSo",
                table: "PhuongTien");

            migrationBuilder.DropIndex(
                name: "IX_NguoiThamGiaGiaoThong_CMND_SDT_Email_UserName",
                table: "NguoiThamGiaGiaoThong");
        }
    }
}
