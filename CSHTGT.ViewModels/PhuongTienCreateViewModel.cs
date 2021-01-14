using System;
using System.Collections.Generic;
using System.Text;

namespace CSHTGT.ViewModels
{
    public class PhuongTienCreateViewModel
    {
        public string CMND { get; set; }
        // thuộc tính gồm 1 bảng               
        public string TenPT { get; set; }
        public string BienSo { get; set; }
        public string NhanHieu { get; set; }
        public int SoChoNgoi { get; set; }
        public string SoKhung { get; set; }
        public string SoMay { get; set; }
        public string TaiTrong { get; set; }
        public string TrangThai { get; set; }
        public int MaLoaiPhuongTien { get; set; }
    }
}
