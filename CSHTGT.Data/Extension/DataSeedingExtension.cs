using CSHTGT.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CSHTGT.Data.Extension
{
    public static class DataSeedingExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoaiPhuongTien>().HasData(
                new LoaiPhuongTien() { ID = 1, TenLoai = "Xe cơ giới", MoTa = "Phương tiện giao thông cơ giới đường bộ bao gồm xe ô tô; máy kéo; rơ moóc hoặc sơ mi rơ moóc được kéo bởi xe ô tô, máy kéo; xe máy (2 bánh, 3 bánh); xe đạp điện và các loại xe tương tự khác" },
                new LoaiPhuongTien() { ID = 2, TenLoai = "Xe thô sơ", MoTa = "Phương tiện giao thông thô sơ đường bộ bao gồm xe đạp, xe xích lô, xe lăn, xe kéo và các loại xe tương tự khác." },
                new LoaiPhuongTien() { ID = 3, TenLoai = "Tàu Container", MoTa = "Tàu Container là phương tiện vận tải biển có cấu trúc đặc biệt, để chứa một lượng lớn hàng hóa được xếp trong các loại Container khác nhau." },
                new LoaiPhuongTien() { ID = 4, TenLoai = "Phà", MoTa = "là một chiếc tàu thủy (hoạt động trên sông hoặc ven biển) chuyên chở hành khách cùng phương tiện của họ trên những tuyến đường và lịch trình cố định." },
                new LoaiPhuongTien() { ID = 5, TenLoai = "Sà lan", MoTa = "là một thuyền có đáy bằng, một phương tiện dùng để chở các hàng hóa nặng di chuyển chủ yếu ở các con kênh hoặc các con sông." }
                );

            //modelBuilder.Entity<DoanhNghiepVanTai>().HasData(
            //    new DoanhNghiepVanTai() { ID = 1, TenDN = "Công ty Vận Tải Hoàng Minh", DiaChi = "Quận 2, TPHCM", TinhTrang="Đang làm việc" },
            //    new DoanhNghiepVanTai() { ID = 2, TenDN = "Công ty Vận Tải HH Trọng Tấn", DiaChi = "366/12 Thành Thái, Tân Phú", TinhTrang = "Đang làm việc" },
            //    new DoanhNghiepVanTai() { ID = 3, TenDN = "Công ty Vận Tải Quốc Tế LACCO ", DiaChi = "Trần Hưng Đạo, Quận 5, TPHCM", TinhTrang = "Đang làm việc" },
            //    new DoanhNghiepVanTai() { ID = 4, TenDN = "Công ty Vận Tải Mạnh Cường Quân", DiaChi = "Võ Văn Kiệt, Quận 5", TinhTrang = "Đang làm việc" },
            //    new DoanhNghiepVanTai() { ID = 5, TenDN = "Công ty vận tải Trịnh Nghiên", DiaChi = "Landmark 81, Bình Thạnh", TinhTrang = "Đang làm việc" }
            //    );
            modelBuilder.Entity<DonVi>().HasData(
                new DonVi() { MaDonVi = 1, TenDonVi = "CSGT TP.Hồ Chí Minh", DiaDiem = "TP.Hồ Chí Minh", NhiemVu = "Quản lý giao thông tại địa phương" },
                new DonVi() { MaDonVi = 2, TenDonVi = "CSGT tỉnh Quảng Nam", DiaDiem = "Quảng Nam", NhiemVu = "Quản lý giao thông tại địa phương" },
                new DonVi() { MaDonVi = 3, TenDonVi = "CSGT tỉnh Quảng Ngãi", DiaDiem = "Quảng Ngãi", NhiemVu = "Quản lý giao thông tại địa phương" },
                new DonVi() { MaDonVi = 4, TenDonVi = "CSGT tỉnh Long An", DiaDiem = "Long An", NhiemVu = "Quản lý giao thông tại địa phương" },
                new DonVi() { MaDonVi = 5, TenDonVi = "CSGT tỉnh Bình Định", DiaDiem = "Bình Định", NhiemVu = "Quản lý giao thông tại địa phương" }
                );
        }
    }
}
