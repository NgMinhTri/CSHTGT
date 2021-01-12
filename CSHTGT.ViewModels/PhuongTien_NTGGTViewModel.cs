using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CSHTGT.ViewModels
{
    public class PhuongTien_NTGGTViewModel
    {
        //thuộc tính goomdf 2 bảng
        public int MaPT { get; set; }    
        public string TenPT { get; set; }
        public string BienSo { get; set; }       
        public string NhanHieu { get; set; }       
        public int SoChoNgoi { get; set; }   
        public string SoKhung { get; set; }       
        public string SoMay { get; set; }
        public string TaiTrong { get; set; }                                         
        public string UserName { get; set; }
        //khóa ngoại
        public int MaLoaiPhuongTien { get; set; }
        
    }
}
