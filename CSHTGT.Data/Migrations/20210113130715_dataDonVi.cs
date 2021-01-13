using Microsoft.EntityFrameworkCore.Migrations;

namespace CSHTGT.Data.Migrations
{
    public partial class dataDonVi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DonVi",
                columns: new[] { "MaDonVi", "DiaDiem", "NhiemVu", "TenDonVi" },
                values: new object[,]
                {
                    { 1, "TP.Hồ Chí Minh", "Quản lý giao thông tại địa phương", "CSGT TP.Hồ Chí Minh" },
                    { 2, "Quảng Nam", "Quản lý giao thông tại địa phương", "CSGT tỉnh Quảng Nam" },
                    { 3, "Quảng Ngãi", "Quản lý giao thông tại địa phương", "CSGT tỉnh Quảng Ngãi" },
                    { 4, "Long An", "Quản lý giao thông tại địa phương", "CSGT tỉnh Long An" },
                    { 5, "Bình Định", "Quản lý giao thông tại địa phương", "CSGT tỉnh Bình Định" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DonVi",
                keyColumn: "MaDonVi",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DonVi",
                keyColumn: "MaDonVi",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DonVi",
                keyColumn: "MaDonVi",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DonVi",
                keyColumn: "MaDonVi",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DonVi",
                keyColumn: "MaDonVi",
                keyValue: 5);
        }
    }
}
