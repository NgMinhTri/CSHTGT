using System;
using System.Collections.Generic;
using System.Text;

namespace CSHTGT.ViewModels
{
    public class GPLXViewModel
    {
        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public string CMND { get; set; }

        public string Hang { get; set; }
        public DateTime NgayTao { get; set; }
        public DateTime NgayHetHan { get; set; }
        public string SoGPLX { get; set; }
        public string TrangThai { get; set; }
        public int ID { get; set; }

        //khóa ngoại
        public int MaDonVi { get; set; }
        public int MaNgTGGiaoThong { get; set; }
    }
}
