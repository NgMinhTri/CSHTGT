using System;
using System.Collections.Generic;
using System.Text;

namespace CSHTGT.ViewModels
{
    public class BienBanViPhamViewModel
    {

        public int MaBienBan { get; set; }
        
        public int MaNgTGGiaoThong { get; set; }
        
        public int MaHinhThucXuPhat { get; set; }
        
        public int MaCanBo { get; set; }
        
        public DateTime HanNopPhat { get; set; }
        
        public string LoiViPham { get; set; }
        
        public DateTime NgayLap { get; set; }
        
        public DateTime NgayViPham { get; set; }
      
        public string SoQuyetDinh { get; set; }

        public int SoTienPhat { get; set; }
        
        public string TinhTrangNopPhat { get; set; }
    }
}
