using Microsoft.EntityFrameworkCore.Migrations;

namespace CSHTGT.Data.Migrations
{
    public partial class UpdateDonvi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LoaiPhuongTien",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LoaiPhuongTien",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LoaiPhuongTien",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "LoaiPhuongTien",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "LoaiPhuongTien",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "NguoiThamGiaGiaoThong",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "SDT",
                table: "NguoiThamGiaGiaoThong",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "PassWord",
                table: "NguoiThamGiaGiaoThong",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "HoTen",
                table: "NguoiThamGiaGiaoThong",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "NguoiThamGiaGiaoThong",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "DiaChi",
                table: "NguoiThamGiaGiaoThong",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "CMND",
                table: "NguoiThamGiaGiaoThong",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "NguoiThamGiaGiaoThong",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SDT",
                table: "NguoiThamGiaGiaoThong",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PassWord",
                table: "NguoiThamGiaGiaoThong",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HoTen",
                table: "NguoiThamGiaGiaoThong",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "NguoiThamGiaGiaoThong",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DiaChi",
                table: "NguoiThamGiaGiaoThong",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CMND",
                table: "NguoiThamGiaGiaoThong",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

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
        }
    }
}
