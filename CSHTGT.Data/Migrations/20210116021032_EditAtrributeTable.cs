using Microsoft.EntityFrameworkCore.Migrations;

namespace CSHTGT.Data.Migrations
{
    public partial class EditAtrributeTable : Migration
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
                unique: true,
                filter: "[CMND] IS NOT NULL AND [SDT] IS NOT NULL AND [Email] IS NOT NULL AND [UserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CanBo_CMND_SDT_Email_UserName",
                table: "CanBo",
                columns: new[] { "CMND", "SDT", "Email", "UserName" },
                unique: true,
                filter: "[CMND] IS NOT NULL AND [SDT] IS NOT NULL AND [Email] IS NOT NULL AND [UserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PhuongTien_BienSo",
                table: "PhuongTien");

            migrationBuilder.DropIndex(
                name: "IX_NguoiThamGiaGiaoThong_CMND_SDT_Email_UserName",
                table: "NguoiThamGiaGiaoThong");

            migrationBuilder.DropIndex(
                name: "IX_CanBo_CMND_SDT_Email_UserName",
                table: "CanBo");
        }
    }
}
