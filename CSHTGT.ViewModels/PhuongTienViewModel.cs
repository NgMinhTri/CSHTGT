using System;
using System.Collections.Generic;
using System.Text;

namespace CSHTGT.ViewModels
{
    public class PhuongTienViewModel
    {
        public string TenPT { get; set; }
        public string BienSo { get; set; }
        public string NhanHieu { get; set; }
        public int SoChoNgoi { get; set; }
        public string SoKhung { get; set; }
        public string SoMay { get; set; }
        public string LoaiDangKy { get; set; }
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public string CMND { get; set; }
        public string Email { get; set; }
        public DateTime NgaySinh { get; set; }
        public string SDT { get; set; }
        public string PassWord { get; set; }
        public string UserName { get; set; }
        //khóa ngoại
        public int MaLoaiPhuongTien { get; set; }
        
    }
}
